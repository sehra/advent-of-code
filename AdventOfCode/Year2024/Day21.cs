namespace AdventOfCode.Year2024;

using Pos = (int R, int C);
using Cache = Dictionary<((int, int), (int, int), int), long>;

public class Day21(string[] input)
{
	public long Part1() => Solve(2);

	public long Part2() => Solve(25);

	private long Solve(int depth)
	{
		var total = 0L;
		var cache = new Cache();

		foreach (var code in input)
		{
			var count = NumpadPresses(code, depth, cache);
			total += count * code.AsSpan(0, 3).ToInt64();
		}

		return total;
	}

	private static long NumpadPresses(string code, int depth, Cache cache)
	{
		var count = 0L;
		var curr = (3, 2); // numpad A

		foreach (var c in code)
		{
			var next = Math.DivRem("789456123.0A".IndexOf(c), 3);
			count += NumpadPresses(curr, next, depth, cache);
			curr = next;
		}

		return count;
	}

	private static long NumpadPresses(Pos beg, Pos end, int depth, Cache cache)
	{
		var best = long.MaxValue;
		var work = new Queue<(Pos, string)>();
		work.Enqueue((beg, ""));

		while (work.TryDequeue(out var state))
		{
			var (pos, path) = state;

			if (pos == (3, 0)) // numpad gap
			{
				continue;
			}

			if (pos == end)
			{
				best = Math.Min(best, DirpadPresses(path + 'A', depth, cache));
				continue;
			}

			QueueNextMoves(work, pos, end, path);
		}

		return best;
	}

	private static long DirpadPresses(string code, int depth, Cache cache)
	{
		if (depth is 0)
		{
			return code.Length;
		}

		var count = 0L;
		var curr = (0, 2); // dirpad A

		foreach (var c in code)
		{
			var next = Math.DivRem(".^A<v>".IndexOf(c), 3);
			count += DirpadPresses(curr, next, depth, cache);
			curr = next;
		}

		return count;
	}

	private static long DirpadPresses(Pos beg, Pos end, int depth, Cache cache)
	{
		if (cache.TryGetValue((beg, end, depth), out var result))
		{
			return result;
		}

		var best = long.MaxValue;
		var work = new Queue<(Pos, string)>();
		work.Enqueue((beg, ""));

		while (work.TryDequeue(out var state))
		{
			var (pos, path) = state;

			if (pos == (0, 0)) // dirpad gap
			{
				continue;
			}

			if (pos == end)
			{
				best = Math.Min(best, DirpadPresses(path + 'A', depth - 1, cache));
				continue;
			}

			QueueNextMoves(work, pos, end, path);
		}

		return cache[(beg, end, depth)] = best;
	}

	private static void QueueNextMoves(Queue<(Pos, string)> queue, Pos pos, Pos end, string path)
	{
		if (end.R < pos.R)
		{
			queue.Enqueue((pos with { R = pos.R - 1 }, path + '^'));
		}
		else if (pos.R < end.R)
		{
			queue.Enqueue((pos with { R = pos.R + 1 }, path + 'v'));
		}

		if (end.C < pos.C)
		{
			queue.Enqueue((pos with { C = pos.C - 1 }, path + '<'));
		}
		else if (pos.C < end.C)
		{
			queue.Enqueue((pos with { C = pos.C + 1 }, path + '>'));
		}
	}
}
