namespace AdventOfCode.Year2023;

public class Day13(string input)
{
	public int Part1() => Parse()
		.Select(map => FindReflection(map).Value)
		.Sum(r => r.Row * 100 + r.Col);

	public int Part2() => Parse()
		.Select(map => FindOtherReflection(map, FindReflection(map).Value))
		.Sum(r => r.Row * 100 + r.Col);

	private static (int Row, int Col)? FindReflection(Grid map, (int Row, int Col) skip = default)
	{
		var rows = FindReflections(map.Col(0)).ToHashSet();
		var cols = FindReflections(map.Row(0)).ToHashSet();

		foreach (var col in map.Cols().Skip(1))
		{
			rows.IntersectWith(FindReflections(col));
		}

		foreach (var row in map.Rows().Skip(1))
		{
			cols.IntersectWith(FindReflections(row));
		}

		rows.Remove(skip.Row);
		cols.Remove(skip.Col);

		if (rows.Count is 0 && cols.Count is 0)
		{
			return default;
		}

		return (rows.SingleOrDefault(), cols.SingleOrDefault());

		static IEnumerable<int> FindReflections(char[] line) => Enumerable
			.Range(1, line.Length - 1)
			.Where(i => line.Skip(i).Zip(line.Take(i).Reverse()).All(p => p.First == p.Second));
	}

	private static (int Row, int Col) FindOtherReflection(Grid map, (int, int) skip)
	{
		for (int r = 0; r < map.RowLength; r++)
		{
			for (int c = 0; c < map.ColLength; c++)
			{
				Flip(ref map[r, c]);

				if (FindReflection(map, skip) is { } value)
				{
					return value;
				}

				Flip(ref map[r, c]);
			}
		}

		throw new Exception("not found");

		static void Flip(ref char c) => c = c is '.' ? '#' : '.';
	}

	private class Grid
	{
		private readonly char[][] _data;

		public Grid(IEnumerable<IEnumerable<char>> data)
		{
			_data = data.Select(row => row.ToArray()).ToArray();
		}

		public int RowLength => _data.Length;
		public int ColLength => _data[0].Length;
		public ref char this[int r, int c] => ref _data[r][c];

		public IEnumerable<char[]> Rows()
		{
			for (int r = 0; r < _data.Length; r++)
			{
				yield return Row(r);
			}
		}

		public IEnumerable<char[]> Cols()
		{
			for (int c = 0; c < _data[0].Length; c++)
			{
				yield return Col(c);
			}
		}

		public char[] Row(int r)
		{
			return _data[r];
		}

		public char[] Col(int c)
		{
			var col = new char[_data.Length];

			for (int r = 0; r < _data.Length; r++)
			{
				col[r] = _data[r][c];
			}

			return col;
		}
	}

	private Grid[] Parse() => input
		.ToLines(StringSplitOptions.TrimEntries)
		.Prepend("")
		.GroupWhile((_, line) => line.Length > 0)
		.Select(lines => new Grid(lines.Skip(1)))
		.ToArray();
}
