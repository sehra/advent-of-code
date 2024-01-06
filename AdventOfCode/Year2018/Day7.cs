namespace AdventOfCode.Year2018;

using Edge = (char S, char T);

public class Day7(string[] input)
{
	public string Part1()
	{
		var edges = Parse();
		var nodes = edges
			.SelectMany(e => EnumerableEx.Return(e.S).Append(e.T))
			.Distinct().Order().ToList();

		var path = new List<char>();

		while (nodes.Count > 0)
		{
			var node = nodes.First(n => !edges.Any(e => e.T == n));
			nodes.Remove(node);
			edges.RemoveAll(e => e.S == node);
			path.Add(node);
		}

		return new([.. path]);
	}

	public int Part2(int workers = 5, int seconds = 60)
	{
		var edges = Parse();
		var nodes = edges
			.SelectMany(e => EnumerableEx.Return(e.S).Append(e.T))
			.Distinct().Order().ToList();

		var work = new List<(char Node, int Time)>();
		var time = 0;

		while (nodes.Count > 0 || work.Any(w => w.Time > time))
		{
			foreach (var (node, _) in work.Where(w => w.Time <= time))
			{
				edges.RemoveAll(e => e.S == node);
			}

			work.RemoveAll(w => w.Time <= time);

			foreach (var node in nodes.Where(n => !edges.Any(e => e.T == n)).ToArray())
			{
				if (work.Count < workers)
				{
					nodes.Remove(node);
					work.Add((node, time + node - 'A' + 1 + seconds));
				}
			}

			time++;
		}

		return time;
	}

	private List<Edge> Parse() => input
		.Select(line => line.Split())
		.Select(line => (line[1][0], line[7][0]))
		.ToList();
}
