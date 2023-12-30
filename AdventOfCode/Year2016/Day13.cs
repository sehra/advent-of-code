namespace AdventOfCode.Year2016;

public class Day13(string input)
{
	public int Part1(int x = 31, int y = 39)
	{
		var fnum = input.ToInt32();
		var goal = new Point(x, y);

		var seen = new HashSet<Point>();
		var work = new PriorityQueue<Point, int>();
		work.Enqueue(new(1, 1), 0);

		while (work.TryDequeue(out var curr, out var steps))
		{
			if (!seen.Add(curr))
			{
				continue;
			}

			if (curr == goal)
			{
				return steps;
			}

			foreach (var dir in "UDLR")
			{
				var next = curr.Step(dir);

				if (next.X >= 0 && next.Y >= 0 && IsOpen(next, fnum))
				{
					work.Enqueue(next, steps + 1);
				}
			}
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var fnum = input.ToInt32();

		var seen = new HashSet<Point>();
		var work = new PriorityQueue<Point, int>();
		work.Enqueue(new(1, 1), 0);

		while (work.TryDequeue(out var curr, out var steps))
		{
			if (steps > 50 || !seen.Add(curr))
			{
				continue;
			}

			foreach (var dir in "UDLR")
			{
				var next = curr.Step(dir);

				if (next.X >= 0 && next.Y >= 0 && IsOpen(next, fnum))
				{
					work.Enqueue(next, steps + 1);
				}
			}
		}

		return seen.Count;
	}

	private static bool IsOpen(Point p, int fnum)
	{
		var test = p.X * p.X + 3 * p.X + 2 * p.X * p.Y + p.Y + p.Y * p.Y + fnum;
		return BitOperations.PopCount((uint)test) % 2 == 0;
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => this with { Y = Y - 1 },
			'D' => this with { Y = Y + 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("dir?"),
		};
	}
}
