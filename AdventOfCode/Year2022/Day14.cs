namespace AdventOfCode.Year2022;

public class Day14
{
	private readonly string[] _input;

	public Day14(string[] input)
	{
		_input = input;
	}

	public int Part1() => Solve(1);

	public int Part2() => Solve(2);

	public int Solve(int part)
	{
		var cave = Parse();
		var ymax = cave.Keys.Max(x => x.Y) + 2;
		var root = new Point(500, 0);

		while (true)
		{
			if (cave.ContainsKey(root))
			{
				break;
			}

			var sand = root;
			var done = false;

			while (true)
			{
				if (part is 1 && sand.Y == ymax)
				{
					done = true;
					break;
				}

				if (part is 2 && sand.Y + 1 == ymax)
				{
					cave[sand] = 'o';
					break;
				}

				var s = sand.Fall('S');
				var l = sand.Fall('L');
				var r = sand.Fall('R');

				if (!cave.ContainsKey(s))
				{
					sand = s;
				}
				else if (!cave.ContainsKey(l))
				{
					sand = l;
				}
				else if (!cave.ContainsKey(r))
				{
					sand = r;
				}
				else
				{
					cave[sand] = 'o';
					break;
				}
			}

			if (done)
			{
				break;
			}
		}

		return cave.Values.Count(x => x is 'o');
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Fall(char dir) => dir switch
		{
			'S' => new(X, Y + 1),
			'L' => new(X - 1, Y + 1),
			'R' => new(X + 1, Y + 1),
			_ => throw new Exception("dir?"),
		};
	}

	private Dictionary<Point, char> Parse()
	{
		var cave = new Dictionary<Point, char>();

		foreach (var line in _input)
		{
			var rocks =
				from coords in line.Split(" -> ")
				let coord = coords.Split(",")
				let x = coord.ElementAt(0).ToInt32()
				let y = coord.ElementAt(1).ToInt32()
				select new Point(x, y);

			foreach (var rock in rocks.Window(2))
			{
				if (rock[0].X == rock[1].X)
				{
					var ymin = Math.Min(rock[0].Y, rock[1].Y);
					var ymax = Math.Max(rock[0].Y, rock[1].Y);

					for (int y = ymin; y <= ymax; y++)
					{
						cave[new(rock[0].X, y)] = '#';
					}
				}
				else
				{
					var xmin = Math.Min(rock[0].X, rock[1].X);
					var xmax = Math.Max(rock[0].X, rock[1].X);

					for (int x = xmin; x <= xmax; x++)
					{
						cave[new(x, rock[0].Y)] = '#';
					}
				}
			}
		}

		return cave;
	}
}
