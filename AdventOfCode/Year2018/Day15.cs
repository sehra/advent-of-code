namespace AdventOfCode.Year2018;

public class Day15(string[] input)
{
	public int Part1()
	{
		var (cave, units) = Parse();
		var rounds = Simulate(cave, units, false).Value;

		return rounds * units.Sum(unit => Math.Max(0, unit.Health));
	}

	public int Part2()
	{
		for (int power = 4; true; power++)
		{
			var (cave, units) = Parse();
			var elves = units.Where(unit => unit.Type is 'E');

			foreach (var unit in elves)
			{
				unit.Power = power;
			}

			var rounds = Simulate(cave, units, true);

			if (rounds.HasValue)
			{
				return rounds.Value * elves.Sum(unit => unit.Health);
			}
		}

		throw new Exception("not found");
	}

	private static int? Simulate(HashSet<Point> cave, List<Unit> units, bool part2)
	{
		var alive = units.Where(unit => unit.Health > 0);
		var rounds = 0;

		while (alive.Distinct(unit => unit.Type).Count() > 1)
		{
			units.Sort((a, b) => a.Pos.CompareTo(b.Pos));

			foreach (var self in alive)
			{
				var targets = alive
					.Where(unit => unit.Type != self.Type)
					.ToArray();

				if (targets.Length == 0)
				{
					return rounds;
				}

				var near = self.Pos
					.Adjacent()
					.Join(targets, pos => pos, unit => unit.Pos, (_, unit) => unit)
					.Any();

				if (!near)
				{
					var open = cave
						.Except(alive.Select(unit => unit.Pos))
						.ToHashSet();
					var path = Explore(open, self.Pos);
					var want = targets
						.SelectMany(unit => unit.Pos.Adjacent())
						.ToHashSet();
					var move = path.Keys
						.Where(want.Contains)
						.OrderBy(pos => Distance(path, pos, self.Pos))
						.ThenBy(pos => pos)
						.FirstOrDefault();

					if (move == default)
					{
						continue;
					}

					while (path[move] != self.Pos)
					{
						move = path[move];
					}

					self.Pos = move;
				}

				var target = self.Pos.Adjacent()
					.Join(targets, pos => pos, unit => unit.Pos, (_, unit) => unit)
					.OrderBy(unit => unit.Health)
					.ThenBy(unit => unit.Pos)
					.FirstOrDefault();

				if (target is not null)
				{
					target.Health -= self.Power;

					if (part2 && target.Type is 'E' && target.Health <= 0)
					{
						return null;
					}
				}
			}

			rounds++;
		}

		return rounds;

		static Dictionary<Point, Point> Explore(HashSet<Point> open, Point start)
		{
			var path = new Dictionary<Point, Point>() { [start] = default };
			var work = new Queue<Point>();
			work.Enqueue(start);

			while (work.TryDequeue(out var curr))
			{
				foreach (var next in curr.Adjacent())
				{
					if (open.Contains(next) && path.TryAdd(next, curr))
					{
						work.Enqueue(next);
					}
				}
			}

			return path;
		}

		static int Distance(Dictionary<Point, Point> path, Point src, Point dst)
		{
			var steps = 0;

			while (path[src] != dst)
			{
				src = path[src];
				steps++;
			}

			return steps;
		}
	}

	private readonly record struct Point(int X, int Y) : IComparable<Point>
	{
		public int CompareTo(Point other)
		{
			var cmp = Y.CompareTo(other.Y);
			if (cmp != 0) return cmp;
			return X.CompareTo(other.X);
		}

		public IEnumerable<Point> Adjacent()
		{
			yield return new(X, Y - 1);
			yield return new(X - 1, Y);
			yield return new(X + 1, Y);
			yield return new(X, Y + 1);
		}
	}

	private record class Unit(char Type)
	{
		public Point Pos { get; set; }
		public int Health { get; set; } = 200;
		public int Power { get; set; } = 3;
	}

	private (HashSet<Point> Cave, List<Unit> Units) Parse()
	{
		var cave = new HashSet<Point>();
		var units = new List<Unit>();

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c is not '#')
				{
					cave.Add(new(x, y));

					if (c is 'E' or 'G')
					{
						units.Add(new(c) { Pos = new(x, y) });
					}
				}
			}
		}

		return (cave, units);
	}
}
