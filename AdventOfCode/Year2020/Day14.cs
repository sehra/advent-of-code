namespace AdventOfCode.Year2020;

public class Day14
{
	private readonly string[] _input;

	public Day14(string input)
	{
		_input = input.ToLines();
	}

	public long Part1()
	{
		var memory = new Dictionary<ulong, long>();
		var mask = "";

		foreach (var line in _input)
		{
			var match = Regex.Match(line, @"^mask = ([01X]+)|mem.(\d+). = (\d+)$");

			if (match.Groups[1].Success)
			{
				mask = match.Groups[1].Value;
			}
			else if (match.Groups[2].Success)
			{
				var address = match.Groups[2].Value.ToUInt64();
				var value = match.Groups[3].Value.ToInt64();

				for (int i = 0; i < mask.Length; i++)
				{
					var keep = Convert.ToInt64(mask.Replace('1', '0').Replace('X', '1'), 2);
					var replace = Convert.ToInt64(mask.Replace('X', '0'), 2);
					memory[address] = (value & keep) | replace;
				}
			}
		}

		return memory.Values.Sum();
	}

	public long Part2()
	{
		var memory = new Dictionary<ulong, long>();

		var zbits = 0UL;
		var obits = 0UL;
		var xbits = Array.Empty<int>();

		foreach (var line in _input)
		{
			var match = Regex.Match(line, @"^mask = ([01X]+)|mem.(\d+). = (\d+)$");

			if (match.Groups[1].Success)
			{
				var mask = match.Groups[1].Value.Reverse().Select((b, i) => (b, i));
				zbits = mask.Where(x => x.b is '0').Aggregate(0UL, (v, x) => v | 1UL << x.i);
				obits = mask.Where(x => x.b is '1').Aggregate(0UL, (v, x) => v | 1UL << x.i);
				xbits = mask.Where(x => x.b is 'X').Select(x => x.i).ToArray();
			}
			else if (match.Groups[2].Success)
			{
				var address = match.Groups[2].Value.ToUInt64();
				var value = match.Groups[3].Value.ToInt64();

				for (int i = 0, max = (int)Math.Pow(2, xbits.Length); i < max; i++)
				{
					var fbits = 0UL;

					for (int j = 0; j < xbits.Length; j++)
					{
						if (((i >> j) & 1) == 1)
						{
							fbits |= 1UL << xbits[j];
						}
					}

					memory[(address & zbits) | obits | fbits] = value;
				}
			}
		}

		return memory.Values.Sum();
	}
}
