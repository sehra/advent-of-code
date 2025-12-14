namespace AdventOfCode.Year2025;

public class Day7(string[] input)
{
	public int Part1() => Solve().Item1;

	public long Part2() => Solve().Item2;

	private (int, long) Solve()
	{
		var beams = new long[input[0].Length];
		beams[input[0].IndexOf('S')] = 1;
		var count = 0;

		foreach (var line in input)
		{
			for (int i = 0; i < line.Length; i++)
			{
				if (line[i] is '^' && beams[i] > 0)
				{
					beams[i - 1] += beams[i];
					beams[i + 1] += beams[i];
					beams[i] = 0;
					count++;
				}
			}
		}

		return (count, beams.Sum());
	}
}
