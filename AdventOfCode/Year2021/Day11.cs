namespace AdventOfCode.Year2021;

public class Day11
{
	private readonly string[] _input;

	public Day11(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var state = Parse();
		var count = 0;

		for (int step = 0; step < 100; step++)
		{
			count += Step(state);
		}

		return count;
	}

	public int Part2()
	{
		var state = Parse();

		for (int step = 1; ; step++)
		{
			if (Step(state) is 100)
			{
				return step;
			}
		}
	}

	private static int Step(int[,] state)
	{
		var count = 0;

		for (int r = 0; r < 10; r++)
		{
			for (int c = 0; c < 10; c++)
			{
				if (++state[r, c] is 10)
				{
					count += Flash(r, c);
				}
			}
		}

		for (int r = 0; r < 10; r++)
		{
			for (int c = 0; c < 10; c++)
			{
				if (state[r, c] > 9)
				{
					state[r, c] = 0;
				}
			}
		}

		return count;

		int Flash(int or, int oc)
		{
			var count = 1;

			foreach (var (dr, dc) in new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) })
			{
				var r = or + dr;
				var c = oc + dc;

				if (r is >= 0 and < 10 && c is >= 0 and < 10)
				{
					if (++state[r, c] is 10)
					{
						count += Flash(r, c);
					}
				}
			}

			return count;
		}
	}

	private int[,] Parse()
	{
		var state = new int[_input.Length, _input[0].Length];

		for (int r = 0; r < _input.Length; r++)
		{
			for (int c = 0; c < _input[r].Length; c++)
			{
				state[r, c] = _input[r][c] - '0';
			}
		}

		return state;
	}
}
