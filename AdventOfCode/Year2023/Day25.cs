namespace AdventOfCode.Year2023;

public class Day25(string[] input)
{
	public int Part1()
	{
		var graph = new Dictionary<string, HashSet<string>>();

		foreach (var line in input)
		{
			var u = line[..3];
			graph.TryAdd(u, []);

			foreach (var v in line[5..].Split())
			{
				graph.TryAdd(v, []);
				graph[u].Add(v);
				graph[v].Add(u);
			}
		}

		var a = new HashSet<string>();
		var b = new HashSet<string>();

		foreach (var (node, _) in graph)
		{
			var dst = Random.Shared.Next(2) == 0 ? a : b;
			dst.Add(node);
		}

		var cuts = 0;

		foreach (var node in a)
		{
			cuts += graph[node].Count(b.Contains);
		}

		while (cuts > 3)
		{
			var src = Random.Shared.Next(a.Count + b.Count) < a.Count ? a : b;
			var dst = src == a ? b : a;

			if (src.Count == 1)
			{
				(src, dst) = (dst, src);
			}

			var diff = 0;
			var move = "";

			foreach (var node in src)
			{
				var d = graph[node].Count - 2 * graph[node].Count(src.Contains);

				if (d > diff)
				{
					move = node;
					diff = d;
				}
			}

			if (move is "")
			{
				move = src.ElementAt(Random.Shared.Next(src.Count));
				diff = graph[move].Count - 2 * graph[move].Count(src.Contains);
			}

			dst.Add(move);
			src.Remove(move);
			cuts -= diff;
		}

		return a.Count * b.Count;
	}

	public string Part2()
	{
		return "get 49 stars";
	}
}
