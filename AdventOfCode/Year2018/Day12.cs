using System.Runtime.InteropServices;

namespace AdventOfCode.Year2018;

using Rule = (string Match, char Value);

public class Day12(string[] input)
{
	public long Part1()
	{
		var (state, rules) = Parse();
		var start = 0;

		for (int i = 0; i < 20; i++)
		{
			(start, state) = Step(rules, start, state);
		}

		return Sum(start, state);
	}

	public long Part2()
	{
		const long n = 50_000_000_000;

		var (state, rules) = Parse();
		var start = 0;
		var seen = new Dictionary<string, int>();

		while (seen.TryAdd(state, start))
		{
			(start, state) = Step(rules, start, state);
		}

		var prev = seen.Last();
		var curr = Sum(start, state);
		var delta = curr - Sum(prev.Value, prev.Key);

		return curr + (n - seen.Count) * delta;
	}

	private static long Sum(int start, string state) => state
		.Index(start).Where(kv => kv.Item is '#').Sum(kv => kv.Index);

	private static (int Start, string State) Step(Rule[] rules, int start, string state)
	{
		var next = new List<char>(state.Length + 8);

		foreach (var check in "....".Concat(state).Concat("....").Window(5))
		{
			var pot = rules
				.Where(r => r.Match.SequenceEqual(check))
				.Select(r => r.Value)
				.FirstOrDefault('.');
			next.Add(pot);
		}

		var span = CollectionsMarshal.AsSpan(next);
		var f = span.IndexOf('#');
		var l = span.LastIndexOf('#');

		return (start + f - 2, new(span[f..(l + 1)]));
	}

	private (string State, Rule[] Rules) Parse()
	{
		var state = input[0][15..];
		var rules = input.Skip(1)
			.Where(line => line[9] is '#')
			.Select(line => (line[..5], line[9]))
			.ToArray();

		return (state, rules);
	}
}
