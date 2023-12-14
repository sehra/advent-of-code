namespace AdventOfCode.Year2023;

public class Day14(string[] input)
{
	public int Part1()
	{
		var dish = Parse();

		for (int c = 0; c < dish[0].Length; c++)
		{
			var cont = true;

			while (cont)
			{
				cont = false;

				for (int r = 0; r < dish.Length - 1; r++)
				{
					if ((dish[r][c], dish[r + 1][c]) is ('.', 'O'))
					{
						dish[r][c] = 'O';
						dish[r + 1][c] = '.';
						cont = true;
					}
				}
			}
		}

		return Load(dish);
	}

	public int Part2()
	{
		const int n = 1_000_000_000;

		var dish = Parse();
		var cache = new Dictionary<string, int>();

		for (int i = 0; i < n; i++)
		{
			var key = dish.ToString((sb, r) => sb.Append(r));

			if (cache.TryGetValue(key, out var j))
			{
				i = n - ((n - i) % (i - j));
			}
			else
			{
				cache.Add(key, i);
			}

			// north
			for (int c = 0; c < dish[0].Length; c++)
			{
				var cont = true;

				while (cont)
				{
					cont = false;

					for (int r = 0; r < dish.Length - 1; r++)
					{
						if ((dish[r][c], dish[r + 1][c]) is ('.', 'O'))
						{
							dish[r][c] = 'O';
							dish[r + 1][c] = '.';
							cont = true;
						}
					}
				}
			}

			// west
			for (int r = 0; r < dish.Length; r++)
			{
				var cont = true;

				while (cont)
				{
					cont = false;

					for (int c = 0; c < dish[0].Length - 1; c++)
					{
						if ((dish[r][c], dish[r][c + 1]) is ('.', 'O'))
						{
							dish[r][c] = 'O';
							dish[r][c + 1] = '.';
							cont = true;
						}
					}
				}
			}

			// south
			for (int c = 0; c < dish[0].Length; c++)
			{
				var cont = true;

				while (cont)
				{
					cont = false;

					for (int r = 0; r < dish.Length - 1; r++)
					{
						if ((dish[r][c], dish[r + 1][c]) is ('O', '.'))
						{
							dish[r][c] = '.';
							dish[r + 1][c] = 'O';
							cont = true;
						}
					}
				}
			}

			// east
			for (int r = 0; r < dish.Length; r++)
			{
				var cont = true;

				while (cont)
				{
					cont = false;

					for (int c = 0; c < dish[0].Length - 1; c++)
					{
						if ((dish[r][c], dish[r][c + 1]) is ('O', '.'))
						{
							dish[r][c] = '.';
							dish[r][c + 1] = 'O';
							cont = true;
						}
					}
				}
			}
		}

		return Load(dish);
	}

	private static int Load(char[][] dish)
	{
		var load = 0;

		for (int r = 0; r < dish.Length; r++)
		{
			for (int c = 0; c < dish[r].Length; c++)
			{
				if (dish[r][c] is 'O')
				{
					load += dish.Length - r;
				}
			}
		}

		return load;
	}

	private char[][] Parse() => input
		.Select(line => line.ToArray())
		.ToArray();
}
