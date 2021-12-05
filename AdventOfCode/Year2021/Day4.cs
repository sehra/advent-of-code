namespace AdventOfCode.Year2021;

public class Day4
{
	private readonly string[] _input;

	public Day4(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var (calls, boards) = Parse();
		var drawn = new HashSet<int>();

		foreach (var call in calls)
		{
			drawn.Add(call);

			foreach (var board in boards)
			{
				if (HasBingo(board, drawn))
				{
					var all = board.AsEnumerable().Select(x => x.Value);
					var sum = all.Except(drawn).Sum();

					return sum * call;
				}
			}
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var (calls, boards) = Parse();
		var drawn = new HashSet<int>();

		foreach (var call in calls)
		{
			drawn.Add(call);
			var bingos = new List<int[,]>();

			foreach (var board in boards)
			{
				if (HasBingo(board, drawn))
				{
					bingos.Add(board);

					if (boards.Count is 1)
					{
						var all = board.AsEnumerable().Select(x => x.Value);
						var sum = all.Except(drawn).Sum();

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

	private static bool HasBingo(int[,] board, HashSet<int> drawn)
	{
		for (int i = 0; i < 5; i++)
		{
			if (drawn.Contains(board[i, 0]) &&
				drawn.Contains(board[i, 1]) &&
				drawn.Contains(board[i, 2]) &&
				drawn.Contains(board[i, 3]) &&
				drawn.Contains(board[i, 4]))
			{
				return true;
			}

			if (drawn.Contains(board[0, i]) &&
				drawn.Contains(board[1, i]) &&
				drawn.Contains(board[2, i]) &&
				drawn.Contains(board[3, i]) &&
				drawn.Contains(board[4, i]))
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
