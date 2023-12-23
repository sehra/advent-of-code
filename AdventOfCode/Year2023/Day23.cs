namespace AdventOfCode.Year2023;

public class Day23(string[] input)
{
	public int Part1()
	{
		var (map, end) = Parse();

		return Count(new(0, 1), [new(0, 1)]);

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

			var dist = -1;

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
		throw new NotImplementedException();
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

	private (Dictionary<Point, char> Map, Point End) Parse()
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

		return (map, new(input.Length - 1, input[^1].Length - 2));
	}
}
