namespace AdventOfCode.Year2016;

public class Day3(string[] input)
{
	public int Part1()
	{
		return input
			.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToInt32())
			.Count(PossibleTriangle);
	}

	public int Part2()
	{
		return input
			.Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToInt32())
			.Chunk(3)
			.SelectMany(t => new int[][]
			{
				[t[0][0], t[1][0], t[2][0]],
				[t[0][1], t[1][1], t[2][1]],
				[t[0][2], t[1][2], t[2][2]],
			})
			.Count(PossibleTriangle);
	}

	private static bool PossibleTriangle(int[] t) =>
		t[0] + t[1] > t[2] && t[0] + t[2] > t[1] && t[1] + t[2] > t[0];
}
