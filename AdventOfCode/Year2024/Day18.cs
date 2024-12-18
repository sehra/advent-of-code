namespace AdventOfCode.Year2024;

using Vec = Vec2<int>;

public class Day18(string[] input)
{
	public int Part1(int size = 70, int time = 1024)
	{
		return Walk([.. Parse().Take(time)], size).Value;
	}

	public string Part2(int size = 70)
	{
		var data = Parse();
		var lo = 0;
		var hi = data.Length - 1;

		while (lo <= hi)
		{
			var n = (lo + hi) / 2;

			if (Walk([.. data.Take(n)], size) is null)
			{
				hi = n - 1;
			}
			else
			{
				lo = n + 1;
			}
		}

		return $"{data[hi].X},{data[hi].Y}";
	}

	private static int? Walk(HashSet<Vec> grid, int size)
	{
		ReadOnlySpan<Vec> dirs = [(1, 0), (-1, 0), (0, 1), (0, -1)];
		var goal = (size, size);
		var seen = new HashSet<Vec>();
		var work = new PriorityQueue<Vec, int>();
		work.Enqueue(Vec.Zero, 0);

		while (work.TryDequeue(out var pos, out var steps))
		{
			if (pos == goal)
			{
				return steps;
			}

			if (!seen.Add(pos))
			{
				continue;
			}

			foreach (var dir in dirs)
			{
				var next = pos + dir;

				if (next.X < 0 || next.X > size || next.Y < 0 || next.Y > size)
				{
					continue;
				}

				if (grid.Contains(next))
				{
					continue;
				}

				work.Enqueue(next, steps + 1);
			}
		}

		return null;
	}

	private Vec[] Parse() => input
		.Select(line => line.Split(',').ToInt32())
		.Select(p => new Vec(p[0], p[1]))
		.ToArray();
}
