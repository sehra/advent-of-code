namespace AdventOfCode.Year2020;

public class Day22
{
	private readonly string[] _input;

	public Day22(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var (player1, player2) = Parse();

		while (player1.Count > 0 && player2.Count > 0)
		{
			var card1 = player1.Dequeue();
			var card2 = player2.Dequeue();

			if (card1 > card2)
			{
				player1.Enqueue(card1);
				player1.Enqueue(card2);
			}
			else
			{
				player2.Enqueue(card2);
				player2.Enqueue(card1);
			}
		}

		return Result(player1, player2).Score;
	}

	public int Part2()
	{
		var (player1, player2) = Parse();

		return PlayGame(player1, player2).Score;

		static (int Winner, int Score) PlayGame(Queue<int> player1, Queue<int> player2)
		{
			var seen = new HashSet<int[]>(new Comparer());

			while (player1.Count > 0 && player2.Count > 0)
			{
				if (!seen.Add(MakeState(player1, player2)))
				{
					return (1, 0);
				}

				var card1 = player1.Dequeue();
				var card2 = player2.Dequeue();
				var winner = 0;

				if (player1.Count >= card1 && player2.Count >= card2)
				{
					winner = PlayGame(new(player1.Take(card1)), new(player2.Take(card2))).Winner;
				}
				else
				{
					winner = card1 > card2 ? 1 : 2;
				}

				if (winner == 1)
				{
					player1.Enqueue(card1);
					player1.Enqueue(card2);
				}
				else
				{
					player2.Enqueue(card2);
					player2.Enqueue(card1);
				}
			}

			return Result(player1, player2);
		}

		static int[] MakeState(Queue<int> player1, Queue<int> player2)
		{
			var state = new int[player1.Count + 1 + player2.Count];
			player1.CopyTo(state, 0);
			player2.CopyTo(state, player1.Count + 1);

			return state;
		}
	}

	private (Queue<int>, Queue<int>) Parse()
	{
		var player1 = new Queue<int>();
		var player2 = new Queue<int>();
		var current = player1;

		foreach (var line in _input)
		{
			if (line.StartsWith("Player 1"))
			{
				continue;
			}
			else if (line.StartsWith("Player 2"))
			{
				current = player2;
				continue;
			}

			current.Enqueue(line.ToInt32());
		}

		return (player1, player2);
	}

	private static (int Winner, int Score) Result(Queue<int> player1, Queue<int> player2)
	{
		var (winner, cards) = player1.Count > 0 ? (1, player1) : (2, player2);
		var score = cards.Reverse().Select((v, i) => v * (i + 1)).Sum();

		return (winner, score);
	}

	private class Comparer : IEqualityComparer<int[]>
	{
		public bool Equals(int[] x, int[] y)
		{
			return x.AsSpan().SequenceEqual(y);
		}

		public int GetHashCode(int[] arr)
		{
			var hash = 0;

			for (int i = 0; i < arr.Length; i++)
			{
				hash = HashCode.Combine(hash, arr[i]);
			}

			return hash;
		}
	}
}
