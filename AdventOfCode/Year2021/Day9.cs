namespace AdventOfCode.Year2021;

public class Day9
{
	private readonly string[] _input;

	public Day9(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var map = ParseMap();
		var low = FindLowPoints(map);

		return low.Sum(x => x.Value + 1);
	}

	public int Part2()
	{
		var map = ParseMap();
		var low = FindLowPoints(map);

		return low
			.Select(p => BasinSize(p.Point))
			.OrderByDescending(x => x)
			.Take(3)
			.Aggregate(1, (acc, n) => acc * n);

		int BasinSize(Point start)
		{
			var size = 0;
			var done = new HashSet<Point>();
			var next = new Queue<Point>();
			next.Enqueue(start);

			while (next.TryDequeue(out var point))
			{
				if (!done.Add(point))
				{
					continue;
				}

				if (map.TryGetValue(point, out var value) && value < 9)
				{
					size++;

					foreach (var direction in "UDLR")
					{
						next.Enqueue(point.Step(direction));
					}
				}
			}

			return size;
		}
	}

	private Dictionary<Point, int> ParseMap()
	{
		var result = new Dictionary<Point, int>();

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[0].Length; x++)
			{
				result.Add(new(x, y), _input[y][x] - '0');
			}
		}

		return result;
	}

	private static List<(Point Point, int Value)> FindLowPoints(Dictionary<Point, int> map)
	{
		var result = new List<(Point, int)>();

		foreach (var (point, value) in map)
		{
			if (IsLowest(point, value))
			{
				result.Add((point, value));
			}
		}

		return result;

		bool IsLowest(Point point, int value)
		{
			foreach (var direction in "UDLR")
			{
				if (map.TryGetValue(point.Step(direction), out var other) && other <= value)
				{
					return false;
				}
			}

			return true;
		}
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char direction) => direction switch
		{
			'U' => this with { Y = Y - 1 },
			'D' => this with { Y = Y + 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("dir?"),
		};
	}
}
