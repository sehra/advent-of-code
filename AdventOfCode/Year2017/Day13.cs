namespace AdventOfCode.Year2017;

public class Day13(string[] input)
{
	public int Part1()
	{
		var firewall = Parse();
		var severity = 0;

		for (int depth = 0, max = firewall.Keys.Max(); depth <= max; depth++)
		{
			if (!firewall.TryGetValue(depth, out var range))
			{
				continue;
			}

			if (depth % (range * 2 - 2) is 0)
			{
				severity += depth * range;
			}
		}

		return severity;
	}

	public int Part2()
	{
		var firewall = Parse();

		for (int delay = 0; true; delay++)
		{
			if (Attempt(delay))
			{
				return delay;
			}
		}

		bool Attempt(int delay)
		{
			for (int depth = 0, max = firewall.Keys.Max(); depth <= max; depth++)
			{
				if (!firewall.TryGetValue(depth, out var range))
				{
					continue;
				}

				if ((delay + depth) % (range * 2 - 2) is 0)
				{
					return false;
				}
			}

			return true;
		}
	}

	private Dictionary<int, int> Parse() => input
		.Select(line => line.Split(':').ToInt32())
		.ToDictionary(line => line[0], line => line[1]);
}
