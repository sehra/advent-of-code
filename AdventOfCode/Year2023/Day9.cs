namespace AdventOfCode.Year2023;

public class Day9(string[] input)
{
	public int Part1() => Solve((a, d) => d.Right + a);

	public int Part2() => Solve((a, d) => d.Left - a);

	private int Solve(Func<int, (int Left, int Right), int> next) =>
		Parse().Sum(hist => Diff(hist).Reverse().Aggregate(0, next));

	private static IEnumerable<(int Left, int Right)> Diff(int[] hist)
	{
		yield return (hist[0], hist[^1]);

		while (!hist.All(x => x is 0))
		{
			hist = hist.Window(2).Select(x => x[1] - x[0]).ToArray();
			yield return (hist[0], hist[^1]);
		}
	}

	private IEnumerable<int[]> Parse() => input.Select(line => line.Split().ToInt32());
}
