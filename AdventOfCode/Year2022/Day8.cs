namespace AdventOfCode.Year2022;

public class Day8
{
	private readonly string[] _input;

	public Day8(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var map = Parse();
		var xlen = map.GetLength(0);
		var ylen = map.GetLength(1);
		var visible = new bool[xlen, ylen];

		for (int x = 0; x < xlen; x++)
		{
			visible[x, 0] = true;
			visible[x, ylen - 1] = true;
		}

		for (int y = 0; y < ylen; y++)
		{
			visible[0, y] = true;
			visible[ylen - 1, y] = true;
		}

		// top
		for (int x = 1; x < xlen - 1; x++)
		{
			for (int y = 1; y < ylen - 1; y++)
			{
				var z = map[x, y];
				var ok = true;

				for (int yy = 0; yy < y; yy++)
				{
					if (map[x, yy] >= z)
					{
						ok = false;
						break;
					}
				}

				if (ok)
				{
					visible[x, y] = true;
				}
			}
		}

		// left
		for (int x = 1; x < xlen - 1; x++)
		{
			for (int y = 1; y < ylen - 1; y++)
			{
				var z = map[x, y];
				var ok = true;

				for (int xx = 0; xx < x; xx++)
				{
					if (map[xx, y] >= z)
					{
						ok = false;
						break;
					}
				}

				if (ok)
				{
					visible[x, y] = true;
				}
			}
		}

		// bottom
		for (int x = 1; x < xlen - 1; x++)
		{
			for (int y = 1; y < ylen - 1; y++)
			{
				var z = map[x, y];
				var ok = true;

				for (int yy = y + 1; yy < ylen; yy++)
				{
					if (map[x, yy] >= z)
					{
						ok = false;
						break;
					}
				}

				if (ok)
				{
					visible[x, y] = true;
				}
			}
		}

		// right
		for (int x = 1; x < xlen - 1; x++)
		{
			for (int y = 1; y < ylen - 1; y++)
			{
				var z = map[x, y];
				var ok = true;

				for (int xx = x + 1; xx < xlen; xx++)
				{
					if (map[xx, y] >= z)
					{
						ok = false;
						break;
					}
				}

				if (ok)
				{
					visible[x, y] = true;
				}
			}
		}

		return visible.AsEnumerable().Count(x => x.Value);
	}

	public int Part2()
	{
		var map = Parse();
		var xlen = map.GetLength(0);
		var ylen = map.GetLength(1);
		var score = new int[xlen, ylen];

		for (int x = 1; x < xlen - 1; x++)
		{
			for (int y = 1; y < ylen - 1; y++)
			{
				var z = map[x, y];
				var (l, r, u, d) = (0, 0, 0, 0);

				// left
				for (int xx = x - 1; xx >= 0; xx--)
				{
					l++;

					if (map[xx, y] >= z)
					{
						break;
					}
				}

				// right
				for (int xx = x + 1; xx < xlen; xx++)
				{
					r++;

					if (map[xx, y] >= z)
					{
						break;
					}
				}

				// up
				for (int yy = y - 1; yy >= 0; yy--)
				{
					u++;

					if (map[x, yy] >= z)
					{
						break;
					}
				}

				// down
				for (int yy = y + 1; yy < ylen; yy++)
				{
					d++;

					if (map[x, yy] >= z)
					{
						break;
					}
				}

				score[x, y] = l * r * u * d;
			}
		}

		return score.AsEnumerable().Max(x => x.Value);
	}

	private int[,] Parse()
	{
		var map = new int[_input[0].Length, _input.Length];

		for (int x = 0; x < _input[0].Length; x++)
		{
			for (int y = 0; y < _input.Length; y++)
			{
				map[x, y] = _input[y][x] - '0';
			}
		}

		return map;
	}
}
