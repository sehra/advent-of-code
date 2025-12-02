namespace AdventOfCode.Year2025;

public class Day2(string input)
{
	public long Part1() => Solve(IsInvalid1);

	public long Part2() => Solve(IsInvalid2);

	private long Solve(Func<ReadOnlySpan<char>, bool> predicate)
	{
		Span<char> buffer = stackalloc char[32];
		var result = 0L;

		foreach (var range in input.AsSpan().Split(','))
		{
			var span = input.AsSpan(range);
			var dash = span.IndexOf('-');
			var first = span[..dash].ToInt64();
			var last = span[(dash + 1)..].ToInt64();

			for (var value = first; value <= last; value++)
			{
				value.TryFormat(buffer, out var length);

				if (predicate(buffer[..length]))
				{
					result += value;
				}
			}
		}

		return result;
	}

	private static bool IsInvalid1(ReadOnlySpan<char> value)
	{
		if (value.Length % 2 is 0)
		{
			var mid = value.Length / 2;

			if (value[..mid].SequenceEqual(value[mid..]))
			{
				return true;
			}
		}

		return false;
	}

	static bool IsInvalid2(ReadOnlySpan<char> value)
	{
		for (int len = 1; len <= value.Length / 2; len++)
		{
			if (value.Length % len is not 0)
			{
				continue;
			}

			var valid = false;

			for (int pos = len; pos < value.Length; pos += len)
			{
				if (!value[..len].SequenceEqual(value.Slice(pos, len)))
				{
					valid = true;
					break;
				}
			}

			if (valid)
			{
				continue;
			}

			return true;
		}

		return false;
	}
}
