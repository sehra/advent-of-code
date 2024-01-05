namespace AdventOfCode.Year2018;

public class Day5(string input)
{
	public int Part1() => React(input);

	public int Part2() => input
		.Where(Char.IsLower)
		.Distinct()
		.Select(c => React(input.Replace($"{c}", "", StringComparison.OrdinalIgnoreCase)))
		.Min();

	private static int React(string input)
	{
		var polymer = input.ToList();
		var again = true;

		while (again)
		{
			again = false;

			for (int i = 0; i < polymer.Count - 1; i++)
			{
				if (polymer[i] - 'a' == polymer[i + 1] - 'A' ||
					polymer[i] - 'A' == polymer[i + 1] - 'a')
				{
					polymer.RemoveRange(i, 2);
					again = true;
				}
			}
		}

		return polymer.Count;
	}
}
