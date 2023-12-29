namespace AdventOfCode.Year2015;

public class Day3(string input)
{
	public int Part1() => input
		.Scan(new Point(), (p, c) => p + c)
		.Append(default)
		.Distinct()
		.Count();

	public int Part2() => input
		.Chunk(2)
		.Scan((A: new Point(), B: new Point()), (p, c) => (p.A + c[0], p.B + c[1]))
		.SelectMany(x => new[] { x.A, x.B })
		.Append(default)
		.Distinct()
		.Count();

	private readonly record struct Point(int X, int Y)
	{
		public static Point operator +(Point p, char c) => c switch
		{
			'>' => p with { X = p.X + 1 },
			'<' => p with { X = p.X - 1 },
			'^' => p with { Y = p.Y + 1 },
			'v' => p with { Y = p.Y - 1 },
			_ => throw new Exception("dir?"),
		};
	}
}
