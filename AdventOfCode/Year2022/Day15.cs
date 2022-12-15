namespace AdventOfCode.Year2022;

public class Day15
{
	private readonly string[] _input;

	public Day15(string[] input)
	{
		_input = input;
	}

	public int Part1(int target = 2_000_000)
	{
		var report = Parse();
		var (min, max) = Ranges(report, target).Single();

		return max - min;
	}

	public long Part2(int limit = 4_000_000)
	{
		var report = Parse();

		for (int y = 0; y <= limit; y++)
		{
			var ranges = Ranges(report, y);

			if (ranges.Any(range => range.Min <= 0 && range.Max >= limit))
			{
				continue;
			}

			var x = ranges[0].Max + 1L;

			return x * 4_000_000 + y;
		}

		throw new Exception("not found");
	}

	private static List<(int Min, int Max)> Ranges(List<(Point Sensor, Point Beacon)> report, int target)
	{
		var ranges = new List<(int Min, int Max)>();

		foreach (var (sensor, beacon) in report)
		{
			var dx = Math.Abs(beacon.X - sensor.X);
			var dy = Math.Abs(beacon.Y - sensor.Y);
			var delta = dx + dy;

			if (Math.Abs(target - sensor.Y) < delta)
			{
				var dist = delta - Math.Abs(target - sensor.Y);
				ranges.Add((sensor.X - dist, sensor.X + dist));
			}
		}

		ranges.Sort();

		for (int i = 0; i < ranges.Count - 1;)
		{
			if (ranges[i].Max + 1 >= ranges[i + 1].Min)
			{
				ranges[i] = ranges[i] with { Max = Math.Max(ranges[i].Max, ranges[i + 1].Max) };
				ranges.RemoveAt(i + 1);
			}
			else
			{
				i++;
			}
		}

		return ranges;
	}

	private readonly record struct Point(int X, int Y);

	private List<(Point Sensor, Point Beacon)> Parse()
	{
		var result = new List<(Point Sensor, Point Beacon)>();

		foreach (var line in _input)
		{
			var match = Regex.Match(line, @"Sensor at x=(-?\d+), y=(-?\d+): closest beacon is at x=(-?\d+), y=(-?\d+)");
			var sensor = new Point(match.Groups[1].Value.ToInt32(), match.Groups[2].Value.ToInt32());
			var beacon = new Point(match.Groups[3].Value.ToInt32(), match.Groups[4].Value.ToInt32());
			result.Add((sensor, beacon));
		}

		return result;
	}
}
