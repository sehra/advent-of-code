using System.Text;

namespace AdventOfCode.Year2022;

public class Day10
{
	private readonly string[] _input;

	public Day10(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var signal = 0;

		foreach (var (cycle, value) in Execute())
		{
			if (cycle is 20 or 60 or 100 or 140 or 180 or 220)
			{
				signal += cycle * value;
			}
		}

		return signal;
	}

	public string Part2()
	{
		var pixels = new char[6, 40];

		foreach (var (cycle, value) in Execute())
		{
			var (row, col) = Math.DivRem(cycle - 1, 40);
			pixels[row, col] = col >= value - 1 && col <= value + 1 ? '#' : '.';
		}

		var screen = new StringBuilder();

		for (int r = 0; r < 6; r++)
		{
			for (int c = 0; c < 40; c++)
			{
				screen.Append(pixels[r, c]);
			}

			screen.AppendLine();
		}

		return screen.ToString();
	}

	private IEnumerable<(int Cycle, int Value)> Execute()
	{
		var cycle = 1;
		var value = 1;

		foreach (var line in _input)
		{
			if (line is "noop")
			{
				yield return (cycle++, value);
			}
			else if (line.StartsWith("addx"))
			{
				yield return (cycle++, value);
				yield return (cycle++, value);
				value += line.AsSpan(5).ToInt32();
			}
		}
	}
}
