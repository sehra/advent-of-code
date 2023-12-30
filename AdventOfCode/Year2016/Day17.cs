using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016;

public class Day17(string input)
{
	public string Part1()
	{
		var goal = new Point(3, 3);
		var work = new PriorityQueue<(Point Pos, char[] Path), int>();
		work.Enqueue((new(0, 0), []), 0);

		while (work.TryDequeue(out var state, out var steps))
		{
			var (curr, path) = state;

			if (curr == goal)
			{
				return new string(path);
			}

			foreach (var dir in "UDLR")
			{
				var next = curr.Step(dir);

				if (0 <= next.X && next.X <= 3 &&
					0 <= next.Y && next.Y <= 3 &&
					IsOpen(dir, path))
				{
					work.Enqueue((next, [.. path, dir]), steps + 1);
				}
			}
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var best = 0;
		var goal = new Point(3, 3);
		var work = new PriorityQueue<(Point Pos, char[] Path), int>();
		work.Enqueue((new(0, 0), []), 0);

		while (work.TryDequeue(out var state, out var steps))
		{
			var (curr, path) = state;

			if (curr == goal)
			{
				best = Math.Max(best, path.Length);
				continue;
			}

			foreach (var dir in "UDLR")
			{
				var next = curr.Step(dir);

				if (0 <= next.X && next.X <= 3 &&
					0 <= next.Y && next.Y <= 3 &&
					IsOpen(dir, path))
				{
					work.Enqueue((next, [.. path, dir]), steps + 1);
				}
			}
		}

		return best;

	}

	bool IsOpen(char dir, char[] path) => (dir, GetHash(new(path))) switch
	{
		('U', [var a, ..]) when a - 'A' > 0 => true,
		('D', [_, var b, ..]) when b - 'A' > 0 => true,
		('L', [_, _, var c, ..]) when c - 'A' > 0 => true,
		('R', [_, _, _, var d, ..]) when d - 'A' > 0 => true,
		_ => false,
	};

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => this with { Y = Y - 1 },
			'D' => this with { Y = Y + 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private string GetHash(string value)
	{
		var data = $"{input}{value}";
		var hash = MD5.HashData(Encoding.ASCII.GetBytes(data));

		return Convert.ToHexString(hash);
	}
}
