namespace AdventOfCode.Year2019;

public class Day1
{
	private readonly int[] _input;

	public Day1(string input)
	{
		_input = input.Split('\n').Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return _input.Select(NeededFuelPart1).Sum();
	}

	private static int NeededFuelPart1(int mass)
	{
		return mass / 3 - 2;
	}

	public int Part2()
	{
		return _input.Select(NeededFuelPart2).Sum();
	}

	private static int NeededFuelPart2(int mass)
	{
		var fuel = NeededFuelPart1(mass);

		if (fuel > 0)
		{
			var extra = NeededFuelPart2(fuel);

			if (extra > 0)
			{
				fuel += extra;
			}
		}

		return fuel;
	}
}
