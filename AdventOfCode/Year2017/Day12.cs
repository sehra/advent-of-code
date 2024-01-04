namespace AdventOfCode.Year2017;

using Graph = Dictionary<int, HashSet<int>>;

public class Day12(string[] input)
{
	public int Part1() => Connected(Parse(), 0).Count;

	public int Part2()
	{
		var graph = Parse();
		var nodes = graph.Keys.ToHashSet();
		var count = 0;

		while (nodes.Count > 0)
		{
			var node = nodes.First();
			var seen = Connected(graph, node);
			nodes.ExceptWith(seen);
			count++;
		}

		return count;
	}

	private static HashSet<int> Connected(Graph graph, int start)
	{
		var seen = new HashSet<int>();
		var work = new Queue<int>();
		work.Enqueue(start);

		while (work.TryDequeue(out var node))
		{
			if (!seen.Add(node))
			{
				continue;
			}

			foreach (var next in graph[node])
			{
				work.Enqueue(next);
			}
		}

		return seen;
	}

	private Graph Parse()
	{
		var graph = new Graph();

		foreach (var line in input)
		{
			var split = line.Split("<->", StringSplitOptions.TrimEntries);
			graph.Add(split[0].ToInt32(), [.. split[1].Split(',').ToInt32()]);
		}

		return graph;
	}
}
