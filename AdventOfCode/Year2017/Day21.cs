namespace AdventOfCode.Year2017;

public class Day21(string[] input)
{
	public int Part1(int iterations = 5) => Solve(iterations);

	public int Part2() => Solve(18);

	private int Solve(int iterations)
	{
		var rules = Parse();

		foreach (var (_, src, _) in rules)
		{
			var m = src[0];
			src.Add(m = Transpose(m));
			src.Add(m = Reverse(m));
			src.Add(m = Transpose(m));
			src.Add(m = Reverse(m));
			src.Add(m = Transpose(m));
			src.Add(m = Reverse(m));
			src.Add(Transpose(m));
		}

		var image = new char[,]
		{
			{ '.', '#', '.' },
			{ '.', '.', '#' },
			{ '#', '#', '#' },
		};

		for (int i = 0; i < iterations; i++)
		{
			if (image.GetLength(0) % 2 is 0)
			{
				var size = image.GetLength(0) / 2 * 3;
				var next = new char[size, size];

				for (int row = 0; row < image.GetLength(0); row += 2)
				{
					for (int col = 0; col < image.GetLength(1); col += 2)
					{
						var rule = rules
							.Where(r => r.Size is 2)
							.FirstOrDefault(r => r.Src.Any(s => IsMatch(row, col, s)));

						if (rule != null)
						{
							Copy(rule.Dst, next, row / 2 * 3, col / 2 * 3);
						}
					}
				}

				image = next;
			}
			else
			{
				var size = image.GetLength(0) / 3 * 4;
				var next = new char[size, size];

				for (int row = 0; row < image.GetLength(0); row += 3)
				{
					for (int col = 0; col < image.GetLength(1); col += 3)
					{
						var rule = rules
							.Where(r => r.Size is 3)
							.FirstOrDefault(r => r.Src.Any(s => IsMatch(row, col, s)));

						if (rule != null)
						{
							Copy(rule.Dst, next, row / 3 * 4, col / 3 * 4);
						}
					}
				}

				image = next;
			}
		}

		return image.AsEnumerable().Count(x => x.Value is '#');

		bool IsMatch(int row, int col, char[,] find)
		{
			for (int r = 0; r < find.GetLength(0); r++)
			{
				for (int c = 0; c < find.GetLength(1); c++)
				{
					if (image[row + r, col + c] != find[r, c])
					{
						return false;
					}
				}
			}

			return true;
		}

		static void Copy(char[,] src, char[,] dst, int row, int col)
		{
			for (int r = 0; r < src.GetLength(0); r++)
			{
				for (int c = 0; c < src.GetLength(1); c++)
				{
					dst[row + r, col + c] = src[r, c];
				}
			}
		}

		static char[,] Transpose(char[,] matrix)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);
			var result = new char[cols, rows];

			for (int col = 0; col < cols; col++)
			{
				for (int row = 0; row < rows; row++)
				{
					result[col, row] = matrix[row, col];
				}
			}

			return result;
		}

		static char[,] Reverse(char[,] matrix)
		{
			var rows = matrix.GetLength(0);
			var cols = matrix.GetLength(1);
			var result = new char[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					result[row, col] = matrix[row, cols - col - 1];
				}
			}

			return result;
		}
	}

	private record class Rule(int Size, List<char[,]> Src, char[,] Dst);

	private List<Rule> Parse()
	{
		var rules = new List<Rule>();

		foreach (var line in input)
		{
			var split = line.Split("=>", StringSplitOptions.TrimEntries);
			var src = split[0].Split('/');
			var dst = split[1].Split('/');
			rules.Add(new(src[0].Length, [ToArray(src)], ToArray(dst)));
		}

		return rules;

		static char[,] ToArray(string[] data)
		{
			var rows = data.Length;
			var cols = data[0].Length;
			var result = new char[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					result[row, col] = data[row][col];
				}
			}

			return result;
		}
	}
}
