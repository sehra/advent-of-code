namespace AdventOfCode.Year2015;

public class Day1(string input)
{
	public int Part1()
	{
		return input.Sum(Translate);
	}

	public int Part2()
	{
		for (int i = 0, floor = 0; i < input.Length; i++)
		{
			floor += Translate(input[i]);

			if (floor is -1)
			{
				return i + 1;
			}
		}

		throw new Exception("not found");
	}

	static int Translate(char c) => c switch
	{
		'(' => 1,
		')' => -1,
		_ => throw new Exception("char?"),
	};
}
