namespace AdventOfCode.Year2024;

public class Day12(string[] input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool part2)
	{
		var farm = Parse();
		var todo = farm.Keys.ToHashSet();
		var price = 0;

		while (todo.Count > 0)
		{
			var start = todo.First();
			var plot = Flood(start);
			price += plot.Count * Fence(plot, farm[start]);
			todo.ExceptWith(plot);
		}

		return price;

		HashSet<Point> Flood(Point start)
		{
			var type = farm[start];
			var plot = new HashSet<Point>();
			var work = new Queue<Point>();
			work.Enqueue(start);

			while (work.TryDequeue(out var pos))
			{
				if (!plot.Add(pos))
				{
					continue;
				}

				foreach (var nbor in "UDLR".Select(pos.Step))
				{
					if (farm.TryGetValue(nbor, out var c) && c == type)
					{
						work.Enqueue(nbor);
					}
				}
			}

			return plot;
		}

		int Fence(HashSet<Point> plot, char type)
		{
			var fence = new HashSet<(Point, char)>();

			foreach (var pos in plot)
			{
				foreach (var dir in "UDLR")
				{
					var nbor = pos.Step(dir);

					if (!farm.TryGetValue(nbor, out var c) || c != type)
					{
						fence.Add((pos, dir));
					}
				}
			}

			if (!part2)
			{
				return fence.Count;
			}

			var sides = 0;

			foreach (var (pos, dir) in fence)
			{
				var d = fence.Contains((pos.Step('D'), dir));
				var r = fence.Contains((pos.Step('R'), dir));

				if (!(d || r))
				{
					sides++;
				}
			}

			return sides;
		}
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

	private Dictionary<Point, char> Parse()
	{
		var map = new Dictionary<Point, char>();

		for (int r = 0; r < input.Length; r++)
		{
			for (int c = 0; c < input[r].Length; c++)
			{
				map[new(r, c)] = input[r][c];
			}
		}

		return map;
	}
}
