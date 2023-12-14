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
		var cache = new Dictionary<string, int>();

		for (int i = 0; i < n; i++)
		{
			var key = dish.ToString((sb, row) => sb.Append(row));

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

	static void TiltNorth(Dish dish) => SlideCols(dish, (a, b) => b - a);
	static void TiltSouth(Dish dish) => SlideCols(dish, (a, b) => a - b);
	static void TiltEast(Dish dish) => SlideRows(dish, (a, b) => a - b);
	static void TiltWest(Dish dish) => SlideRows(dish, (a, b) => b - a);

	private static void SlideCols(Dish dish, Comparison<char> comp)
	{
		for (int col = 0; col < dish[0].Length; col++)
		{
			SlideCol(dish, col, comp);
		}

		static void SlideCol(Dish dish, int col, Comparison<char> comp)
		{
			Span<char> data = stackalloc char[dish.Length];

			for (int row = 0; row < dish.Length; row++)
			{
				data[row] = dish[row][col];
			}

			Slide(data, comp);

			for (int row = 0; row < dish.Length; row++)
			{
				dish[row][col] = data[row];
			}
		}
	}

	private static void SlideRows(Dish dish, Comparison<char> comp)
	{
		for (int row = 0; row < dish.Length; row++)
		{
			Slide(dish[row], comp);
		}
	}

	private static void Slide(Span<char> line, Comparison<char> comp)
	{
		while (!line.IsEmpty)
		{
			var hash = line.IndexOf('#');
			line[..(hash is -1 ? line.Length : hash)].Sort(comp);
			line = line[(hash is -1 ? line.Length : hash + 1)..];
		}
	}

	private static int Load(Dish dish) => dish
		.Index()
		.Sum(row => row.Value.Count(c => c is 'O') * (dish.Length - row.Key));
	
	private Dish Parse() => input
		.Select(line => line.ToCharArray())
		.ToArray();
}
