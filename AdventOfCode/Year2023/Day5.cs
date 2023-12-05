namespace AdventOfCode.Year2023;

public class Day5(string[] input)
{
	public long Part1()
	{
		var (seeds, maps) = Parse();

		return seeds.Min(seed => maps.Aggregate(seed, MapForward));
	}

	public long Part2()
	{
		var (seeds, maps) = Parse();

		return maps
			.SelectMany((map, i) => map.Select(range => maps.Take(i + 1).Reverse().Aggregate(range.Dst, MapReverse)))
			.Where(seed => seeds.Chunk(2).Any(pair => pair[0] <= seed && seed < pair[0] + pair[1]))
			.Min(seed => maps.Aggregate(seed, MapForward));
	}

	private static long MapForward(long value, List<(long Dst, long Src, long Len)> map)
	{
		foreach (var (dst, src, len) in map)
		{
			if (src <= value && value < src + len)
			{
				return dst - src + value;
			}
		}

		return value;
	}

	private static long MapReverse(long value, List<(long Dst, long Src, long Len)> map)
	{
		foreach (var (dst, src, len) in map)
		{
			if (dst <= value && value < dst + len)
			{
				return src - dst + value;
			}
		}

		return value;
	}

	private (List<long> Seeds, List<List<(long Dst, long Src, long Len)>> Maps) Parse()
	{
		var seeds = input[0].Split(' ').Skip(1).Select(x => x.ToInt64()).ToList();
		var maps = new List<List<(long, long, long)>>();

		foreach (var line in input.Skip(1))
		{
			if (line.Length is 0)
			{
				continue;
			}
			else if (line.EndsWith(':'))
			{
				maps.Add([]);
			}
			else
			{
				var vals = line.Split(' ').ToInt64();
				maps[^1].Add((vals[0], vals[1], vals[2]));
			}
		}

		return (seeds, maps);
	}
}
