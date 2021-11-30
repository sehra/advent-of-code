namespace AdventOfCode.Year2020;

public class Day3
{
	private readonly string[] _input;

	public Day3(string input)
	{
		_input = input.ToLines();
	}

	public long Part1()
	{
		return CountTrees(3, 1);
	}

	public long Part2()
	{
		long answer = CountTrees(1, 1);
		answer *= CountTrees(3, 1);
		answer *= CountTrees(5, 1);
		answer *= CountTrees(7, 1);
		answer *= CountTrees(1, 2);

		return answer;
	}

	private int CountTrees(int right, int down)
	{
		var trees = 0;

		for (int i = 0, j = 0; i < _input.Length; i += down, j += right)
		{
			if (_input[i][j % _input[i].Length] == '#')
			{
				trees++;
			}
		}

		return trees;
	}
}
