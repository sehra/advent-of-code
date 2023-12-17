namespace AdventOfCode.Year2023;

public class Day17(string[] input)
{
	public int Part1() => Solve(0, 3);

	public int Part2() => Solve(4, 10);

	private int Solve(int min, int max)
	{
		var goal = (input.Length - 1, input[^1].Length - 1);
		var seen = new HashSet<(Point, int)>();
		var work = new PriorityQueue<(Point Point, int Steps), int>();
		work.Enqueue((new(0, 0, 'R'), 0), 0);
		work.Enqueue((new(0, 0, 'D'), 0), 0);

		while (work.TryDequeue(out var state, out var loss))
		{
			var (curr, steps) = state;

			if ((curr.Row, curr.Col) == goal && steps >= min)
			{
				return loss;
			}

			if (!seen.Add((curr, steps)))
			{
				continue;
			}

			foreach (var dir in "SLR")
			{
				if (dir is 'S' && steps >= max)
				{
					continue;
				}

				if (min > 0 && dir is 'L' or 'R' && steps < min)
				{
					continue;
				}

				var next = curr.Turn(dir).Step();

				if (!InBounds(next))
				{
					continue;
				}

				work.Enqueue((next, dir is 'S' ? steps + 1 : 1), loss + Loss(next));
			}
		}

		throw new Exception("not found");

		bool InBounds(Point p) =>
			0 <= p.Row && p.Row < input.Length &&
			0 <= p.Col && p.Col < input[p.Row].Length;

		int Loss(Point p) => input[p.Row][p.Col] - '0';
	}

	private readonly record struct Point(int Row, int Col, char Dir)
	{
		public Point Step() => Dir switch
		{
			'U' => this with { Row = Row - 1 },
			'D' => this with { Row = Row + 1 },
			'L' => this with { Col = Col - 1 },
			'R' => this with { Col = Col + 1 },
			_ => throw new Exception("dir?"),
		};

		public Point Turn(char dir) => (dir, Dir) switch
		{
			('S', _) => this,
			('L', 'U') => this with { Dir = 'L' },
			('L', 'D') => this with { Dir = 'R' },
			('L', 'L') => this with { Dir = 'D' },
			('L', 'R') => this with { Dir = 'U' },
			('R', 'U') => this with { Dir = 'R' },
			('R', 'D') => this with { Dir = 'L' },
			('R', 'L') => this with { Dir = 'U' },
			('R', 'R') => this with { Dir = 'D' },
			_ => throw new Exception("dir?"),
		};
	}
}
