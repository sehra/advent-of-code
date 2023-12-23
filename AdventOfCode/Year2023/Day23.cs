namespace AdventOfCode.Year2023;

public class Day23(string[] input)
{
	public int Part1()
	{
		var (map, beg, end) = Parse();

		return Count(beg, [beg]);

		int Count(Point pos, HashSet<Point> path)
		{
			if (pos == end)
			{
				return path.Count - 1;
			}

			Point[] moves = map[pos] switch
			{
				'.' => [.. "UDLR".Select(pos.Step)],
				'^' => [pos.Step('U')],
				'v' => [pos.Step('D')],
				'<' => [pos.Step('L')],
				'>' => [pos.Step('R')],
				_ => throw new Exception("type?"),
			};

			var dist = 0;

			foreach (var next in moves)
			{
				if (map.ContainsKey(next) && path.Add(next))
				{
					dist = Math.Max(dist, Count(next, path));
					path.Remove(next);
				}
			}

			return dist;
		}
	}

	public int Part2()
	{
		var (map, beg, end) = Parse();
		var graph = new Dictionary<Point, Dictionary<Point, int>>();

		foreach (var key in map.Keys)
		{
			graph.Add(key, []);

			foreach (var pos in "UDLR".Select(key.Step))
			{
				if (map.ContainsKey(pos))
				{
					graph[key].Add(pos, 1);
				}
			}
		}

		foreach (var key in map.Keys)
		{
			if (!graph.ContainsKey(key))
			{
				continue;
			}

			var nbors = graph[key];

			if (nbors.Count is 0 || (nbors.Count is 1 && !(key == beg || key == end)))
			{
				graph.Remove(key);

				foreach (var (nbor, _) in nbors)
				{
					graph[nbor].Remove(key);
				}
			}
			else if (nbors.Count is 2)
			{
				var dist = nbors.Values.Sum();
				var fst = nbors.Keys.ElementAt(0);
				var snd = nbors.Keys.ElementAt(1);
				graph[fst].Add(snd, dist);
				graph[snd].Add(fst, dist);
				graph.Remove(key);

				foreach (var (nbor, _) in nbors)
				{
					graph[nbor].Remove(key);
				}
			}
		}

		return Count(beg, new() { [beg] = 0 });

		int Count(Point pos, Dictionary<Point, int> path)
		{
			if (pos == end)
			{
				return path.Values.Sum();
			}

			var dist = 0;

			foreach (var nbor in graph[pos])
			{
				if (path.TryAdd(nbor.Key, nbor.Value))
				{
					dist = Math.Max(dist, Count(nbor.Key, path));
					path.Remove(nbor.Key);
				}
			}

			return dist;
		}
	}

	private readonly record struct Point(int R, int C)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => this with { R = R - 1 },
			'D' => this with { R = R + 1 },
			'L' => this with { C = C - 1 },
			'R' => this with { C = C + 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private (Dictionary<Point, char> Map, Point Beg, Point End) Parse()
	{
		var map = new Dictionary<Point, char>();

		for (int row = 0; row < input.Length; row++)
		{
			for (int col = 0; col < input[row].Length; col++)
			{
				var c = input[row][col];

				if (c is not '#')
				{
					map.Add(new(row, col), c);
				}
			}
		}

		return (map, new(0, 1), new(input.Length - 1, input[^1].Length - 2));
	}
}
