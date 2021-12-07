namespace AdventOfCode.Year2021;

public class Day7
{
	private readonly int[] _input;

	public Day7(string input)
	{
		_input = input.Split(',').Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return LeastFuel(pos => pos);
	}

	public int Part2()
	{
		return LeastFuel(pos => pos * (pos + 1) / 2);
	}

	private int LeastFuel(Func<int, int> cost)
	{
		var min = _input.Min();
		var max = _input.Max();
		var best = Int32.MaxValue;

		for (int pos = min; pos <= max; pos++)
		{
			var fuel = _input.Sum(p => cost(Math.Abs(p - pos)));
			best = Math.Min(best, fuel);
		}

		return best;
	}
}
