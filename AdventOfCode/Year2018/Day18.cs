namespace AdventOfCode.Year2018;

using Point = (int R, int C);

public class Day18(string[] input)
{
	public int Part1()
	{
		var grid = Parse();

		for (int i = 0; i < 10; i++)
		{
			grid = Step(grid);
		}

		return Score(grid);
	}

	public int Part2()
	{
		const int n = 1_000_000_000;
		
		var grid = Parse();
		var seen = new Dictionary<string, int>();

		for (int i = 0; i < n; i++)
		{
			var state = grid
				.AsEnumerable()
				.ToString((sb, e) => sb.Append(e.Value));

			if (seen.TryGetValue(state, out var j))
			{
				i = n - ((n - i) % (i - j));
			}
			else
			{
				seen.Add(state, i);
			}

			grid = Step(grid);
		}

		return Score(grid);
	}

	private static int Score(char[,] grid) =>
		grid.AsEnumerable().Count(v => v.Value is '|') *
		grid.AsEnumerable().Count(v => v.Value is '#');

	private char[,] Step(char[,] grid)
	{
		var rows = grid.GetLength(0);
		var cols = grid.GetLength(1);
		var next = new char[rows, cols];

		for (int r = 0; r < rows; r++)
		{
			for (int c = 0; c < cols; c++)
			{
				var adj = Adjacent((r, c))
					.Where(InBounds)
					.Select(p => grid[p.R, p.C]);
				var t = adj.Count(c => c is '|');
				var l = adj.Count(c => c is '#');

				next[r, c] = (grid[r, c], t, l) switch
				{
					('.', >= 3, _) => '|',
					('|', _, >= 3) => '#',
					('#', >= 1, >= 1) => '#',
					('#', _, _) => '.',
					(var x, _, _) => x,
				};
			}
		}

		return next;

		static IEnumerable<Point> Adjacent(Point p)
		{
			yield return (p.R - 1, p.C - 1);
			yield return (p.R - 1, p.C);
			yield return (p.R - 1, p.C + 1);
			yield return (p.R, p.C - 1);
			yield return (p.R, p.C + 1);
			yield return (p.R + 1, p.C - 1);
			yield return (p.R + 1, p.C);
			yield return (p.R + 1, p.C + 1);
		}

		bool InBounds(Point p) =>
			0 <= p.R && p.R < rows &&
			0 <= p.C && p.C < cols;
	}

	private char[,] Parse()
	{
		var grid = new char[input.Length, input[0].Length];

		for (int r = 0; r < input.Length; r++)
		{
			for (int c = 0; c < input[r].Length; c++)
			{
				grid[r, c] = input[r][c];
			}
		}

		return grid;
	}
}
