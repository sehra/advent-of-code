using System.Diagnostics.CodeAnalysis;

namespace AdventOfCode.Year2020;

public class Day25
{
	private readonly string[] _input;

	public Day25(string input)
	{
		_input = input.ToLines();
	}

	public long Part1()
	{
		var card = _input[0].ToInt64();
		var door = _input[1].ToInt64();

		long value = 1;
		var loops = 0;

		while (value != card)
		{
			value *= 7;
			value %= 20201227;
			loops++;
		}

		long key = 1;

		for (int i = 0; i < loops; i++)
		{
			key *= door;
			key %= 20201227;
		}

		return key;
	}

	[SuppressMessage("Performance", "CA1822")]
	public string Part2()
	{
		return "get 49 stars";
	}
}
