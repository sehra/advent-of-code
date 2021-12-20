namespace AdventOfCode.Year2021;

public class Day20
{
	private readonly string[] _input;

	public Day20(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Solve(2);
	}

	public int Part2()
	{
		return Solve(50);
	}

	private int Solve(int ticks)
	{
		var (alg, img) = Parse();
		var inv = alg[0] is '#' && alg[^1] is '.';

		for (int i = 0; i < ticks; i++)
		{
			var res = new HashSet<(int R, int C)>();
			var def = 0;

			if (inv)
			{
				def = (i % 2 is 0) ? 0 : 1;
			}

			var rmin = img.Min(p => p.R);
			var rmax = img.Max(p => p.R);
			var cmin = img.Min(p => p.C);
			var cmax = img.Max(p => p.C);

			for (int r = rmin - 1; r <= rmax + 1; r++)
			{
				for (int c = cmin - 1; c <= cmax + 1; c++)
				{
					var idx =
						Get(r - 1, c - 1) << 8 |
						Get(r - 1, c) << 7 |
						Get(r - 1, c + 1) << 6 |
						Get(r, c - 1) << 5 |
						Get(r, c) << 4 |
						Get(r, c + 1) << 3 |
						Get(r + 1, c - 1) << 2 |
						Get(r + 1, c) << 1 |
						Get(r + 1, c + 1) << 0;

					if (alg[idx] is '#')
					{
						res.Add((r, c));
					}
				}
			}

			img = res;

			int Get(int r, int c)
			{
				if (rmin <= r && r <= rmax && cmin <= c && c <= cmax)
				{
					return img.Contains((r, c)) ? 1 : 0;
				}

				return def;
			}
		}

		return img.Count;
	}

	private (string Alg, HashSet<(int R, int C)> Img) Parse()
	{
		var alg = _input[0];
		var img = new HashSet<(int R, int C)>();

		for (int i = 1, r = 0; i < _input.Length; i++, r++)
		{
			for (int c = 0; c < _input[i].Length; c++)
			{
				if (_input[i][c] is '#')
				{
					img.Add((r, c));
				}

			}
		}

		return (alg, img);
	}
}
