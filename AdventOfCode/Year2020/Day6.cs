namespace AdventOfCode.Year2020;

public class Day6
{
	private readonly string[] _input;

	public Day6(string input)
	{
		_input = input.Replace("\r\n", "\n")
			.Split("\n\n", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
	}

	public int Part1()
	{
		return _input
			.Select(group => group.Replace("\n", "").Distinct().Count())
			.Sum();
	}

	public int Part2()
	{
		return _input
			.Select(group => group.ToLines())
			.Select(group => group
				.SelectMany(answer => answer.Distinct())
				.GroupBy(answer => answer, (_, answers) => answers.Count())
				.Where(count => count == group.Length)
				.Count()
			)
			.Sum();
	}
}
