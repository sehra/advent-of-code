using System.Collections.Frozen;

namespace AdventOfCode.Year2024;

using Map = FrozenSet<Vec2<int>>;
using Vec = Vec2<int>;

public class Day16(string[] input)
{
	public int Part1()
	{
		var (map, beg, end) = Parse();

		var seen = new HashSet<(Vec, int)>();
		var work = new PriorityQueue<(Vec, int), int>();
		work.Enqueue((beg, 0), 0);

		while (work.TryDequeue(out var curr, out var cost))
		{
			var (pos, dir) = curr;

			if (pos == end)
			{
				return cost;
			}

			if (!seen.Add((pos, dir)))
			{
				continue;
			}

			if (map.Contains(pos + ToVec(dir)))
			{
				work.Enqueue((pos + ToVec(dir), dir), cost + 1);
			}

			work.Enqueue((pos, (dir + 1) % 4), cost + 1000);
			work.Enqueue((pos, (dir + 3) % 4), cost + 1000);
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var (map, beg, end) = Parse();

		var seen = new Dictionary<(Vec, int), int>();
		var work = new PriorityQueue<(Vec[], int), int>();
		work.Enqueue(([beg], 0), 0);

		var bestCost = int.MaxValue;
		var bestPath = new HashSet<Vec>();

		while (work.TryDequeue(out var curr, out var cost))
		{
			var (path, dir) = curr;
			var pos = path[^1];

			if (pos == end)
			{
				if (cost > bestCost)
				{
					return bestPath.Count;
				}

				bestCost = cost;
				bestPath.UnionWith(path);
			}

			if (seen.TryGetValue((pos, dir), out var seenCost) && seenCost < cost)
			{
				continue;
			}

			seen[(pos, dir)] = cost;

			if (map.Contains(pos + ToVec(dir)))
			{
				work.Enqueue(([.. path, pos + ToVec(dir)], dir), cost + 1);
			}

			work.Enqueue((path, (dir + 1) % 4), cost + 1000);
			work.Enqueue((path, (dir + 3) % 4), cost + 1000);
		}

		throw new Exception("not found");
	}

	private static Vec ToVec(int dir) => dir switch
	{
		0 => (1, 0),
		1 => (0, 1),
		2 => (-1, 0),
		3 => (0, -1),
		_ => throw new Exception("dir?"),
	};

	private (Map, Vec, Vec) Parse()
	{
		var map = new HashSet<Vec>();
		var beg = default(Vec);
		var end = default(Vec);

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c is not '#')
				{
					map.Add((x, y));

					if (c is 'S')
					{
						beg = (x, y);
					}
					else if (c is 'E')
					{
						end = (x, y);
					}
				}
			}
		}

		return (map.ToFrozenSet(), beg, end);
	}
}
