namespace AdventOfCode.Year2017;

public class Day6(string input)
{
	public int Part1()
	{
		var banks = input.Split('\t').ToInt32();
		var seen = new HashSet<int[]>(new Comparer());
		var cycle = 0;

		while (true)
		{
			if (!seen.Add([.. banks]))
			{
				return cycle;
			}

			var (index, count) = banks.Index().MaxBy(b => b.Value);
			banks[index] = 0;

			while (count-- > 0)
			{
				index = (index + 1) % banks.Length;
				banks[index] += 1;
			}

			cycle++;
		}
	}

	public int Part2()
	{
		var banks = input.Split('\t').ToInt32();
		var seen = new HashSet<int[]>(new Comparer());
		var cycle = 0;

		int[] watch = null;
		var last = 0;

		while (true)
		{
			if (!seen.Add([.. banks]))
			{
				if (last is 0)
				{
					watch = [.. banks];
					last = cycle;
				}
				else if (watch.SequenceEqual(banks))
				{
					return cycle - last;
				}
			}

			var (index, count) = banks.Index().MaxBy(b => b.Value);
			banks[index] = 0;

			while (count-- > 0)
			{
				index = (index + 1) % banks.Length;
				banks[index] += 1;
			}

			cycle++;
		}
	}

	private class Comparer : IEqualityComparer<int[]>
	{
		public bool Equals(int[] x, int[] y) =>
			x.SequenceEqual(y);

		public int GetHashCode(int[] obj) =>
			obj.Aggregate(HashCode.Combine);
	}
}
