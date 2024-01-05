namespace AdventOfCode.Year2018;

public class Day1(string[] input)
{
	public int Part1() => Parse().Sum();

	public int Part2()
	{
		var seen = new HashSet<int>();

		foreach (var freq in Parse().Repeat().Scan((a, b) => a + b))
		{
			if (!seen.Add(freq))
			{
				return freq;
			}
		}

		throw new Exception("not found");
	}

	private int[] Parse() => input.ToInt32();
}
