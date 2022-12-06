namespace AdventOfCode.Year2022;

public class Day6
{
	private readonly string _input;

	public Day6(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Solve(4);
	}

	public int Part2()
	{
		return Solve(14);
	}

	private int Solve(int count)
	{
		for (int i = 0; i < _input.Length - count; i++)
		{
			if (_input.Skip(i).Take(count).Distinct().Count() == count)
			{
				return i + count;
			}
		}

		throw new Exception("not found");
	}
}
