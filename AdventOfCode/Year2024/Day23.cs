namespace AdventOfCode.Year2024;

using Graph = Dictionary<string, HashSet<string>>;
using Nodes = HashSet<string>;

public class Day23(string[] input)
{
	public int Part1()
	{
		var graph = Parse();
		var groups =
			from a in graph.Keys
			where a.StartsWith('t')
			from b in graph.Keys
			where a != b && graph[a].Contains(b)
			from c in graph.Keys
			where a != c && b != c && graph[a].Contains(c) && graph[b].Contains(c)
			select Sorted(a, b, c);

		return groups.Distinct().Count();

		static (string, string, string) Sorted(string a, string b, string c)
		{
			var temp = new[] { a, b, c };
			Array.Sort(temp);

			return (temp[0], temp[1], temp[2]);
		}
	}

	public string Part2()
	{
		var graph = Parse();
		var clique = Cliques(graph).OrderByDescending(c => c.Count).First();

		return String.Join(',', clique.Order());

		static IEnumerable<Nodes> Cliques(Graph graph)
		{
			return BronKerbosch([], [.. graph.Keys], []);

			IEnumerable<Nodes> BronKerbosch(Nodes r, Nodes p, Nodes x)
			{
				if (p.Count == 0 && x.Count == 0)
				{
					yield return r;
				}
				else
				{
					foreach (var v in p.Except(graph[p.Concat(x).First()]))
					{
						Nodes ruv = [.. r, v];
						Nodes pin = [.. p.Intersect(graph[v])];
						Nodes xin = [.. x.Intersect(graph[v])];

						foreach (var c in BronKerbosch(ruv, pin, xin))
						{
							yield return c;
						}

						p.Remove(v);
						x.Add(v);
					}
				}
			}
		}
	}

	private Graph Parse()
	{
		var graph = new Graph();

		foreach (var line in input)
		{
			var split = line.Split('-');
			var l = split[0];
			var r = split[1];

			if (!graph.TryGetValue(l, out var ls))
			{
				graph[l] = ls = [];
			}

			if (!graph.TryGetValue(r, out var rs))
			{
				graph[r] = rs = [];
			}

			ls.Add(r);
			rs.Add(l);
		}

		return graph;
	}
}
