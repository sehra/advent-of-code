namespace AdventOfCode.Year2020;

public class Day15
{
	private readonly int[] _input;

	public Day15(string input)
	{
		_input = input.Split(',').Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return Solve(2020);
	}

	public int Part2()
	{
		return Solve(30_000_000);
	}

	private int Solve(int turns)
	{
		var numbers = new int[turns];

		for (int turn = 0; turn < _input.Length; turn++)
		{
			numbers[_input[turn]] = turn + 1;
		}
		
		var last = _input[^1];

		for (int turn = _input.Length - 1; turn < turns - 1; turn++)
		{
			var spoken = numbers[last];
			numbers[last] = turn + 1;
			last = spoken is 0 ? 0 : turn + 1 - spoken;
		}

		return last;
	}
}
