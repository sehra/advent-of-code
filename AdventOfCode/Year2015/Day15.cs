namespace AdventOfCode.Year2015;

public class Day15(string[] input)
{
	public long Part1()
	{
		var ingredients = Parse();

		return Recipes(ingredients.Length)
			.Max(recipe => Score(ingredients, recipe));
	}

	public long Part2()
	{
		var ingredients = Parse();

		return Recipes(ingredients.Length)
			.Max(recipe => Score(ingredients, recipe, 500));
	}

	private static long Score(long[][] ingredients, IEnumerable<int> recipe, int filter = -1)
	{
		if (filter > 0)
		{
			var calories = ingredients.Zip(recipe)
				.Select(prop => prop.First.TakeLast(1).Select(value => value * prop.Second).Single())
				.Sum();

			if (calories != filter)
			{
				return 0;
			}
		}

		return ingredients.Zip(recipe)
			.Select(prop => prop.First.SkipLast(1).Select(value => value * prop.Second))
			.Aggregate((a, b) => a.Zip(b).Select(x => x.First + x.Second))
			.Where(x => x >= 0)
			.Multiply();
	}

	private static IEnumerable<IEnumerable<int>> Recipes(int count, int total = 100)
	{
		var start = count == 1 ? total : 0;

		for (int i = start; i < total + 1; i++)
		{
			var left = total - i;

			if (count - 1 > 0)
			{
				foreach (var y in Recipes(count - 1, left))
				{
					yield return Enumerable.Repeat(i, 1).Concat(y);
				}
			}
			else
			{
				yield return Enumerable.Repeat(i, 1);
			}
		}
	}

	private long[][] Parse() => input
		.Select(line => line.Split([":", ","], StringSplitOptions.TrimEntries)[1..])
		.Select(line => line.Select(prop => prop.Split()[1]).Parse<long>().ToArray())
		.ToArray();
}
