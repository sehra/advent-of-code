namespace AdventOfCode.Year2022;

public class Day1
{
	private readonly string _input;

	public Day1(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Parse().Max();
	}

	public int Part2()
	{
		return Parse().OrderDescending().Take(3).Sum();
	}

	private List<int> Parse()
	{
		var result = new List<int>() { 0 };

		foreach (var line in _input.ToLines(StringSplitOptions.TrimEntries))
		{
			if (String.IsNullOrEmpty(line))
			{
				result.Add(0);
			}
			else
			{
				result[^1] += line.ToInt32();
			}
		}

		return result;
	}
}
