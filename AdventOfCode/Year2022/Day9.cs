namespace AdventOfCode.Year2022;

public class Day9
{
	private readonly string[] _input;

	public Day9(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var head = new Point(0, 0);
		var tail = head;
		var seen = new HashSet<Point>() { tail };

		foreach (var line in _input)
		{
			var direction = line[0];
			var steps = line.AsSpan(2).ToInt32();

			for (int i = 0; i < steps; i++)
			{
				head = head.Move(direction);
				tail = tail.MoveTowards(head);
				seen.Add(tail);
			}
		}

		return seen.Count;
	}

	public int Part2()
	{
		var head = new Point(0, 0);
		var tail = Enumerable.Repeat(head, 9).ToArray();
		var seen = new HashSet<Point>() { tail[^1] };

		foreach (var line in _input)
		{
			var direction = line[0];
			var steps = line.AsSpan(2).ToInt32();

			for (int i = 0; i < steps; i++)
			{
				head = head.Move(direction);
				tail[0] = tail[0].MoveTowards(head);

				for (int j = 1; j < tail.Length; j++)
				{
					tail[j] = tail[j].MoveTowards(tail[j - 1]);
				}

				seen.Add(tail[^1]);
			}
		}

		return seen.Count;
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Move(char direction) => direction switch
		{
			'U' => this with { Y = Y + 1 },
			'D' => this with { Y = Y - 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("direction?"),
		};

		public Point MoveTowards(Point other) => (other.X - X, other.Y - Y) switch
		{
			(-2, 0) => this with { X = X - 1 },
			(+2, 0) => this with { X = X + 1 },
			(0, -2) => this with { Y = Y - 1 },
			(0, +2) => this with { Y = Y + 1 },
			(-2, -1) => new(X - 1, Y - 1),
			(-2, +1) => new(X - 1, Y + 1),
			(+2, -1) => new(X + 1, Y - 1),
			(+2, +1) => new(X + 1, Y + 1),
			(-1, -2) => new(X - 1, Y - 1),
			(+1, -2) => new(X + 1, Y - 1),
			(-1, +2) => new(X - 1, Y + 1),
			(+1, +2) => new(X + 1, Y + 1),
			(-2, -2) => new(X - 1, Y - 1),
			(-2, +2) => new(X - 1, Y + 1),
			(+2, -2) => new(X + 1, Y - 1),
			(+2, +2) => new(X + 1, Y + 1),
			_ => this,
		};
	}
}
