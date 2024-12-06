namespace AdventOfCode.Year2024;

using Point = (int Row, int Col);

public class Day6(string[] input)
{
	public int Part1()
	{
		return Walk(Find(), (-1, -1)).Path.Distinct(step => step.Pos).Count();
	}

	public int Part2()
	{
		var guard = Find();
		var (path, _) = Walk(guard, (-1, -1));
		var count = 0;

		foreach (var step in path.Distinct(step => step.Pos))
		{
			if (step.Pos == guard.Pos)
			{
				continue;
			}

			var (_, loop) = Walk(guard, step.Pos);

			if (loop)
			{
				count++;
			}
		}

		return count;
	}

	private Guard Find()
	{
		for (int r = 0; r < input.Length; r++)
		{
			if (input[r].IndexOf('^') is var c && c is not -1)
			{
				return new Guard(r, c, 0);
			}
		}

		throw new Exception("not found");
	}

	private (HashSet<Guard> Path, bool Loop) Walk(Guard guard, Point obstacle)
	{
		var path = new HashSet<Guard>() { guard };

		while (true)
		{
			var next = guard.Step();

			if (next.Row < 0 || next.Row >= input.Length ||
				next.Col < 0 || next.Col >= input[next.Row].Length)
			{
				return (path, false);
			}
			else if (input[next.Row][next.Col] is '#' || next.Pos == obstacle)
			{
				guard = guard.Turn();
			}
			else if (!path.Add(guard = next))
			{
				return (path, true);
			}
		}
	}

	private readonly record struct Guard(int Row, int Col, int Dir)
	{
		public Point Pos => (Row, Col);

		public Guard Step() => Dir switch
		{
			0 => this with { Row = Row - 1 },
			1 => this with { Col = Col + 1 },
			2 => this with { Row = Row + 1 },
			3 => this with { Col = Col - 1 },
			_ => throw new Exception("dir?"),
		};

		public Guard Turn() => this with { Dir = (Dir + 1) % 4 };
	}
}
