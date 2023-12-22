namespace AdventOfCode.Year2023;

public class Day22(string[] input)
{
	public int Part1()
	{
		var bricks = Parse();
		var graph = Compact(bricks);
		var count = 0;

		foreach (var brick in graph.Keys)
		{
			var @unsafe = graph.Values
				.Where(ds => ds.Contains(brick))
				.Any(ds => !ds.Except(brick).Any());
			count += @unsafe ? 0 : 1;
		}

		return count;
	}

	public int Part2()
	{
		// TODO: this is super slow

		var bricks = Parse();
		var graph = Compact(bricks);
		var count = 0;

		foreach (var brick in graph.Keys)
		{
			count += ChainReaction(brick);
		}

		return count;

		int ChainReaction(Brick start)
		{
			var fell = new HashSet<Brick>() { start };
			var work = new Queue<Brick>();
			work.Enqueue(start);

			while (work.TryDequeue(out var check))
			{
				var maybe = graph.Where(kv => kv.Value.Contains(check));

				foreach (var (brick, deps) in maybe)
				{
					if (deps.All(fell.Contains))
					{
						fell.Add(brick);
						work.Enqueue(brick);
					}
				}
			}

			return fell.Count - 1;
		}
	}

	private static Dictionary<Brick, List<Brick>> Compact(List<Brick> bricks)
	{
		var graph = new Dictionary<Brick, List<Brick>>();
		var taken = new HashSet<Pos3>();

		foreach (var brick in bricks.OrderBy(p => p.Bot.Z))
		{
			var place = brick;

			while (!place.Drop().BotLayer().Any(taken.Contains) && place.Bot.Z > 1)
			{
				place = place.Drop();
			}

			var hits = graph.Keys
				.Where(b => b.Top.Z == place.Bot.Z - 1)
				.Where(b => b.TopLayer().Intersect(place.Drop().BotLayer()).Any())
				.ToList();
			graph.Add(place, hits);
			taken.UnionWith(place.TopLayer());
		}

		return graph;
	}

	private readonly record struct Pos3(int X, int Y, int Z)
	{
		public static Pos3 Parse(string value)
		{
			var nums = value.Split(',').ToInt32();
			return new(nums[0], nums[1], nums[2]);
		}

		public Pos3 Drop() => this with { Z = Z - 1 };
	}

	private readonly record struct Brick(Pos3 Bot, Pos3 Top)
	{
		public static Brick Parse(string value)
		{
			var points = value.Split('~');
			var bot = Pos3.Parse(points[0]);
			var top = Pos3.Parse(points[1]);

			Debug.Assert(bot.X <= top.X);
			Debug.Assert(bot.Y <= top.Y);
			Debug.Assert(bot.Z <= top.Z);

			return new(bot, top);
		}

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

	private List<Brick> Parse() => input
		.Select(Brick.Parse).ToList();
}
