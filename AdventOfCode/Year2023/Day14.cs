namespace AdventOfCode.Year2023;

using Dish = char[][];

public class Day14(string[] input)
{
	public int Part1()
	{
		var dish = Parse();

		TiltNorth(dish);

		return Load(dish);
	}

	public int Part2()
	{
		const int n = 1_000_000_000;

		var dish = Parse();
		var cache = new Dictionary<int, int>();

		for (int i = 0; i < n; i++)
		{
			var key = dish
				.SelectMany(row => row)
				.Aggregate(0, HashCode.Combine);

			if (cache.TryGetValue(key, out var j))
			{
				i = n - ((n - i) % (i - j));
			}
			else
			{
				cache.Add(key, i);
			}

			TiltNorth(dish);
			TiltWest(dish);
			TiltSouth(dish);
			TiltEast(dish);
		}

		return Load(dish);
	}

	static void TiltNorth(Dish dish) => SlideCols(dish, 'O', '.');
	static void TiltSouth(Dish dish) => SlideCols(dish, '.', 'O');
	static void TiltEast(Dish dish) => SlideRows(dish, '.', 'O');
	static void TiltWest(Dish dish) => SlideRows(dish, 'O', '.');

	private static void SlideCols(Dish dish, char fst, char lst)
	{
		for (int col = 0; col < dish[0].Length; col++)
		{
			SlideCol(dish, col, fst, lst);
		}

		static void SlideCol(Dish dish, int col, char fst, char lst)
		{
			Span<char> data = stackalloc char[dish.Length];

			for (int row = 0; row < dish.Length; row++)
			{
				data[row] = dish[row][col];
			}

			Slide(data, fst, lst);

			for (int row = 0; row < dish.Length; row++)
			{
				dish[row][col] = data[row];
			}
		}
	}

	private static void SlideRows(Dish dish, char fst, char lst)
	{
		for (int row = 0; row < dish.Length; row++)
		{
			Slide(dish[row], fst, lst);
		}
	}

	private static void Slide(Span<char> line, char fst, char lst)
	{
		while (!line.IsEmpty)
		{
			var hash = line.IndexOf('#');
			hash = hash is -1 ? line.Length : hash;
			var span = line[..hash];
			var edge = span.Count(fst);
			span[..edge].Fill(fst);
			span[edge..].Fill(lst);
			line = line[span.Length..].TrimStart('#');
		}
	}

	private static int Load(Dish dish) => dish
		.Index()
		.Sum(row => row.Item.Count(c => c is 'O') * (dish.Length - row.Index));
	
	private Dish Parse() => input
		.Select(line => line.ToCharArray())
		.ToArray();
}
