namespace AdventOfCode.Year2025;

public class Day5(string[] input)
{
	public int Part1()
	{
		var (ranges, items) = Parse();

		return items.Count(item => ranges.Any(range => range.Lo <= item && item <= range.Hi));
	}

	public long Part2()
	{
		var (ranges, _) = Parse();
		
		return ranges
			.OrderBy(r => r.Lo)
			.Aggregate(new List<(long Lo, long Hi)>(), (agg, range) =>
			{
				if (agg.Count is 0)
				{
					agg.Add(range);
				}
				else
				{
					var (lo, hi) = agg[^1];

					if (range.Lo <= hi)
					{
						agg[^1] = (lo, Math.Max(hi, range.Hi));
					}
					else
					{
						agg.Add(range);
					}
				}

				return agg;
			})
			.Sum(r => r.Hi - r.Lo + 1);
	}

	private (List<(long Lo, long Hi)>, List<long>) Parse()
	{
		var ranges = new List<(long Lo, long Hi)>();
		var items = new List<long>();

		foreach (var line in input)
		{
			var split = line.Split('-').ToInt64();

			if (split.Length is 2)
			{
				ranges.Add((split[0], split[1]));
			}
			else
			{
				items.Add(split[0]);
			}
		}
		
		return (ranges, items);
	}
}
