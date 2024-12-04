namespace AdventOfCode.Year2024;

public class Day4(string[] input)
{
	public int Part1()
	{
		ReadOnlySpan<(int, int)> deltas = [
			(-1, -1), (-1, 0), (-1, 1),
			(0, -1), (0, 1),
			(1, -1), (1, 0), (1, 1),
		];
		var count = 0;

		for (int r = 0; r < input.Length; r++)
		{
			for (int c = 0; c < input[r].Length; c++)
			{
				if (input[r][c] is not 'X')
				{
					continue;
				}

				foreach (var (dr, dc) in deltas)
				{
					var rl = r + dr * 3;
					var cl = c + dc * 3;

					if (0 <= rl && rl < input.Length &&
						0 <= cl && cl < input[r].Length &&
						input[r + dr * 1][c + dc * 1] is 'M' &&
						input[r + dr * 2][c + dc * 2] is 'A' &&
						input[r + dr * 3][c + dc * 3] is 'S')
					{
						count++;
					}
				}
			}
		}

		return count;
	}

	public int Part2()
	{
		var count = 0;

		for (int r = 1; r < input.Length - 1; r++)
		{
			for (int c = 1; c < input[r].Length - 1; c++)
			{
				if (input[r][c] is not 'A')
				{
					continue;
				}

				var ul = input[r - 1][c - 1];
				var ur = input[r - 1][c + 1];
				var dr = input[r + 1][c + 1];
				var dl = input[r + 1][c - 1];

				count += (ul, ur, dr, dl) switch
				{
					('M', 'M', 'S', 'S') => 1,
					('S', 'M', 'M', 'S') => 1,
					('S', 'S', 'M', 'M') => 1,
					('M', 'S', 'S', 'M') => 1,
					_ => 0,
				};
			}
		}

		return count;
	}
}
