namespace AdventOfCode.Year2023;

using Point = (int X, int Y);

public class Day21(string[] input)
{
	public long Part1(int steps = 64)
	{
		var (map, start, size) = Parse();

		return Count(map, start, size, steps);
	}

	public long Part2(int steps = 26_501_365)
	{
		// TODO: need an actual generic solution

		var (map, start, size) = Parse();

		if (size is 131)
		{
			var (n, d) = Math.DivRem(steps, size);
			var y0 = Count(map, start, size, d + size * 0);
			var y1 = Count(map, start, size, d + size * 1);
			var y2 = Count(map, start, size, d + size * 2);

			var a = (y2 + y0 - 2 * y1) / 2;
			var b = y1 - y0 - a;
			var c = y0;

			return a * n * n + b * n + c;
		}
		else
		{
			return Count(map, start, size, steps);
		}
	}

	private static long Count(HashSet<Point> map, Point start, int size, int steps)
	{
		var goal = new HashSet<Point>();
		var comp = steps % 2;

		var seen = new HashSet<Point>();
		var work = new PriorityQueue<Point, int>();
		work.Enqueue(start, 0);

		while (work.TryDequeue(out var curr, out var dist))
		{
			if (!seen.Add(curr))
			{
				continue;
			}

			if (dist % 2 == comp)
			{
				goal.Add(curr);
			}

			if (dist == steps)
			{
				continue;
			}

			foreach (var dir in "NSEW")
			{
				var next = Step(curr, dir);
				var x = MathFunc.Mod(next.X, size);
				var y = MathFunc.Mod(next.Y, size);

				if (map.Contains((x, y)))
				{
					work.Enqueue(next, dist + 1);
				}
			}
		}

		return goal.Count;

		static Point Step(Point p, char dir) => dir switch
		{
			'N' => p with { Y = p.Y - 1 },
			'S' => p with { Y = p.Y + 1 },
			'E' => p with { X = p.X + 1 },
			'W' => p with { X = p.X - 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private (HashSet<Point>, Point, int) Parse()
	{
		Debug.Assert(input.Length == input[0].Length);

		var map = new HashSet<Point>();
		var pos = (0, 0);

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c is '.')
				{
					map.Add((x, y));
				}
				else if (c is 'S')
				{
					map.Add(pos = (x, y));
				}
			}
		}

		return (map, pos, input.Length);
	}
}
