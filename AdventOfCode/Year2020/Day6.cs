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
			.Sum(group => group.Replace("\n", "").Distinct().Count());
	}

	public int Part2()
	{
		return _input
			.Select(group => group.ToLines())
			.Sum(group => group
				.SelectMany(answer => answer.Distinct())
				.GroupBy(answer => answer, (_, answers) => answers.Count())
				.Count(count => count == group.Length)
			);
	}
}
