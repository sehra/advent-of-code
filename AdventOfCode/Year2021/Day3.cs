namespace AdventOfCode.Year2021;

public class Day3
{
	private readonly string[] _input;

	public Day3(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var gammaBuf = new char[_input[0].Length];
		var epsilonBuf = new char[_input[0].Length];

		for (int i = 0; i < _input[0].Length; i++)
		{
			if (BitCount(_input, i) < 0)
			{
				gammaBuf[i] = '1';
				epsilonBuf[i] = '0';
			}
			else
			{
				gammaBuf[i] = '0';
				epsilonBuf[i] = '1';
			}
		}

		var gamma = Convert.ToInt32(new string(gammaBuf), 2);
		var epsilon = Convert.ToInt32(new string(epsilonBuf), 2);

		return gamma * epsilon;
	}

	public int Part2()
	{
		var generator = Convert.ToInt32(Find(c => c < 0), 2);
		var scrubber = Convert.ToInt32(Find(c => c >= 0), 2);

		return generator * scrubber;

		string Find(Func<int, bool> comparer)
		{
			var haystack = _input;
			var needle = "";
			var index = 0;

			while (true)
			{
				needle += comparer(BitCount(haystack, index++)) ? '0' : '1';
				haystack = haystack.Where(x => x.StartsWith(needle)).ToArray();

				if (haystack.Length is 1)
				{
					return haystack[0];
				}
			}
		}
	}

	private static int BitCount(string[] values, int index)
	{
		var count = 0;

		foreach (var value in values)
		{
			count += value[index] is '0' ? -1 : 1;
		}

		return count;
	}
}
