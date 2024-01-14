namespace AdventOfCode.Year2018;

public class Day14(string input)
{
	public string Part1()
	{
		var rounds = input.ToInt32();
		var board = new List<int>() { 3, 7 };
		var elf1 = 0;
		var elf2 = 1;

		for (int i = 0; i < rounds + 10; i++)
		{
			var score = board[elf1] + board[elf2];

			if (score < 10)
			{
				board.Add(score);
			}
			else
			{
				board.Add(1);
				board.Add(score - 10);
			}

			elf1 = (elf1 + 1 + board[elf1]) % board.Count;
			elf2 = (elf2 + 1 + board[elf2]) % board.Count;
		}

		return board.Skip(rounds).Take(10)
			.ToString((sb, r) => sb.Append(r));
	}

	public int Part2()
	{
		var match = input.Select(c => c - '0').ToArray();
		var board = new List<int>() { 3, 7 };
		var elf1 = 0;
		var elf2 = 1;

		while (true)
		{
			var score = board[elf1] + board[elf2];

			if (score < 10)
			{
				board.Add(score);
			}
			else
			{
				board.Add(1);
				board.Add(score - 10);
			}

			elf1 = (elf1 + 1 + board[elf1]) % board.Count;
			elf2 = (elf2 + 1 + board[elf2]) % board.Count;

			if (score >= 10 && board.TakeLast(match.Length + 1).Take(match.Length).SequenceEqual(match))
			{
				return board.Count - match.Length - 1;
			}

			if (board.TakeLast(match.Length).SequenceEqual(match))
			{
				return board.Count - match.Length;
			}
		}
	}
}
