namespace AdventOfCode.Year2020;

public class Day5
{
	private readonly string[] _input;

	public Day5(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		return _input.Select(Decode).Max();
	}

	public int Part2()
	{
		var seats = _input.Select(Decode).OrderBy(x => x).ToArray();

		for (int i = 0; i < seats.Length - 1; i++)
		{
			if (seats[i] + 1 != seats[i + 1])
			{
				return seats[i] + 1;
			}
		}

		throw new Exception("not found");
	}

	private int Decode(string value)
	{
		value = value
			.Replace('F', '0')
			.Replace('B', '1')
			.Replace('L', '0')
			.Replace('R', '1');

		return Convert.ToInt32(value, 2);
	}
}
