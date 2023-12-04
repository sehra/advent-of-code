namespace AdventOfCode.Year2023;

public class Day4(string[] input)
{
	public int Part1() => Parse()
		.Where(count => count > 0)
		.Sum(count => 1 << (count - 1));

	public int Part2()
	{
		var games = Parse();
		var cards = Enumerable.Repeat(1, games.Length).ToArray();

		for (int src = 0; src < games.Length; src++)
		{
			for (int num = games[src], dst = src + 1; num > 0; num--, dst++)
			{
				cards[dst] += cards[src];
			}
		}

		return cards.Sum();
	}

	private int[] Parse() => input
		.Select(line => line.Split(':', '|'))
		.Select(line => new
		{
			Want = line[1].Split(' ', StringSplitOptions.RemoveEmptyEntries),
			Have = line[2].Split(' ', StringSplitOptions.RemoveEmptyEntries),
		})
		.Select(card => card.Want.Intersect(card.Have).Count())
		.ToArray();
}
