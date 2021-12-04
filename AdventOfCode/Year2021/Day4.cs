namespace AdventOfCode.Year2021;

public class Day4
{
	private readonly string[] _input;

	public Day4(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var (calls, boards) = Parse();
		var called = new HashSet<int>();

		foreach (var call in calls)
		{
			called.Add(call);

			foreach (var board in boards)
			{
				if (HasBingo(board, called))
				{
					var all = board.AsEnumerable().Select(x => x.Value);
					var sum = all.Except(called).Sum();

					return sum * call;
				}
			}
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var (calls, boards) = Parse();
		var called = new HashSet<int>();

		foreach (var call in calls)
		{
			called.Add(call);
			var bingos = new List<int[,]>();

			foreach (var board in boards)
			{
				if (HasBingo(board, called))
				{
					bingos.Add(board);

					if (boards.Count is 1)
					{
						var all = board.AsEnumerable().Select(x => x.Value);
						var sum = all.Except(called).Sum();

						return sum * call;
					}
				}
			}

			foreach (var board in bingos)
			{
				boards.Remove(board);
			}
		}

		throw new Exception("not found");
	}

	private static bool HasBingo(int[,] board, HashSet<int> called)
	{
		for (int i = 0; i < 5; i++)
		{
			if (called.Contains(board[i, 0]) &&
				called.Contains(board[i, 1]) &&
				called.Contains(board[i, 2]) &&
				called.Contains(board[i, 3]) &&
				called.Contains(board[i, 4]))
			{
				return true;
			}

			if (called.Contains(board[0, i]) &&
				called.Contains(board[1, i]) &&
				called.Contains(board[2, i]) &&
				called.Contains(board[3, i]) &&
				called.Contains(board[4, i]))
			{
				return true;
			}
		}

		return false;
	}

	private (int[] Calls, List<int[,]> Boards) Parse()
	{
		var calls = _input[0].Split(',').Select(Int32.Parse).ToArray();
		var boards = new List<int[,]>();

		foreach (var chunk in _input.Skip(1).Chunk(5))
		{
			var board = new int[5, 5];

			for (var i = 0; i < 5; i++)
			{
				var line = chunk[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
				board[i, 0] = line[0].ToInt32();
				board[i, 1] = line[1].ToInt32();
				board[i, 2] = line[2].ToInt32();
				board[i, 3] = line[3].ToInt32();
				board[i, 4] = line[4].ToInt32();
			}

			boards.Add(board);
		}

		return (calls, boards);
	}
}
