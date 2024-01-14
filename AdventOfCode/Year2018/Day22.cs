namespace AdventOfCode.Year2018;

using Point = (int X, int Y);

public class Day22(string[] input)
{
	public int Part1()
	{
		var (depth, target) = Parse();
		var cave = new Cave(depth, target);
		var risk = 0;

		for (int x = 0; x <= target.X; x++)
		{
			for (int y = 0; y <= target.Y; y++)
			{
				var type = cave[(x, y)];

				if (type is '=')
				{
					risk += 1;
				}
				else if (type is '|')
				{
					risk += 2;
				}
			}
		}

		return risk;
	}

	public int Part2()
	{
		var (depth, target) = Parse();
		var cave = new Cave(depth, target);

		var seen = new Dictionary<(Point, Equip), int>();
		var work = new PriorityQueue<(Point, Equip, int), int>();
		work.Enqueue(((0, 0), Equip.Torch, 0), 0);

		while (work.TryDequeue(out var state, out _))
		{
			var (curr, equip, time) = state;

			if (seen.TryGetValue((curr, equip), out var best) && best <= time)
			{
				continue;
			}
			else
			{
				seen[(curr, equip)] = time;
			}

			if (curr == target && equip == Equip.Torch)
			{
				return time;
			}

			foreach (var next in Adjacent(curr))
			{
				if (next.X < 0 || next.Y < 0)
				{
					continue;
				}

				foreach (var e in Equips(cave[curr], cave[next]))
				{
					var change = e == equip ? 0 : 7;
					var prio = time + 1 + change + TaxiDist(next, target);
					work.Enqueue((next, e, time + 1 + change), prio);
				}
			}
		}

		throw new Exception("not found");

		static IEnumerable<Point> Adjacent(Point p)
		{
			yield return (p.X, p.Y - 1);
			yield return (p.X, p.Y + 1);
			yield return (p.X - 1, p.Y);
			yield return (p.X + 1, p.Y);
		}

		static IEnumerable<Equip> Equips(char curr, char next) => (curr, next) switch
		{
			('.', '.') => [Equip.Climb, Equip.Torch],
			('.', '=') => [Equip.Climb],
			('.', '|') => [Equip.Torch],
			('=', '.') => [Equip.Climb],
			('=', '=') => [Equip.Climb, Equip.Neither],
			('=', '|') => [Equip.Neither],
			('|', '.') => [Equip.Torch],
			('|', '=') => [Equip.Neither],
			('|', '|') => [Equip.Torch, Equip.Neither],
			_ => throw new Exception("type?"),
		};

		static int TaxiDist(Point a, Point b) =>
			Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y);
	}

	private enum Equip
	{
		Neither,
		Climb,
		Torch,
	}

	private class Cave(int depth, Point target)
	{
		private readonly Dictionary<Point, int> _levels = [];
		private readonly Dictionary<Point, char> _types = [];
		private readonly int _depth = depth;
		private readonly Point _target = target;

		public char this[Point p] => GetType(p);

		private char GetType(Point p)
		{
			if (_types.TryGetValue(p, out var type))
			{
				return type;
			}

			return _types[p] = (GetLevel(p) % 3) switch
			{
				0 => '.',
				1 => '=',
				2 => '|',
				_ => throw new Exception("level?"),
			};
		}

		private int GetIndex(Point p)
		{
			if (p == default || p == _target)
			{
				return 0;
			}
			else if (p.Y is 0)
			{
				return p.X * 16807;
			}
			else if (p.X is 0)
			{
				return p.Y * 48271;
			}
			else
			{
				return GetLevel((p.X - 1, p.Y)) * GetLevel((p.X, p.Y - 1));
			}
		}

		private int GetLevel(Point p)
		{
			if (_levels.TryGetValue(p, out var level))
			{
				return level;
			}

			return _levels[p] = (GetIndex(p) + _depth) % 20183;
		}
	}

	private (int Depth, Point Target) Parse()
	{
		var depth = input[0][7..].ToInt32();
		var split = input[1][8..].Split(',');

		return (depth, (split[0].ToInt32(), split[1].ToInt32()));
	}
}
