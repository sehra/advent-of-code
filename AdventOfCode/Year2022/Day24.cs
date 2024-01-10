namespace AdventOfCode.Year2022;

public class Day24(string[] input)
{
	public int Part1()
	{
		var (grid, size, src, dst) = Parse();

		return Walk(grid, size, new(src, 0), dst);
	}

	public int Part2()
	{
		var (grid, size, src, dst) = Parse();
		var time = 0;

		time = Walk(grid, size, new(src, time), dst);
		time = Walk(grid, size, new(dst, time), src);
		time = Walk(grid, size, new(src, time), dst);

		return time;
	}

	private static int Walk(Dictionary<Point, char> grid, Point size, State init, Point dst)
	{
		var seen = new HashSet<State>() { init };
		var work = new PriorityQueue<State, int>();
		work.Enqueue(init, 0);

		while (work.TryDequeue(out var state, out _))
		{
			var (curr, time) = state;

			if (curr == dst)
			{
				return time;
			}

			time += 1;

			foreach (var next in "UDLRS".Select(curr.Step))
			{
				if (!grid.ContainsKey(next))
				{
					continue;
				}

				if (0 < next.X && next.X < (size.X - 1) &&
					0 < next.Y && next.Y < (size.Y - 1))
				{
					var u = MathFunc.Mod(next.Y + time - 1, size.Y - 2) + 1;
					var d = MathFunc.Mod(next.Y - time - 1, size.Y - 2) + 1;
					var l = MathFunc.Mod(next.X + time - 1, size.X - 2) + 1;
					var r = MathFunc.Mod(next.X - time - 1, size.X - 2) + 1;

					if (grid[new(next.X, u)] is '^' ||
						grid[new(next.X, d)] is 'v' ||
						grid[new(l, next.Y)] is '<' ||
						grid[new(r, next.Y)] is '>')
					{
						continue;
					}
				}

				if (seen.Add(new(next, time)))
				{
					work.Enqueue(new(next, time), time + TaxiDist(next, dst));
				}
			}
		}

		throw new Exception("not found");

		static int TaxiDist(Point a, Point b) =>
			Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.X);
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => new(X, Y - 1),
			'D' => new(X, Y + 1),
			'L' => new(X - 1, Y),
			'R' => new(X + 1, Y),
			'S' => this,
			_ => throw new Exception("dir?"),
		};
	}

	private readonly record struct State(Point Pos, int Time);

	private (Dictionary<Point, char> Grid, Point Size, Point Src, Point Dst) Parse()
	{
		var grid = new Dictionary<Point, char>();
		var size = new Point(input[0].Length, input.Length);
		var src = new Point(input[0].IndexOf('.'), 0);
		var dst = new Point(input[^1].IndexOf('.'), input.Length - 1);

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c != '#')
				{
					grid.Add(new(x, y), c);
				}
			}
		}

		return (grid, size, src, dst);
	}
}
