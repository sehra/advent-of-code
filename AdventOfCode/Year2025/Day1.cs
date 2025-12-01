namespace AdventOfCode.Year2025;

public class Day1(string[] input)
{
	public int Part1()
	{
		var pos = 50;
		var res = 0;

		foreach (var line in input)
		{
			var dir = line[0] is 'L' ? -1 : 1;
			var val = line[1..].ToInt32();
			pos = (pos + dir * val) % 100;

			if (pos is 0)
			{
				res++;
			}
		}

		return res;
	}

	public int Part2()
	{
		var pos = 50;
		var res = 0;

		foreach (var line in input)
		{
			var dir = line[0] is 'L' ? -1 : 1;
			var val = line[1..].ToInt32();

			for (var i = 0; i < val; i++)
			{
				pos = (pos + dir) % 100;

				if (pos is 0)
				{
					res++;
				}
			}
		}

		return res;
	}
}
