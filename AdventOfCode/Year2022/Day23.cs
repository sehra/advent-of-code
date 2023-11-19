namespace AdventOfCode.Year2022;

public class Day23
{
	private readonly string[] _input;

	public Day23(string[] input)
	{
		_input = input;
	}

	public int Part1() => Solve(10);

	public int Part2() => Solve();

	private int Solve(int? rounds = null)
	{
		var world = Parse();
		var tests = new string[][]
		{
			["N", "NE", "NW"],
			["S", "SE", "SW"],
			["W", "NW", "SW"],
			["E", "NE", "SE"],
		};

		foreach (var (round, moves) in new[] { 0, 1, 2, 3 }.Repeat().Select(n => tests.Repeat().Skip(n).Take(4)).Index(1))
		{
			var wants = new Dictionary<Point, List<Point>>();

			foreach (var elf in world)
			{
				if (!elf.Adjacent().Any(world.Contains))
				{
					continue;
				}

				foreach (var move in moves)
				{
					if (move.Select(elf.Step).All(p => !world.Contains(p)))
					{
						var pos = elf.Step(move[0]);

						if (wants.TryGetValue(pos, out var elves))
						{
							elves.Add(elf);
						}
						else
						{
							wants.Add(pos, [elf]);
						}

						break;
					}
				}
			}

			if (wants.Count is 0)
			{
				return round;
			}

			foreach (var (elf, elves) in wants.Where(x => x.Value.Count is 1))
			{
				world.Remove(elves[0]);
				world.Add(elf);
			}

			if (round == rounds)
			{
				break;
			}
		}

		var xmin = world.Min(p => p.X);
		var xmax = world.Max(p => p.X);
		var ymin = world.Min(p => p.Y);
		var ymax = world.Max(p => p.Y);

		return (xmax - xmin + 1) * (ymax - ymin + 1) - world.Count;
	}

	private HashSet<Point> Parse()
	{
		var world = new HashSet<Point>();

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				if (_input[y][x] is '#')
				{
					world.Add(new(x, y));
				}
			}
		}

		return world;
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(string dir) => dir switch
		{
			"N" => this with { Y = Y - 1 },
			"S" => this with { Y = Y + 1 },
			"E" => this with { X = X + 1 },
			"W" => this with { X = X - 1 },
			"NW" => Step("N").Step("W"),
			"NE" => Step("N").Step("E"),
			"SW" => Step("S").Step("W"),
			"SE" => Step("S").Step("E"),
			_ => throw new Exception("dir?"),
		};

		public IEnumerable<Point> Adjacent()
		{
			yield return Step("N");
			yield return Step("S");
			yield return Step("E");
			yield return Step("W");
			yield return Step("NW");
			yield return Step("NE");
			yield return Step("SW");
			yield return Step("SE");
		}
	}
}
