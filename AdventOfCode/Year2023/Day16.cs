namespace AdventOfCode.Year2023;

public class Day16(string[] input)
{
	public int Part1() => Solve(new(0, -1, 'R'));

	public int Part2()
	{
		var tests = new List<int>();
		var rows = input.Length;
		var cols = input[0].Length;

		for (int row = 0; row < rows; row++)
		{
			tests.Add(Solve(new(row, -1, 'R')));
			tests.Add(Solve(new(row, cols, 'L')));
		}

		for (int col = 0; col < cols; col++)
		{
			tests.Add(Solve(new(-1, col, 'D')));
			tests.Add(Solve(new(rows, col, 'U')));
		}

		return tests.Max();
	}

	private int Solve(Beam start)
	{
		var seen = new HashSet<Beam>();
		var work = new Queue<Beam>();
		work.Enqueue(start);

		while (work.TryDequeue(out var curr))
		{
			if (!seen.Add(curr))
			{
				continue;
			}

			var beam = curr.Step();

			if (!InBounds(beam))
			{
				continue;
			}

			var tile = input[beam.Row][beam.Col];

			if (tile is '|')
			{
				work.Enqueue(beam with { Dir = 'U' });
				work.Enqueue(beam with { Dir = 'D' });
			}
			else if (tile is '-')
			{
				work.Enqueue(beam with { Dir = 'L' });
				work.Enqueue(beam with { Dir = 'R' });
			}
			else if (tile is '/' or '\\')
			{
				work.Enqueue(beam.Reflect(tile));
			}
			else
			{
				work.Enqueue(beam);
			}
		}

		return seen.Distinct(beam => (beam.Row, beam.Col)).Count() - 1;

		bool InBounds(Beam beam) =>
			0 <= beam.Row && beam.Row < input.Length &&
			0 <= beam.Col && beam.Col < input[beam.Row].Length;
	}

	private readonly record struct Beam(int Row, int Col, char Dir)
	{
		public Beam Step() => Dir switch
		{
			'U' => this with { Row = Row - 1 },
			'D' => this with { Row = Row + 1 },
			'L' => this with { Col = Col - 1 },
			'R' => this with { Col = Col + 1 },
			_ => throw new Exception("dir?"),
		};

		public Beam Reflect(char mirror) => (Dir, mirror) switch
		{
			('U', '/') => this with { Dir = 'R' },
			('D', '/') => this with { Dir = 'L' },
			('L', '/') => this with { Dir = 'D' },
			('R', '/') => this with { Dir = 'U' },
			('U', '\\') => this with { Dir = 'L' },
			('D', '\\') => this with { Dir = 'R' },
			('L', '\\') => this with { Dir = 'U' },
			('R', '\\') => this with { Dir = 'D' },
			_ => throw new Exception("mirror?"),
		};
	}
}
