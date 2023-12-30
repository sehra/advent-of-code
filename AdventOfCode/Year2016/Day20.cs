namespace AdventOfCode.Year2016;

public class Day20(string[] input)
{
	public uint Part1(uint min = UInt32.MinValue, uint max = UInt32.MaxValue)
	{
		foreach (var range in Parse().OrderBy(r => r.Min).ThenBy(r => r.Max))
		{
			if (range.Min <= min && min <= range.Max)
			{
				min = range.Max + 1;
			}
		}

		return min;
	}

	public long Part2(uint min = UInt32.MinValue, uint max = UInt32.MaxValue)
	{
		var allowed = new HashSet<(uint Min, uint Max)>()
		{
			(min, max)
		};

		foreach (var block in Parse())
		{
			foreach (var allow in allowed.ToArray())
			{
				// |  block  |
				//  | allow |
				if (block.Min <= allow.Min && allow.Max <= block.Max)
				{
					allowed.Remove(allow);
				}
				//  | block |
				// |  allow  |
				else if (allow.Min <= block.Min && block.Max <= allow.Max)
				{
					allowed.Remove(allow);

					if (block.Min > min && allow.Min <= block.Min - 1)
					{
						allowed.Add((allow.Min, block.Min - 1));
					}

					if (block.Max < max && block.Max + 1 <= allow.Max)
					{
						allowed.Add((block.Max + 1, allow.Max));
					}
				}               
				// | block |
				//  | allow |
				else if (block.Min < allow.Min && allow.Min <= block.Max)
				{
					allowed.Remove(allow);

					if (block.Max < max && block.Max + 1 <= allow.Max)
					{
						allowed.Add((block.Max + 1, allow.Max));
					}
				}
				//  | block |
				// | allow |
				else if (allow.Min <= block.Min && block.Min <= allow.Max)
				{
					allowed.Remove(allow);

					if (block.Min > min && allow.Min <= block.Min - 1)
					{
						allowed.Add((allow.Min, block.Min - 1));
					}
				}
			}
		}

		return allowed.Sum(r => r.Max - r.Min + 1);
	}

	private (uint Min, uint Max)[] Parse() => input
		.Select(line => line.Split('-'))
		.Select(line => (line[0].ToUInt32(), line[1].ToUInt32()))
		.ToArray();
}
