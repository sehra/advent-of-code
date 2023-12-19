namespace AdventOfCode.Year2023;

public class Day19(string[] input)
{
	public int Part1()
	{
		var (flows, items) = Parse();
		var total = 0;

		foreach (var item in items)
		{
			var flow = "in";

			while (true)
			{
				if (flow is "A" or "R")
				{
					if (flow is "A")
					{
						total += item.X + item.M + item.A + item.S;
					}

					break;
				}

				foreach (var rule in flows[flow])
				{
					if (rule.Run(item) is { } jump)
					{
						flow = jump;
						break;
					}
				}
			}
		}

		return total;
	}

	public long Part2()
	{
		var (flows, _) = Parse();
		var lo = new Item(1, 1, 1, 1);
		var hi = new Item(4000, 4000, 4000, 4000);

		return Count("in", lo, hi);

		long Count(string flow, Item lo, Item hi)
		{
			if (flow is "R")
			{
				return 0;
			}

			if (flow is "A")
			{
				long x = hi.X - lo.X + 1;
				long m = hi.M - lo.M + 1;
				long a = hi.A - lo.A + 1;
				long s = hi.S - lo.S + 1;

				return x * m * a * s;
			}

			long total = 0;

			foreach (var rule in flows[flow])
			{
				if (rule is CondRule cond)
				{
					if (cond.Test is '<')
					{
						if (lo.Get(cond.Prop) < cond.Value)
						{
							total += Count(cond.Flow, lo, hi.With(cond.Prop, cond.Value - 1));
						}

						lo = lo.With(cond.Prop, cond.Value);
					}
					else if (cond.Test is '>')
					{
						if (hi.Get(cond.Prop) > cond.Value)
						{
							total += Count(cond.Flow, lo.With(cond.Prop, cond.Value + 1), hi);
						}

						hi = hi.With(cond.Prop, cond.Value);
					}
				}
				else if (rule is JumpRule jump)
				{
					total += Count(jump.Flow, lo, hi);
				}
			}

			return total;
		}
	}

	private abstract record class Rule
	{
		public abstract string Run(Item item);
	}

	private sealed record class CondRule(char Prop, char Test, int Value, string Flow) : Rule
	{
		public override string Run(Item item) => Test switch
		{
			'<' => item.Get(Prop) < Value ? Flow : null,
			'>' => item.Get(Prop) > Value ? Flow : null,
			_ => throw new Exception("test?"),
		};
	}

	private sealed record class JumpRule(string Flow) : Rule
	{
		public override string Run(Item item) => Flow;
	}

	private readonly record struct Item(int X, int M, int A, int S)
	{
		public int Get(char prop) => prop switch
		{
			'x' => X,
			'm' => M,
			'a' => A,
			's' => S,
			_ => throw new Exception("prop?"),
		};

		public Item With(char prop, int value) => prop switch
		{
			'x' => this with { X = value },
			'm' => this with { M = value },
			'a' => this with { A = value },
			's' => this with { S = value },
			_ => throw new Exception("prop?"),
		};
	}

	private (Dictionary<string, Rule[]>, List<Item>) Parse()
	{
		var flows = new Dictionary<string, Rule[]>();
		var items = new List<Item>();

		foreach (var line in input)
		{
			if (!line.StartsWith('{'))
			{
				var brace = line.IndexOf('{');
				var flow = line[..brace];
				flows.Add(flow, [.. line[(brace + 1)..^1].Split(',').Select(ParseRule)]);
			}
			else
			{
				items.Add(ParseItem(line));
			}
		}

		return (flows, items);

		static Rule ParseRule(string rule)
		{
			var colon = rule.IndexOf(':');

			if (colon is -1)
			{
				return new JumpRule(rule);
			}
			else
			{
				var prop = rule[0];
				var test = rule[1];
				var value = rule[2..colon].ToInt32();
				var flow = rule[(colon + 1)..];

				return new CondRule(prop, test, value, flow);
			}
		}

		static Item ParseItem(string item)
		{
			var props = item[1..^1].Split(',');
			var x = props[0][2..].ToInt32();
			var m = props[1][2..].ToInt32();
			var a = props[2][2..].ToInt32();
			var s = props[3][2..].ToInt32();

			return new(x, m, a, s);
		}
	}
}
