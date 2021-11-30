namespace AdventOfCode.Year2020;

public class Day15
{
	private readonly int[] _input;

	public Day15(string input)
	{
		_input = input.Split(',').Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return Solve(2020);
	}

	public int Part2()
	{
		return Solve(30_000_000);
	}

	private int Solve(int turns)
	{
		var numbers = new Dictionary<int, (int Last, int Prev)>();
		var last = _input.Last();

		for (int turn = 0; turn < _input.Length; turn++)
		{
			numbers.Add(_input[turn], (turn, -1));
		}

		for (int turn = _input.Length; turn < turns; turn++)
		{
			var number = numbers[last];

			if (number.Prev == -1)
			{
				last = 0;
			}
			else
			{
				last = number.Last - number.Prev;
			}

			if (numbers.TryGetValue(last, out number))
			{
				numbers[last] = (turn, number.Last);
			}
			else
			{
				numbers[last] = (turn, -1);
			}
		}

		return last;
	}
}
