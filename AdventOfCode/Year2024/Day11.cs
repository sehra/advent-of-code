namespace AdventOfCode.Year2024;

public class Day11(string input)
{
	public long Part1() => Solve(25);

	public long Part2() => Solve(75);

	private long Solve(int blinks)
	{
		var cache = new Dictionary<(long, int), long>();

		return input.Split().ToInt64().Sum(stone => Blink(stone, blinks));

		long Blink(long stone, int blinks)
		{
			if (cache.TryGetValue((stone, blinks), out var value))
			{
				return value;
			}

			if (blinks is 0)
			{
				return 1;
			}

			if (stone is 0)
			{
				return Cache(Blink(1, blinks - 1));
			}
			else if (Digits(stone) is var d && d % 2 is 0)
			{
				var s = stone.ToString().AsSpan();
				var l = s[..(d / 2)].ToInt64();
				var r = s[(d / 2)..].ToInt64();

				return Cache(Blink(l, blinks - 1) + Blink(r, blinks - 1));
			}
			else
			{
				return Cache(Blink(stone * 2024, blinks - 1));
			}

			long Cache(long value) => cache[(stone, blinks)] = value;

			static int Digits(long v)
			{
				var count = 0;

				while (v > 0)
				{
					v /= 10;
					count++;
				}

				return count;
			}
		}
	}
}
