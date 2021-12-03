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
		var count = BitCount(_input);
		var gammaBuf = new char[count.Length];
		var epsilonBuf = new char[count.Length];

		for (int i = 0; i < count.Length; i++)
		{
			if (count[i] < 0)
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
		var eplison = Convert.ToInt32(new string(epsilonBuf), 2);

		return gamma * eplison;
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
			var count = BitCount(haystack);
			var index = 0;

			while (true)
			{
				needle += comparer(count[index]) ? '0' : '1';
				haystack = haystack.Where(x => x.StartsWith(needle)).ToArray();

				if (haystack.Length is 1)
				{
					return haystack[0];
				}

				count = BitCount(haystack);
				index++;
			}
		}
	}

	private static int[] BitCount(string[] values)
	{
		var count = new int[values[0].Length];

		foreach (var value in values)
		{
			for (int i = 0; i < value.Length; i++)
			{
				count[i] += value[i] is '0' ? -1 : 1;
			}
		}

		return count;
	}
}
