namespace AdventOfCode.Year2016;

public class Day1(string input)
{
	public int Part1()
	{
		var pos = Parse()
			.Aggregate(new Pos(0, 0, 'N'), (pos, insn) => pos.Turn(insn.Turn).Step(insn.Steps));

		return Math.Abs(pos.X) + Math.Abs(pos.Y);
	}

	public int Part2()
	{
		var pos = new Pos(0, 0, 'N');
		var seen = new HashSet<(int, int)>();

		foreach (var (turn, steps) in Parse())
		{
			pos = pos.Turn(turn);

			for (var i = 0; i < steps; i++)
			{
				pos = pos.Step();

				if (!seen.Add((pos.X, pos.Y)))
				{
					return Math.Abs(pos.X) + Math.Abs(pos.Y);
				}
			}
		}

		throw new Exception("not found");
	}

	private readonly record struct Pos(int X, int Y, char Dir)
	{
		public Pos Turn(char turn) => (Dir, turn) switch
		{
			('N', 'L') => this with { Dir = 'W' },
			('N', 'R') => this with { Dir = 'E' },
			('S', 'L') => this with { Dir = 'E' },
			('S', 'R') => this with { Dir = 'W' },
			('E', 'L') => this with { Dir = 'N' },
			('E', 'R') => this with { Dir = 'S' },
			('W', 'L') => this with { Dir = 'S' },
			('W', 'R') => this with { Dir = 'N' },
			_ => throw new Exception("turn?"),
		};

		public Pos Step(int steps = 1) => Dir switch
		{
			'N' => this with { X = X + steps },
			'S' => this with { X = X - steps },
			'E' => this with { Y = Y + steps },
			'W' => this with { Y = Y - steps },
			_ => throw new Exception("dir?"),
		};
	}

	private IEnumerable<(char Turn, int Steps)> Parse() => input
		.Split(',', StringSplitOptions.TrimEntries)
		.Select(line => (line[0], line[1..].ToInt32()));
}
