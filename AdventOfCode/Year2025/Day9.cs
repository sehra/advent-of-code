namespace AdventOfCode.Year2025;

using Vec = Vec2<long>;

public class Day9(string[] input)
{
	public long Part1()
	{
		var tiles = Parse();
		var best = 0L;

		for (int i = 0; i < tiles.Length; i++)
		{
			for (int j = i + 1; j < tiles.Length; j++)
			{
				var area = new Area(tiles[i], tiles[j]);
				best = Math.Max(best, area.Size);
			}
		}

		return best;
	}

	public long Part2()
	{
		var tiles = Parse();
		var lines = new List<Area>();

		for (int i = 0; i < tiles.Length; i++)
		{
			lines.Add(new(tiles[i], tiles[(i + 1) % tiles.Length]));
		}

		var areas = new List<Area>();

		for (int i = 0; i < tiles.Length; i++)
		{
			for (int j = i + 1; j < tiles.Length; j++)
			{
				areas.Add(new Area(tiles[i], tiles[j]).Resize(-1));
			}
		}

		return areas
			.OrderByDescending(area => area.Size)
			.First(area => lines.All(line => !line.Intersects(area)))
			.Resize(1)
			.Size;
	}

	private readonly struct Area(Vec p, Vec q)
	{
		public Vec P { get; } = (Math.Min(p.X, q.X), Math.Min(p.Y, q.Y));
		public Vec Q { get; } = (Math.Max(p.X, q.X), Math.Max(p.Y, q.Y));
		public long Size => (Q.X - P.X + 1) * (Q.Y - P.Y + 1);

		public bool Intersects(Area other) =>
			!(other.Q.X < P.X || other.P.X > Q.X || other.Q.Y < P.Y || other.P.Y > Q.Y);

		public Area Resize(int n) => new(P - (n, n), Q + (n, n));
	}

	private Vec[] Parse() => [ ..input
		.Select(line =>
		{
			var split = line.Split(',').ToInt64();
			return new Vec(split[0], split[1]);
		})];
}
