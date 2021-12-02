namespace AdventOfCode.Year2021;

public class Day2
{
	private readonly string[] _input;

	public Day2(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var position = 0;
		var depth = 0;

		foreach (var line in _input)
		{
			var value = line.AsSpan(line.IndexOf(' ')).ToInt32();

			switch (line[0])
			{
				case 'f':
					position += value;
					break;

				case 'd':
					depth += value;
					break;

				case 'u':
					depth -= value;
					break;
			}
		}

		return position * depth;
	}

	public int Part2()
	{
		var position = 0;
		var depth = 0;
		var aim = 0;

		foreach (var line in _input)
		{
			var value = line.AsSpan(line.IndexOf(' ')).ToInt32();

			switch (line[0])
			{
				case 'f':
					position += value;
					depth += aim * value;
					break;

				case 'd':
					aim += value;
					break;

				case 'u':
					aim -= value;
					break;
			}
		}

		return position * depth;
	}
}
