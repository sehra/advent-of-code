namespace AdventOfCode.Year2017;

[SkipInputTrim]
public class Day19(string input)
{
	public string Part1() => Solve().Letters;

	public int Part2() => Solve().Steps;

	private (string Letters, int Steps) Solve()
	{
		var grid = Parse();
		var pos = new Point(0, Array.IndexOf(grid[0], '|'));
		var dir = 'D';

		var letters = new List<char>();
		var steps = 0;

		while (true)
		{
			var c = grid[pos.Row][pos.Col];

			if (Char.IsLetter(c))
			{
				letters.Add(c);
			}
			else if (c is '+')
			{
				if (dir is 'U' or 'D')
				{
					if (IsPath(pos.Step('L')))
					{
						dir = 'L';
					}
					else if (IsPath(pos.Step('R')))
					{
						dir = 'R';
					}
				}
				else if (dir is 'L' or 'R')
				{
					if (IsPath(pos.Step('U')))
					{
						dir = 'U';
					}
					else if (IsPath(pos.Step('D')))
					{
						dir = 'D';
					}
				}
			}
			else if (c is ' ')
			{
				break;
			}

			pos = pos.Step(dir);
			steps++;
		}

		return (new(letters.ToArray()), steps);

		bool IsPath(Point p) => grid[p.Row][p.Col] != ' ';
	}

	private readonly record struct Point(int Row, int Col)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => new(Row - 1, Col),
			'D' => new(Row + 1, Col),
			'L' => new(Row, Col - 1),
			'R' => new(Row, Col + 1),
			_ => throw new Exception("dir?"),
		};
	}

	private char[][] Parse() => input
		.ToLines(StringSplitOptions.RemoveEmptyEntries)
		.Select(line => line.ToCharArray())
		.ToArray();
}
