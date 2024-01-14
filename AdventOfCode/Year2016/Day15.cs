namespace AdventOfCode.Year2016;

using Disc = (int Slots, int Start);

public class Day15(string[] input)
{
	public int Part1() => Solve(Parse());

	public int Part2() => Solve(Parse().Append((11, 0)));

	private int Solve(IEnumerable<Disc> discs)
	{
		var num = discs.Select(d => d.Slots).ToArray();
		var rem = discs.Select((d, i) => num[i] - (d.Start + i + 1) % num[i]);

		return MathFunc.Crt(num, [.. rem]);
	}

	private Disc[] Parse() => input
		.Select(line => line.Split(' ', '.'))
		.Select(line => (line[3].ToInt32(), line[11].ToInt32()))
		.ToArray();
}
