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

	private static long MapForward(long value, List<Range> map) => map
		.Where(r => r.Src <= value && value < r.Src + r.Len)
		.Select(r => r.Dst - r.Src + value)
		.SingleOrDefault(value);

	private static long MapReverse(long value, List<Range> map) => map
		.Where(r => r.Dst <= value && value < r.Dst + r.Len)
		.Select(r => r.Src - r.Dst + value)
		.SingleOrDefault(value);

	private readonly record struct Range(long Dst, long Src, long Len)
	{
		public static Range Parse(string value)
		{
			var vals = value.Split(' ').ToInt64();
			return new(vals[0], vals[1], vals[2]);
		}
	}

	private (List<long> Seeds, List<List<Range>> Maps) Parse()
	{
		var seeds = input[0].Split(' ').Skip(1).Parse<long>().ToList();
		var maps = input.Skip(1)
			.Where(line => line.Length > 0)
			.GroupWhile((_, line) => !line.EndsWith(':'))
			.Select(lines => lines.Skip(1).Select(Range.Parse).ToList())
			.ToList();

		return (seeds, maps);
	}
}
