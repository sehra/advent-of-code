namespace AdventOfCode.Year2025;

public class Day11(string[] input)
{
	public long Part1() => Solve(Parse(), [], "you", "out");

	public long Part2()
	{
		var graph = Parse();
		var cache = new Dictionary<(string, string), long>();
		var sdfo =
			Solve(graph, cache, "svr", "dac") *
			Solve(graph, cache, "dac", "fft") *
			Solve(graph, cache, "fft", "out");
		var sfdo =
			Solve(graph, cache, "svr", "fft") *
			Solve(graph, cache, "fft", "dac") *
			Solve(graph, cache, "dac", "out");

		return sdfo + sfdo;
	}

	private static long Solve(Dictionary<string, List<string>> graph,
		Dictionary<(string, string), long> cache, string from, string goal)
	{
		if (cache.TryGetValue((from, goal), out var value))
		{
			return value;
		}

		if (from == goal)
		{
			return 1;
		}

		if (!graph.TryGetValue(from, out var nodes))
		{
			return 0;
		}

		return cache[(from, goal)] = nodes.Sum(next => Solve(graph, cache, next, goal));
	}

	private Dictionary<string, List<string>> Parse() => input
		.Select(line => line.Split(": "))
		.ToDictionary(parts => parts[0], parts => parts[1].Split(' ').ToList());
}
