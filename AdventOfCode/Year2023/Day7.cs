namespace AdventOfCode.Year2023;

public class Day7(string[] input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool jokers)
	{
		var hands = new List<long>(input.Length);

		foreach (var line in input)
		{
			var score = Score(line.AsSpan(0, 5), jokers);
			var order = Order(line.AsSpan(0, 5), jokers);
			var bid = line.AsSpan(6).ToInt64();
			hands.Add(score << 52 | order << 32 | bid);
		}

		hands.Sort();

		return hands.Index(1).Sum(x => x.Key * (int)(x.Value & uint.MaxValue));
	}

	private long Score(ReadOnlySpan<char> hand, bool jokers)
	{
		Span<int> counts = stackalloc int[16];

		for (int i = 0; i < hand.Length; i++)
		{
			var card = hand[i] switch
			{
				'A' => 14,
				'K' => 13,
				'Q' => 12,
				'J' => jokers ? 0 : 11,
				'T' => 10,
				var c => c - '0',
			};

			if (card > 0)
			{
				counts[card]++;
			}
		}

		counts.Sort((a, b) => b - a);
		counts[0] += jokers ? hand.Count('J') : 0;

		return counts switch
		{
			[5, ..] => 6,
			[4, ..] => 5,
			[3, 2, ..] => 4,
			[3, ..] => 3,
			[2, 2, ..] => 2,
			[2, ..] => 1,
			_ => 0,
		};
	}

	private static long Order(ReadOnlySpan<char> hand, bool jokers)
	{
		var values = jokers ? "J23456789TQKA" : "23456789TJQKA";
		var order = 0;

		for (int i = 0; i < hand.Length; i++)
		{
			order <<= 4;
			order |= values.IndexOf(hand[i]);
		}

		return order;
	}
}
