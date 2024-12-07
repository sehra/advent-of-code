namespace AdventOfCode.Year2024;

public class Day7(string[] input)
{
	public long Part1()
	{
		return Parse().Where(x => Search(x.Value, x.Numbers, false)).Sum(x => x.Value);
	}

	public long Part2()
	{
		return Parse().Where(x => Search(x.Value, x.Numbers, true)).Sum(x => x.Value);
	}

	private static bool Search(long target, long[] numbers, bool part2, int index = 0, long result = 0)
	{
		if (index == numbers.Length)
		{
			return result == target;
		}

		if (result > target)
		{
			return false;
		}

		return Search(target, numbers, part2, index + 1, result + numbers[index]) ||
			Search(target, numbers, part2, index + 1, result * numbers[index]) ||
			(part2 && Search(target, numbers, part2, index + 1, Concat(result, numbers[index])));

		static long Concat(long a, long b)
		{
			var c = b;

			while (c > 0)
			{
				a *= 10;
				c /= 10;
			}

			return a + b;
		}
	}

	private IEnumerable<(long Value, long[] Numbers)> Parse() => input
		.Select(x => x.Split(": "))
		.Select(x => (x[0].ToInt64(), x[1].Split().ToInt64()));
}
