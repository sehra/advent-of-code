namespace AdventOfCode.Year2015;

public class Day20(string input)
{
	public int Part1()
	{
		var target = input.ToInt32();
		var houses = new int[target / 10];

		for (int elf = 1; elf < houses.Length; elf++)
		{
			for (int i = elf; i < houses.Length; i += elf)
			{
				houses[i] += elf * 10;
			}
		}

		return Array.FindIndex(houses, n => n >= target);
	}

	public int Part2()
	{
		var target = input.ToInt32();
		var houses = new int[target / 10];

		for (int elf = 1; elf < houses.Length; elf++)
		{
			for (int i = elf, n = 0; i < houses.Length && n < 50; i += elf, n++)
			{
				houses[i] += elf * 11;
			}
		}

		return Array.FindIndex(houses, n => n >= target);
	}
}
