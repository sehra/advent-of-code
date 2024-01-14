namespace AdventOfCode.Year2018;

public class Day9(string input)
{
	public long Part1()
	{
		var (players, highest) = Parse();

		return Solve(players, highest);
	}

	public long Part2()
	{
		var (players, highest) = Parse();

		return Solve(players, highest * 100);
	}

	private static long Solve(int players, int highest)
	{
		var elves = new long[players];
		var current = new Marble(0);
		current.Next = current;
		current.Prev = current;

		for (int i = 1, elf = 0; i <= highest; i++, elf++)
		{
			if (i % 23 is 0)
			{
				var remove = current.Prev.Prev.Prev.Prev.Prev.Prev.Prev;
				var next = remove.Next;
				var prev = remove.Prev;
				prev.Next = next;
				next.Prev = prev;
				elves[elf % players] += i + remove.Value;
				current = next;
			}
			else
			{
				var one = current.Next;
				var two = current.Next.Next;
				var marble = new Marble(i)
				{
					Prev = one,
					Next = two,
				};
				one.Next = marble;
				two.Prev = marble;
				current = marble;
			}
		}

		return elves.Max();
	}

	private class Marble(int value)
	{
		public int Value { get; } = value;
		public Marble Prev { get; set; }
		public Marble Next { get; set; }
	}

	private (int, int) Parse()
	{
		var split = input.Split();
		var players = split[0].ToInt32();
		var highest = split[6].ToInt32();

		return (players, highest);
	}
}
