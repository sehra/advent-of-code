namespace AdventOfCode.Year2024;

public class Day19(string[] input)
{
	public int Part1()
	{
		var (haves, wants) = Parse();

		return wants.Count(want => IsPossible(want));

		bool IsPossible(ReadOnlySpan<char> want)
		{
			if (want.IsEmpty)
			{
				return true;
			}

			foreach (var have in haves)
			{
				if (want.StartsWith(have) && IsPossible(want[have.Length..]))
				{
					return true;
				}
			}

			return false;
		}
	}

	public long Part2()
	{
		var (haves, wants) = Parse();

		return wants.Sum(want => PossibleWays(want, []));

		long PossibleWays(ReadOnlySpan<char> want, Dictionary<int, long> cache)
		{
			if (want.IsEmpty)
			{
				return 1;
			}

			if (cache.TryGetValue(want.Length, out var count))
			{
				return count;
			}

			foreach (var have in haves)
			{
				if (want.StartsWith(have))
				{
					count += PossibleWays(want[have.Length..], cache);
				}
			}

			return cache[want.Length] = count;
		}
	}

	private (string[], string[]) Parse() => (input[0].Split(", "), input[1..]);
}
