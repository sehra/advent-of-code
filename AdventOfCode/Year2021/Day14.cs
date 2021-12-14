namespace AdventOfCode.Year2021;

public class Day14
{
	private readonly string[] _input;

	public Day14(string[] input)
	{
		_input = input;
	}

	public long Part1()
	{
		return Solve(10);
	}

	public long Part2()
	{
		return Solve(40);
	}

	private long Solve(int steps)
	{
		var (template, rules) = Parse();
		var state = new Counter<Polymer, long>();

		foreach (var pair in template.Window(2))
		{
			state[new(pair[0], pair[1])] = 1;
		}

		for (int step = 0; step < steps; step++)
		{
			var next = new Counter<Polymer, long>();

			foreach (var (polymer, count) in state)
			{
				var insert = rules[polymer];
				next[new Polymer(polymer.L, insert)] += count;
				next[new Polymer(insert, polymer.R)] += count;
			}

			state = next;
		}

		var quantities = new Counter<char, long>()
		{
			[template[0]] = 1,
		};

		foreach (var (polymer, count) in state)
		{
			quantities[polymer.R] += count;
		}

		var min = quantities.Values.Min();
		var max = quantities.Values.Max();

		return max - min;
	}

	private (string Template, Dictionary<Polymer, char> Rules) Parse()
	{
		var rules = new Dictionary<Polymer, char>();

		foreach (var line in _input.Skip(1).Select(line => line.Split(" -> ")))
		{
			rules.Add(new(line[0][0], line[0][1]), line[1][0]);
		}

		return (_input[0], rules);
	}

	private readonly record struct Polymer(char L, char R);

	private class Counter<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public new TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => base[key] = value;
		}
	}
}
