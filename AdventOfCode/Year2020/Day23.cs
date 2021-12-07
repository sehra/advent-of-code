using System.Text;

namespace AdventOfCode.Year2020;

public class Day23
{
	private readonly int[] _input;

	public Day23(string input)
	{
		_input = input.Trim().Select(c => c - '0').ToArray();
	}

	public string Part1(int moves = 100)
	{
		var cups = RunGame(_input, moves);
		var result = new StringBuilder();

		for (int i = 0, x = 1; i < 8; i++)
		{
			result.Append(x = cups[x]);
		}

		return result.ToString();
	}

	public long Part2()
	{
		var cups = RunGame(_input, 10_000_000, 1_000_000);
		long a = cups[1];
		long b = cups[a];

		return a * b;
	}

	private static int[] RunGame(int[] input, int moves, int? size = null)
	{
		size ??= input.Length;
		var cups = new int[size.Value + 1];

		for (int i = 0; i < cups.Length; i++)
		{
			cups[i] = i + 1;
		}

		for (int i = 0; i < input.Length - 1; i++)
		{
			cups[input[i]] = input[i + 1];
		}

		cups[0] = input[0];
		cups[input[^1]] = input.Length == size
			? input[0]
			: input.Length + 1;

		if (cups.Length > input.Length + 1)
		{
			cups[^1] = input[0];
		}

		for (int i = 0; i < moves; i++)
		{
			var value = cups[0];
			var next1 = cups[value];
			var next2 = cups[next1];
			var next3 = cups[next2];
			cups[value] = cups[next3];
			cups[0] = cups[next3];
			var x = value - 1;

			while (x == next1 || x == next2 || x == next3 || x == 0)
			{
				x = x == 0 ? size.Value : x - 1;
			}

			var cut = cups[x];
			cups[x] = next1;
			cups[next3] = cut;
		}

		return cups;
	}
}
