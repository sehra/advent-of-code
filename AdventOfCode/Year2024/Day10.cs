namespace AdventOfCode.Year2024;

public class Day10(string[] input)
{
	public int Part1() => Solve([]);

	public int Part2() => Solve(null);

	private int Solve(HashSet<(int, int)> v)
	{
		var score = 0;

		for (int r = 0; r < input.Length; r++)
		{
			for (int c = 0; c < input[r].Length; c++)
			{
				if (input[r][c] is '0')
				{
					v?.Clear();
					score += Walk(r, c, v);
				}
			}
		}

		return score;

		int Walk(int r, int c, HashSet<(int, int)> v, int h = '0')
		{
			if (0 <= r && r < input.Length &&
				0 <= c && c < input[r].Length)
			{
				if (input[r][c] != h || !(v?.Add((r, c)) ?? true))
				{
					return 0;
				}

				if (h is '9')
				{
					return 1;
				}

				return
					Walk(r - 1, c, v, h + 1) +
					Walk(r + 1, c, v, h + 1) +
					Walk(r, c - 1, v, h + 1) +
					Walk(r, c + 1, v, h + 1);
			}

			return 0;
		}
	}
}
