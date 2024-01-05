namespace AdventOfCode.Year2017;

public class Day1(string input)
{
	public int Part1() => Solve(1);

	public int Part2() => Solve(input.Length / 2);

	private int Solve(int offset)
	{
		var sum = 0;

		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] == input[(i + offset) % input.Length])
			{
				sum += input[i] - '0';
			}
		}

		return sum;
	}
}
