namespace AdventOfCode.Year2023;

public class Day7(string[] input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool jokers) => Parse(jokers)
		.Order()
		.Index(1)
		.Sum(kv => kv.Key * kv.Value.Bid);

	private int Score(string hand, bool jokers)
	{
		var counts = (jokers ? hand.Where(c => c is not 'J') : hand)
			.GroupBy(c => c)
			.Select(g => g.Count())
			.OrderDescending()
			.ToArray();

		if (jokers)
		{
			var extra = hand.Count(c => c is 'J');

			if (counts.Length is 0)
			{
				counts = [5];
			}
			else
			{
				counts[0] += extra;
			}
		}

		return counts switch
		{
			[5] => 6,
			[4, ..] => 5,
			[3, 2] => 4,
			[3, ..] => 3,
			[2, 2, ..] => 2,
			[2, ..] => 1,
			_ => 0,
		};
	}

	private readonly record struct Hand(string Cards, bool Jokers) : IComparable<Hand>
	{
		public int CompareTo(Hand other) => Order().CompareTo(other.Order());

		private (int, int, int, int, int) Order()
		{
			var values = Jokers ? "J23456789TQKA" : "23456789TJQKA";

			return (
				values.IndexOf(Cards[0]),
				values.IndexOf(Cards[1]),
				values.IndexOf(Cards[2]),
				values.IndexOf(Cards[3]),
				values.IndexOf(Cards[4])
			);
		}
	}

	private (int Score, Hand, int Bid)[] Parse(bool jokers) => input
		.Select(line => line.Split(' '))
		.Select(line => (Score(line[0], jokers), new Hand(line[0], jokers), line[1].ToInt32()))
		.ToArray();
}
