namespace AdventOfCode.Year2021;

public class Day1
{
	private readonly int[] _input;

	public Day1(string input)
	{
		_input = input.ToLines().Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return _input
			.Window(2)
			.Count(x => x[1] > x[0]);
	}

	public int Part2()
	{
		return _input
			.Window(3)
			.Window(2)
			.Count(x => x[1].Sum() > x[0].Sum());
	}
}
