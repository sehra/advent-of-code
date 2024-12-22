namespace AdventOfCode.Year2024;

using Key = (int, int, int, int);

public class Day22(int[] input)
{
	public long Part1()
	{
		return input.Sum(seed => (long)Secrets(seed).Take(2000).Last());
	}

	public int Part2()
	{
		var seqs = new Counter<Key>();
		var seen = new HashSet<Key>(2000);

		foreach (var seed in input)
		{
			seen.Clear();
			var nums = Secrets(seed)
				.Take(2000)
				.Prepend(seed)
				.Select(n => n % 10)
				.TupleWindow2()
				.Select(w => (w.Item2 - w.Item1, w.Item2))
				.TupleWindow4();

			foreach (var ((a, _), (b, _), (c, _), (d, num)) in nums)
			{
				var key = (a, b, c, d);

				if (seen.Add(key))
				{
					seqs[key] += num;
				}
			}
		}

		return seqs.Values.Max();
	}

	private static IEnumerable<int> Secrets(int seed)
	{
		long state = seed;

		while (true)
		{
			state ^= state * 64;
			state %= 16777216;
			state ^= state / 32;
			state %= 16777216;
			state ^= state * 2048;
			state %= 16777216;

			yield return (int)state;
		}
	}
}
