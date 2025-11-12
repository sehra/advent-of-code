namespace AdventOfCode.Year2016;

public class Day18(string input)
{
	public int Part1(int rows = 40) => Solve(rows);

	public int Part2() => Solve(400_000);

	private int Solve(int rows)
	{
		var floor = new List<char[]>() { input.ToCharArray() };

		for (int row = 1; row < rows; row++)
		{
			var tiles = new char[input.Length];

			for (int col = 0; col < tiles.Length; col++)
			{
				var l = GetTile(row - 1, col - 1);
				var c = GetTile(row - 1, col);
				var r = GetTile(row - 1, col + 1);

				tiles[col] = (l, c, r) switch
				{
					('^', '^', '.') => '^',
					('.', '^', '^') => '^',
					('^', '.', '.') => '^',
					('.', '.', '^') => '^',
					_ => '.'
				};
			}

			floor.Add(tiles);
		}

		return floor.Sum(row => row.Count(c => c is '.'));

		char GetTile(int row, int col) =>
			0 <= col && col < floor[row].Length
			? floor[row][col]
			: '.';
	}
}
