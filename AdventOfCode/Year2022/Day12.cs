namespace AdventOfCode.Year2022;

public class Day12
{
	private readonly string[] _input;

	public Day12(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var (map, src, dst) = Parse();

		return Solve(map, new[] { src }, dst);
	}

	public int Part2()
	{
		var (map, _, dst) = Parse();
		var srcs = map.Where(x => x.Value is 'a').Select(x => x.Key);

		return Solve(map, srcs, dst);
	}

	private static int Solve(Dictionary<Point, int> map, IEnumerable<Point> srcs, Point dst)
	{
		var next = new Queue<(Point pos, int dist)>(srcs.Select(x => (x, 0)));
		var done = new HashSet<Point>();

		while (next.TryDequeue(out var work))
		{
			if (!done.Add(work.pos))
			{
				continue;
			}

			if (work.pos == dst)
			{
				return work.dist;
			}

			foreach (var dir in "UDLR")
			{
				var pos = work.pos.Step(dir);

				if (map.ContainsKey(pos))
				{
					if (map[pos] <= map[work.pos] + 1)
					{
						next.Enqueue((pos, work.dist + 1));
					}
				}
			}
		}

		throw new Exception("not found");
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

	private (Dictionary<Point, int> map, Point src, Point dst) Parse()
	{
		var map = new Dictionary<Point, int>();
		var src = default(Point);
		var dst = default(Point);

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				var c = _input[y][x];

				if (c is 'S')
				{
					src = new(x, y);
					c = 'a';
				}
				else if (c is 'E')
				{
					dst = new(x, y);
					c = 'z';
				}

				map[new(x, y)] = c;
			}
		}

		return (map, src, dst);
	}
}
