namespace AdventOfCode.Year2023;

public class Day10(string[] input)
{
	public int Part1()
	{
		var (map, pos) = Parse();
		var path = Walk(map, pos);

		return path.Count / 2;
	}

	public int Part2()
	{
		var (map, pos) = Parse();
		var path = Walk(map, pos);
		var area = 0;

		for (int y = 0; y < input.Length; y++)
		{
			var inside = false;

			for (int x = 0; x < input[y].Length; x++)
			{
				var p = new Point(x, y);

				if (path.Contains(p))
				{
					var n = map.Contains((p, p + 'N'));
					var s = map.Contains((p, p + 'S'));
					var e = map.Contains((p, p + 'E'));
					var w = map.Contains((p, p + 'W'));

					if (n && (s || e || w))
					{
						inside = !inside;
					}
				}
				else if (inside)
				{
					area++;
				}
			}
		}

		return area;
	}

	private static HashSet<Point> Walk(HashSet<(Point, Point)> map, Point pos)
	{
		var path = new HashSet<Point>();
		var work = new Queue<Point>();
		work.Enqueue(pos);

		while (work.TryDequeue(out var curr))
		{
			if (!path.Add(curr))
			{
				continue;
			}

			foreach (var dir in "NSEW")
			{
				var next = curr + dir;

				if (map.Contains((curr, next)))
				{
					work.Enqueue(next);
				}
			}
		}

		return path;
	}

	private readonly record struct Point(int X, int Y)
	{
		public static Point operator +(Point p, char dir) => dir switch
		{
			'N' => p with { Y = p.Y - 1 },
			'S' => p with { Y = p.Y + 1 },
			'E' => p with { X = p.X + 1 },
			'W' => p with { X = p.X - 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private (HashSet<(Point, Point)> Map, Point Pos) Parse()
	{
		var map = new HashSet<(Point A, Point B)>();
		var pos = default(Point);

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c is '.')
				{
					continue;
				}
				else if (c is 'S')
				{
					pos = new(x, y);
				}
				else
				{
					var p = new Point(x, y);
					var (a, b) = c switch
					{
						'|' => (p + 'N', p + 'S'),
						'-' => (p + 'E', p + 'W'),
						'L' => (p + 'N', p + 'E'),
						'J' => (p + 'N', p + 'W'),
						'7' => (p + 'S', p + 'W'),
						'F' => (p + 'S', p + 'E'),
						_ => throw new Exception("char?"),
					};
					map.Add((p, a));
					map.Add((p, b));
				}
			}
		}

		foreach (var (a, b) in map.Where(x => x.B == pos).ToArray())
		{
			map.Add((b, a));
		}

		return (map, pos);
	}
}
