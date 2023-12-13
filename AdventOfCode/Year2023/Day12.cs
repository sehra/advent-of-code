namespace AdventOfCode.Year2023;

public class Day12(string[] input)
{
	public long Part1() => Parse(1).Sum(x => Count(x.Record, x.Expect));

	public long Part2() => Parse(5).Sum(x => Count(x.Record, x.Expect));

	private long Count(char[] record, int[] expect)
	{
		var cache = new Dictionary<int, long>();

		return Solve(record, expect);

		long Solve(char[] record, int[] expect)
		{
			if (record is [])
			{
				return expect is [] ? 1 : 0;
			}

			if (record.Length < expect.Sum())
			{
				return 0;
			}

			if (cache.TryGetValue(CacheKey(), out var value))
			{
				return value;
			}

			if (record is ['.', ..])
			{
				return Cache(Solve([.. record.AsSpan(1).Trim('.')], expect));
			}

			if (record is ['#', ..])
			{
				if (expect is [])
				{
					return Cache(0);
				}

				if (record.AsSpan(0, expect[0]).Contains('.'))
				{
					return Cache(0);
				}

				var remain = record.AsSpan(expect[0]);

				if (remain is [])
				{
					return Cache(Solve([], expect[1..]));
				}

				if (remain is ['#', ..])
				{
					return Cache(0);
				}

				return Cache(Solve([.. remain[1..]], expect[1..]));
			}

			if (record is ['?', ..])
			{
				return Cache(Solve(['#', .. record.AsSpan(1)], expect) +
					Solve([.. record.AsSpan(1).Trim('.')], expect));
			}

			throw new Exception("char?");

			int CacheKey() => (record.Length << 16) | expect.Length;
			long Cache(long value) => cache[CacheKey()] = value;
		}
	}

	private (char[] Record, int[] Expect)[] Parse(int copies) => input
		.Select(line => line.Split(' '))
		.Select(line => new
		{
			Record = String.Join('?', Enumerable.Repeat(line[0], copies)),
			Expect = String.Join(',', Enumerable.Repeat(line[1], copies)),
		})
		.Select(line => (line.Record.ToArray(), line.Expect.Split(',').ToInt32()))
		.ToArray();
}
