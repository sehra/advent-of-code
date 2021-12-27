namespace AdventOfCode.Year2021;

public class Day25
{
	private readonly string[] _input;

	public Day25(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var ocean = new char[_input.Length, _input[0].Length];

		for (int r = 0; r < _input.Length; r++)
		{
			for (int c = 0; c < _input[r].Length; c++)
			{
				ocean[r, c] = _input[r][c];
			}
		}

		for (int step = 1; ; step++)
		{
			var east = new List<(int Row, int Col)>();

			for (int r = 0; r < ocean.GetLength(0); r++)
			{
				for (int c = 0; c < ocean.GetLength(1); c++)
				{
					if (ocean[r, c] is '>' && ocean[r, NextCol(c)] is '.')
					{
						east.Add((r, c));
					}
				}
			}

			foreach (var (r, c) in east)
			{
				ocean[r, c] = '.';
				ocean[r, NextCol(c)] = '>';
			}

			var south = new List<(int Row, int Col)>();

			for (int r = 0; r < ocean.GetLength(0); r++)
			{
				for (int c = 0; c < ocean.GetLength(1); c++)
				{
					if (ocean[r, c] is 'v' && ocean[NextRow(r), c] is '.')
					{
						south.Add((r, c));
					}
				}
			}

			foreach (var (r, c) in south)
			{
				ocean[r, c] = '.';
				ocean[NextRow(r), c] = 'v';
			}

			if (east.Count is 0 && south.Count is 0)
			{
				return step;
			}
		}

		int NextCol(int col) => (col + 1) % _input[0].Length;
		int NextRow(int row) => (row + 1) % _input.Length;
	}

	public string Part2()
	{
		return "get 49 stars";
	}
}
