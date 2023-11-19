namespace AdventOfCode.Year2020;

public class Day21
{
	private readonly string[] _input;

	public Day21(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var foods = Parse();
		var allergens = GetAllergens(foods);

		return foods.SelectMany(f => f.Ingredients).Count(i => !allergens.ContainsValue(i));
	}

	public string Part2()
	{
		var foods = Parse();
		var allergens = GetAllergens(foods);

		return String.Join(',', allergens.OrderBy(m => m.Key).Select(m => m.Value));
	}

	private record Food(string[] Ingredients, string[] Allergens);

	private List<Food> Parse()
	{
		var foods = new List<Food>();

		foreach (var line in _input)
		{
			var cut = line.IndexOf('(');
			var ingredients = line[..(cut - 1)].Split(' ');
			var allergens = line[(cut + 10)..^1].Split(", ");
			foods.Add(new(ingredients, allergens));
		}

		return foods;
	}

	private static Dictionary<string, string> GetAllergens(List<Food> foods)
	{
		var matches = new Dictionary<string, List<string>>();

		foreach (var allergen in foods.SelectMany(f => f.Allergens).Distinct())
		{
			matches.Add(allergen, []);

			foreach (var ingredient in foods.First(f => f.Allergens.Contains(allergen)).Ingredients)
			{
				if (foods.Where(f => f.Allergens.Contains(allergen)).All(f => f.Ingredients.Contains(ingredient)))
				{
					matches[allergen].Add(ingredient);
				}
			}
		}

		var done = new HashSet<string>();

		while (matches.Any(m => m.Value.Count > 1))
		{
			var current = matches.First(m => !done.Contains(m.Key) && m.Value.Count == 1);
			var value = current.Value[0];

			foreach (var match in matches.Except(current).Where(m => m.Value.Contains(value)))
			{
				match.Value.Remove(value);
			}

			done.Add(current.Key);
		}

		return matches.ToDictionary(m => m.Key, m => m.Value[0]);
	}
}
