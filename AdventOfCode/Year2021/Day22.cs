namespace AdventOfCode.Year2021;

public class Day22
{
	private readonly string[] _input;

	public Day22(string[] input)
	{
		_input = input;
	}

	public long Part1()
	{
		return Solve(new Cube(new(-50, -50, -50), new(51, 51, 51)));
	}

	public long Part2()
	{
		return Solve(Cube.Max);
	}

	private long Solve(Cube bounds)
	{
		var steps = Parse();
		var cubes = new List<Cube>();

		foreach (var (on, cube) in steps)
		{
			if (!bounds.Contains(cube))
			{
				continue;
			}

			cubes = cubes.SelectMany(c => c - cube).ToList();

			if (on)
			{
				cubes.Add(cube);
			}
		}

		return cubes.Sum(c => c.Volume);
	}

	private List<(bool On, Cube Cube)> Parse()
	{
		var regex = new Regex(@"^(on|off) x=(-?\d+)\.\.(-?\d+),y=(-?\d+)\.\.(-?\d+),z=(-?\d+)\.\.(-?\d+)$");
		var steps = new List<(bool, Cube)>();

		foreach (var line in _input)
		{
			var match = regex.Match(line);

			var on = match.Groups[1].Value is "on";
			var xmin = match.Groups[2].Value.ToInt32();
			var xmax = match.Groups[3].Value.ToInt32() + 1;
			var ymin = match.Groups[4].Value.ToInt32();
			var ymax = match.Groups[5].Value.ToInt32() + 1;
			var zmin = match.Groups[6].Value.ToInt32();
			var zmax = match.Groups[7].Value.ToInt32() + 1;

			steps.Add((on, new(new(xmin, ymin, zmin), new(xmax, ymax, zmax))));
		}

		return steps;
	}

	private readonly record struct Point(int X, int Y, int Z)
	{
		public static Point Min => new(Int32.MinValue, Int32.MinValue, Int32.MinValue);
		public static Point Max => new(Int32.MaxValue, Int32.MaxValue, Int32.MaxValue);
	}

	private readonly record struct Cube(Point A, Point B)
	{
		public static Cube Max => new(Point.Min, Point.Max);

		public bool Contains(Cube other) =>
			A.X <= other.A.X && B.X >= other.B.X &&
			A.Y <= other.A.Y && B.Y >= other.B.Y &&
			A.Z <= other.A.Z && B.Z >= other.B.Z;

		public bool Intersects(Cube other) =>
			A.X <= other.B.X && B.X >= other.A.X &&
			A.Y <= other.B.Y && B.Y >= other.A.Y &&
			A.Z <= other.B.Z && B.Z >= other.A.Z;

		public long Volume => ((long)B.X - A.X) * ((long)B.Y - A.Y) * ((long)B.Z - A.Z);

		public static Cube[] operator -(Cube a, Cube b)
		{
			if (b.Contains(a))
			{
				return Array.Empty<Cube>();
			}

			if (!a.Intersects(b))
			{
				return new[] { a };
			}

			var xs = new List<int>() { a.A.X };
			if (a.A.X < b.A.X && b.A.X < a.B.X) xs.Add(b.A.X);
			if (a.A.X < b.B.X && b.B.X < a.B.X) xs.Add(b.B.X);
			xs.Add(a.B.X);

			var ys = new List<int>() { a.A.Y };
			if (a.A.Y < b.A.Y && b.A.Y < a.B.Y) ys.Add(b.A.Y);
			if (a.A.Y < b.B.Y && b.B.Y < a.B.Y) ys.Add(b.B.Y);
			ys.Add(a.B.Y);

			var zs = new List<int>() { a.A.Z };
			if (a.A.Z < b.A.Z && b.A.Z < a.B.Z) zs.Add(b.A.Z);
			if (a.A.Z < b.B.Z && b.B.Z < a.B.Z) zs.Add(b.B.Z);
			zs.Add(a.B.Z);

			var cubes = new List<Cube>();

			foreach (var x in xs.Window(2))
			{
				foreach (var y in ys.Window(2))
				{
					foreach (var z in zs.Window(2))
					{
						var pa = new Point(x[0], y[0], z[0]);
						var pb = new Point(x[1], y[1], z[1]);
						cubes.Add(new(pa, pb));
					}
				}
			}

			return cubes.Where(c => !b.Contains(c)).ToArray();
		}
	}
}
