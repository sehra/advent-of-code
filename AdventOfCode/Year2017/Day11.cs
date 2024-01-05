namespace AdventOfCode.Year2017;

public class Day11(string input)
{
	public int Part1() => Distances().Last();

	public int Part2() => Distances().Max();

	private IEnumerable<int> Distances() => input
		.Split(',')
		.Scan(new Hexagon(), (pos, dir) => pos.Step(dir))
		.Select(pos => (Math.Abs(pos.Q) + Math.Abs(pos.R) + Math.Abs(pos.S)) / 2);

	// https://www.redblobgames.com/grids/hexagons/
	private readonly record struct Hexagon(int Q, int R, int S)
	{
		public Hexagon Step(string dir) => dir switch
		{
			"n" => new(Q, R - 1, S + 1),
			"ne" => new(Q + 1, R - 1, S),
			"nw" => new(Q - 1, R, S + 1),
			"s" => new(Q, R + 1, S - 1),
			"se" => new(Q + 1, R, S - 1),
			"sw" => new(Q - 1, R + 1, S),
			_ => throw new Exception("dir?"),
		};
	}
}
