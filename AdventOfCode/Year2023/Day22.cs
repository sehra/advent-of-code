namespace AdventOfCode.Year2023;

public class Day22(string[] input)
{
	public int Part1()
	{
		var bricks = Parse();
		var graph = FallAndDeps(bricks);
		var count = 0;

		foreach (var brick in graph)
		{
			var safe = brick.Above.All(b => b.Below.Except(brick).Any());
			count += safe ? 1 : 0;
		}

		return count;
	}

	public int Part2()
	{
		var bricks = Parse();
		var graph = FallAndDeps(bricks);
		var count = 0;

		foreach (var check in graph)
		{
			var gone = new HashSet<Brick>();
			var work = new Queue<Brick>();
			work.Enqueue(check);

			while (work.TryDequeue(out var brick))
			{
				if (!gone.Add(brick))
				{
					continue;
				}

				foreach (var above in brick.Above)
				{
					if (!above.Below.Except(gone).Any())
					{
						work.Enqueue(above);
					}
				}
			}

			count += gone.Count - 1;
		}

		return count;
	}

	private static List<Brick> FallAndDeps(List<Brick> bricks)
	{
		var world = new List<Brick>();
		var taken = new HashSet<Pos3>();

		foreach (var place in bricks.OrderBy(p => p.Bot.Z))
		{
			var brick = place;

			while (!brick.Drop().BotLayer().Any(taken.Contains) && brick.Bot.Z > 1)
			{
				brick = brick.Drop();
			}

			world.Add(brick);
			taken.UnionWith(brick.TopLayer());

			var hits = world
				.Where(b => b.Top.Z == brick.Bot.Z - 1)
				.Where(b => b.TopLayer().Intersect(brick.Drop().BotLayer()).Any())
				.ToArray();
			brick.Below.AddRange(hits);
			hits.ForEach(hit => hit.Above.Add(brick));
		}

		return world;
	}

	private readonly record struct Pos3(int X, int Y, int Z)
	{
		public Pos3 Drop() => this with { Z = Z - 1 };
	}

	private record class Brick(Pos3 Bot, Pos3 Top)
	{
		public List<Brick> Above { get; } = [];
		public List<Brick> Below { get; } = [];

		public Brick Drop() => new(Bot.Drop(), Top.Drop());

		public IEnumerable<Pos3> BotLayer() => Layer(Bot.Z);

		public IEnumerable<Pos3> TopLayer() => Layer(Top.Z);

		private IEnumerable<Pos3> Layer(int z)
		{
			for (int x = Bot.X; x <= Top.X; x++)
			{
				for (int y = Bot.Y; y <= Top.Y; y++)
				{
					yield return new(x, y, z);
				}
			}
		}
	}

	private List<Brick> Parse()
	{
		var bricks = new List<Brick>();

		foreach (var line in input)
		{
			var split = line.Split('~');
			var bnums = split[0].Split(',').ToInt32();
			var tnums = split[1].Split(',').ToInt32();

			var bot = new Pos3(bnums[0], bnums[1], bnums[2]);
			var top = new Pos3(tnums[0], tnums[1], tnums[2]);

			Debug.Assert(bot.X <= top.X);
			Debug.Assert(bot.Y <= top.Y);
			Debug.Assert(bot.Z <= top.Z);

			bricks.Add(new(bot, top));
		}

		return bricks;
	}
}
