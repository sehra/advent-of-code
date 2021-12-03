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
			if (count[i].Z < count[i].O)
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
		var generator = Convert.ToInt32(Find(c => c.Z > c.O ? '0' : '1'), 2);
		var scrubber = Convert.ToInt32(Find(c => c.Z <= c.O ? '0' : '1'), 2);

		return generator * scrubber;

		string Find(Func<Count, char> comparer)
		{
			var haystack = _input;
			var needle = "";
			var count = BitCount(haystack);
			var index = 0;

			while (true)
			{
				needle += comparer(count[index]);
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

	private static Count[] BitCount(string[] values)
	{
		var count = new Count[values[0].Length];

		foreach (var value in values)
		{
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] is '0')
				{
					count[i].Z++;
				}
				else
				{
					count[i].O++;
				}
			}
		}

		return count;
	}

	private record struct Count(int Z, int O);
}
