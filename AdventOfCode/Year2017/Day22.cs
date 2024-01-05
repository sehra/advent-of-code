namespace AdventOfCode.Year2017;

public class Day22(string[] input)
{
	public int Part1()
	{
		var (grid, pos) = Parse();
		var dir = 'U';
		var count = 0;

		for (int i = 0; i < 10_000; i++)
		{
			dir = Turn(dir, grid.Contains(pos) ? 'R' : 'L');

			if (grid.Contains(pos))
			{
				grid.Remove(pos);
			}
			else
			{
				grid.Add(pos);
				count++;
			}

			pos = pos.Step(dir);
		}

		return count;
	}

	public int Part2()
	{
		var (temp, pos) = Parse();
		var grid = temp.ToDictionary(p => p, _ => 'I');
		var dir = 'U';
		var count = 0;

		for (int i = 0; i < 10_000_000; i++)
		{
			if (!grid.TryGetValue(pos, out var state))
			{
				state = 'C';
			}

			dir = state switch
			{
				'C' => Turn(dir, 'L'),
				'W' => dir,
				'I' => Turn(dir, 'R'),
				'F' => Turn(dir, 'B'),
				_ => throw new Exception("state?"),
			};

			var next = Next(state);

			if (next is 'I')
			{
				count++;
			}

			grid[pos] = next;
			pos = pos.Step(dir);
		}

		return count;

		static char Next(char state) => state switch
		{
			'C' => 'W',
			'W' => 'I',
			'I' => 'F',
			'F' => 'C',
			_ => throw new Exception("state?"),
		};
	}

	private static char Turn(char dir, char turn) => (dir, turn) switch
	{
		('U', 'L') => 'L',
		('U', 'R') => 'R',
		('U', 'B') => 'D',
		('D', 'L') => 'R',
		('D', 'R') => 'L',
		('D', 'B') => 'U',
		('L', 'L') => 'D',
		('L', 'R') => 'U',
		('L', 'B') => 'R',
		('R', 'L') => 'U',
		('R', 'R') => 'D',
		('R', 'B') => 'L',
		_ => throw new Exception("dir? turn?"),
	};

	private readonly record struct Point(int R, int C)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => new(R - 1, C),
			'D' => new(R + 1, C),
			'L' => new(R, C - 1),
			'R' => new(R, C + 1),
			_ => throw new Exception("dir?"),
		};
	}

	private (HashSet<Point>, Point) Parse()
	{
		var grid = new HashSet<Point>();

		for (int r = 0; r < input.Length; r++)
		{
			for (int c = 0; c < input[r].Length; c++)
			{
				if (input[r][c] is '#')
				{
					grid.Add(new(r, c));
				}
			}
		}

		return (grid, new(input[0].Length / 2, input.Length / 2));
	}
}
