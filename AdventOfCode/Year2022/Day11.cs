namespace AdventOfCode.Year2022;

public class Day11
{
	private readonly string[] _input;

	public Day11(string[] input)
	{
		_input = input;
	}

	public long Part1()
	{
		return Run(Parse(), 20, item => item / 3);
	}

	public long Part2()
	{
		var monkeys = Parse();
		var divisor = monkeys.Select(x => x.Divisor)
			.Aggregate(1, (a, b) => a * b, x => x);

		return Run(monkeys, 10_000, item => item % divisor);
	}

	private static long Run(List<Monkey> monkeys, int rounds, Func<long, long> divide)
	{
		var inspects = new DefaultDictionary<int, int>();

		foreach (var _ in Enumerable.Range(1, rounds))
		{
			foreach (var (index, monkey) in monkeys.Index())
			{
				foreach (var item in monkey.Items)
				{
					var inspected = divide(monkey.Inspect(item));
					var target = monkey.Target(inspected);
					monkeys[target].Items.Add(inspected);
					inspects[index]++;
				}

				monkey.Items.Clear();
			}
		}

		return inspects.Values.OrderDescending().Take(2)
			.Aggregate(1L, (a, b) => a * b, x => x);
	}

	private List<Monkey> Parse()
	{
		var monkeys = new List<Monkey>();

		foreach (var monkey in _input.GroupWhile((_, x) => !x.StartsWith("Monkey")))
		{
			monkeys.Add(new()
			{
				Items = monkey.ElementAt(1)["Starting items: ".Length..].Split(',').Select(Int64.Parse).ToList(),
				Inspect = ParseExpr(monkey.ElementAt(2)),
				Target = ParseTest(monkey.ElementAt(3), monkey.ElementAt(4), monkey.ElementAt(5)),
				Divisor = monkey.ElementAt(3)["Test: divisible by ".Length..].ToInt32(),
			});
		}

		return monkeys;

		static Func<long, long> ParseExpr(string expr)
		{
			var split = expr["Operation: new = old ".Length..].Split();
			Func<long, long, long> oper = split[0] switch
			{
				"+" => (long a, long b) => a + b,
				"*" => (long a, long b) => a * b,
				_ => throw new Exception("operator?"),
			};
			Func<long, long> what = null;
			if (split[1] is "old")
			{
				what = old => old;
			}
			else
			{
				var value = split[1].ToInt32();
				what = _ => value;
			}

			return old => oper(old, what(old));
		}

		static Func<long, int> ParseTest(string test, string ifTrue, string ifFalse)
		{
			var testValue = test["Test: divisible by ".Length..].ToInt32();
			var ifTrueValue = ifTrue["If true: throw to monkey ".Length..].ToInt32();
			var ifFalseValue = ifFalse["If false: throw to monkey ".Length..].ToInt32();

			return value => value % testValue == 0 ? ifTrueValue : ifFalseValue;
		}
	}

	private class Monkey
	{
		public List<long> Items { get; init; }
		public Func<long, long> Inspect { get; init; }
		public Func<long, int> Target { get; init; }
		public int Divisor { get; init; }
	}

	private class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public new TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => base[key] = value;
		}
	}
}
