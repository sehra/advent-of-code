namespace AdventOfCode.Year2017;

public class Day5(string[] input)
{
	public int Part1() => Solve(n => n + 1);

	public int Part2() => Solve(n => n >= 3 ? n - 1 : n + 1);

	private int Solve(Func<int, int> next)
	{
		var jumps = input.ToInt32();
		var index = 0;
		var steps = 0;

		while (0 <= index && index < jumps.Length)
		{
			var offset = jumps[index];
			jumps[index] = next(offset);;
			index += offset;
			steps++;
		}

		return steps;
	}
}
