using System.Collections.Frozen;

namespace AdventOfCode.Year2024;

using Map = FrozenSet<Vec2<int>>;
using Vec = Vec2<int>;

public class Day20(string[] input)
{
	public int Part1(int save = 100) => Solve(2, save);

	public int Part2(int save = 100) => Solve(20, save);

	private int Solve(int cheat, int save)
	{
		ReadOnlySpan<Vec> dirs = [(-1, 0), (1, 0), (0, -1), (0, 1)];

		var (map, beg, end) = Parse();
		var seen = new Dictionary<Vec, int>();
		var work = new Queue<(Vec, int)>();
		work.Enqueue((beg, 0));

		while (work.TryDequeue(out var state))
		{
			var (pos, dist) = state;

			if (!seen.TryAdd(pos, dist))
			{
				continue;
			}

			if (pos == end)
			{
				continue;
			}

			foreach (var dir in dirs)
			{
				var nbor = pos + dir;

				if (map.Contains(nbor))
				{
					work.Enqueue((nbor, dist + 1));
				}
			}
		}

		var dists = seen.ToArray();
		var count = 0;

		for (int i = 0; i < dists.Length; i++)
		{
			var (p1, t1) = dists[i];

			for (int j = i + 1; j < dists.Length; j++)
			{
				var (p2, t2) = dists[j];
				var dist = Math.Abs(p1.X - p2.X) + Math.Abs(p1.Y - p2.Y);

				if (dist <= cheat && Math.Abs(t1 - t2) - save >= dist)
				{
					count++;
				}
			}
		}

		return count;
	}

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
