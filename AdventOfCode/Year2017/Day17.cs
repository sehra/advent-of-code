namespace AdventOfCode.Year2017;

public class Day17(string input)
{
	public int Part1()
	{
		var steps = input.ToInt32();
		var buffer = new List<int>() { 0 };

		for (int value = 1, index = 0; value < 2018; value++)
		{
			index = (index + steps) % buffer.Count + 1;
			buffer.Insert(index, value);
		}

		return buffer[buffer.IndexOf(2017) + 1];
	}

	public int Part2()
	{
		var steps = input.ToInt32();
		var answer = 0;

		for (int value = 1, index = 0; value < 50_000_000; value++)
		{
			index = (index + steps) % value + 1;

			if (index is 1)
			{
				answer = value;
			}
		}

		return answer;
	}
}
