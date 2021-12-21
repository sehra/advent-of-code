using static System.Linq.Enumerable;

namespace AdventOfCode.Year2021;

public class Day21
{
	private readonly string[] _input;

	public Day21(string[] input)
	{
		_input = input;
	}

	public long Part1()
	{
		var (player1, player2) = Parse();
		var die = Range(1, 100).Repeat().Select((n, i) => (n, i + 1)).GetEnumerator();

		while (true)
		{
			var roll = Roll(die);
			player1 += roll;

			if (player1.Score >= 1000)
			{
				return player2.Score * roll.Count;
			}

			roll = Roll(die);
			player2 += roll;

			if (player2.Score >= 1000)
			{
				return player1.Score * roll.Count;
			}
		}

		static Roll Roll(IEnumerator<(int Roll, int Count)> die)
		{
			var roll1 = die.Next();
			var roll2 = die.Next();
			var roll3 = die.Next();

			return new(roll1.Roll, roll2.Roll, roll3.Roll, roll3.Count);
		}
	}

	public long Part2()
	{
		var (player1, player2) = Parse();
		var outcomes = new Dictionary<(Player, Player), Outcome>();

		return Play(player1, player2).Max();

		Outcome Play(Player player1, Player player2)
		{
			if (player2.Score >= 21)
			{
				return new(0, 1);
			}

			if (outcomes.TryGetValue((player1, player2), out var outcome))
			{
				return outcome;
			}

			var rolls =
				from roll1 in Range(1, 3)
				from roll2 in Range(1, 3)
				from roll3 in Range(1, 3)
				select new Roll(roll1, roll2, roll3);

			foreach (var roll in rolls)
			{
				outcome += Play(player2, player1 + roll);
			}

			outcomes.TryAdd((player1, player2), outcome);

			return outcome;
		}
	}

	private (Player, Player) Parse()
	{
		var player1 = _input[0][^1] - '0';
		var player2 = _input[1][^1] - '0';

		return (new(player1), new(player2));
	}

	private readonly record struct Player(int Space, long Score = 0)
	{
		public static Player operator +(Player player, Roll roll)
		{
			var space = player.Space + roll.Roll1 + roll.Roll2 + roll.Roll3;
			space = (space - 1) % 10 + 1;

			return new(space, player.Score + space);
		}
	}

	private readonly record struct Roll(int Roll1, int Roll2, int Roll3, int Count = 0);

	private readonly record struct Outcome(long Player1, long Player2)
	{
		// careful
		public static Outcome operator +(Outcome a, Outcome b) =>
			new(a.Player1 + b.Player2, a.Player2 + b.Player1);

		public long Max() => Math.Max(Player1, Player2);
	}
}
