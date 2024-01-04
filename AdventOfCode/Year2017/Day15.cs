namespace AdventOfCode.Year2017;

public class Day15(string[] input)
{
	public int Part1()
	{
		var gens = Parse();
		var a = Generator(gens[0], 16807).GetEnumerator();
		var b = Generator(gens[1], 48271).GetEnumerator();
		var count = 0;

		for (int i = 0; i < 40_000_000; i++)
		{
			if ((a.Next() & 0xFFFF) == (b.Next() & 0xFFFF))
			{
				count++;
			}
		}

		return count;

		static IEnumerable<long> Generator(int start, int factor)
		{
			long value = start;

			while (true)
			{
				value *= factor;
				value %= 2147483647;

				yield return value;
			}
		}
	}

	public int Part2()
	{
		var gens = Parse();
		var a = Generator(gens[0], 16807, 4).GetEnumerator();
		var b = Generator(gens[1], 48271, 8).GetEnumerator();
		var count = 0;

		for (int i = 0; i < 5_000_000; i++)
		{
			if ((a.Next() & 0xFFFF) == (b.Next() & 0xFFFF))
			{
				count++;
			}
		}

		return count;

		static IEnumerable<long> Generator(int start, int factor, int multiple)
		{
			long value = start;

			while (true)
			{
				value *= factor;
				value %= 2147483647;

				if (value % multiple is 0)
				{
					yield return value;
				}
			}
		}
	}

	private int[] Parse() => input
		.Select(line => line.Split()[4].ToInt32())
		.ToArray();
}
