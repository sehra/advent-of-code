namespace AdventOfCode.Year2021;

public class Day19
{
	private readonly string[] _input;

	public Day19(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var scanners = Align(Parse());
		var beacons = new HashSet<Vector>();

		foreach (var scanner in scanners)
		{
			foreach (var beacon in scanner.Beacons)
			{
				beacons.Add(scanner.Alignment * beacon + scanner.Position);
			}
		}

		return beacons.Count;
	}

	public int Part2()
	{
		var scanners = Align(Parse());
		var distance = 0;

		foreach (var a in scanners)
		{
			foreach (var b in scanners)
			{
				if (a == b)
				{
					continue;
				}

				var apos = a.Position;
				var bpos = b.Position;

				distance = Math.Max(distance, ManhattanDistance(apos, bpos));
			}
		}

		return distance;

		static int ManhattanDistance(Vector a, Vector b) =>
			Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y) + Math.Abs(a.Z - b.Z);
	}

	private static List<Scanner> Align(List<Scanner> scanners)
	{
		var done = new List<Scanner>() { scanners[0] };
		var work = new List<Scanner>(scanners.Skip(1));

		while (work.Count > 0)
		{
			foreach (var locked in done)
			{
				foreach (var scanner in work)
				{
					if (TryAlign(locked, scanner))
					{
						done.Add(scanner);
						work.Remove(scanner);
						goto next;
					}
				}
			}

		next:
			continue;
		}

		return scanners;
	}

	private static bool TryAlign(Scanner a, Scanner b)
	{
		if (!a.CompareDistances(b))
		{
			return false;
		}

		var abs = a.Beacons.Select(ab => a.Alignment * ab).ToHashSet();

		foreach (var rotation in Rotations)
		{
			var bbs = b.Beacons.Select(bb => rotation * bb).ToArray();

			foreach (var ab in abs)
			{
				foreach (var bb in bbs)
				{
					var delta = bb - ab;
					var moved = bbs.Select(bb => bb - delta);
					var count = 0;

					foreach (var mbb in moved)
					{
						if (abs.Contains(mbb))
						{
							count++;

							if (count >= 12)
							{
								b.Position = a.Position - delta;
								b.Alignment = rotation;

								return true;
							}
						}
					}
				}
			}
		}

		return false;
	}

	private List<Scanner> Parse()
	{
		var scanners = new List<Scanner>();

		foreach (var line in _input)
		{
			if (line.StartsWith("---"))
			{
				scanners.Add(new() { Number = line.Split(' ')[2].ToInt32() });
				continue;
			}

			var split = line.Split(',');
			var x = split[0].ToInt32();
			var y = split[1].ToInt32();
			var z = split[2].ToInt32();
			scanners[^1].Beacons.Add(new(x, y, z));
		}

		foreach (var scanner in scanners)
		{
			scanner.GenerateDistances();
		}

		return scanners;
	}

	// https://www.euclideanspace.com/maths/algebra/matrix/transforms/examples/index.htm
	private static readonly Matrix[] Rotations =
	[
		new(1, 0, 0, 0, 1, 0, 0, 0, 1),
		new(1, 0, 0, 0, 0, -1, 0, 1, 0),
		new(1, 0, 0, 0, -1, 0, 0, 0, -1),
		new(1, 0, 0, 0, 0, 1, 0, -1, 0),

		new(0, -1, 0, 1, 0, 0, 0, 0, 1),
		new(0, 0, 1, 1, 0, 0, 0, 1, 0),
		new(0, 1, 0, 1, 0, 0, 0, 0, -1),
		new(0, 0, -1, 1, 0, 0, 0, -1, 0),

		new(-1, 0, 0, 0, -1, 0, 0, 0, 1),
		new(-1, 0, 0, 0, 0, -1, 0, -1, 0),
		new(-1, 0, 0, 0, 1, 0, 0, 0, -1),
		new(-1, 0, 0, 0, 0, 1, 0, 1, 0),

		new(0, 1, 0, -1, 0, 0, 0, 0, 1),
		new(0, 0, 1, -1, 0, 0, 0, -1, 0),
		new(0, -1, 0, -1, 0, 0, 0, 0, -1),
		new(0, 0, -1, -1, 0, 0, 0, 1, 0),

		new(0, 0, -1, 0, 1, 0, 1, 0, 0),
		new(0, 1, 0, 0, 0, 1, 1, 0, 0),
		new(0, 0, 1, 0, -1, 0, 1, 0, 0),
		new(0, -1, 0, 0, 0, -1, 1, 0, 0),

		new(0, 0, -1, 0, -1, 0, -1, 0, 0),
		new(0, -1, 0, 0, 0, 1, -1, 0, 0),
		new(0, 0, 1, 0, 1, 0, -1, 0, 0),
		new(0, 1, 0, 0, 0, -1, -1, 0, 0),
	];

	private readonly record struct Matrix(int M11, int M12, int M13, int M21, int M22, int M23, int M31, int M32, int M33)
	{
		public static Matrix Identity => new(1, 0, 0, 0, 1, 0, 0, 0, 1);

		public static Vector operator *(Matrix m, Vector v)
		{
			var x = m.M11 * v.X + m.M12 * v.Y + m.M13 * v.Z;
			var y = m.M21 * v.X + m.M22 * v.Y + m.M23 * v.Z;
			var z = m.M31 * v.X + m.M32 * v.Y + m.M33 * v.Z;

			return new Vector(x, y, z);
		}
	}

	private readonly record struct Vector(int X, int Y, int Z)
	{
		public static Vector operator +(Vector a, Vector b) =>
			new(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

		public static Vector operator -(Vector a, Vector b) =>
			new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
	}

	private class Scanner
	{
		private readonly HashSet<int> _distances = [];

		public int Number { get; init; }
		public List<Vector> Beacons { get; } = [];
		public Vector Position { get; set; }
		public Matrix Alignment { get; set; } = Matrix.Identity;

		public void GenerateDistances()
		{
			for (int i = 0; i < Beacons.Count - 1; i++)
			{
				for (int j = i + 1; j < Beacons.Count; j++)
				{
					var a = Beacons[i];
					var b = Beacons[j];
					var d = (int)(Math.Pow(b.X - a.X, 2) + Math.Pow(b.Y - a.Y, 2) + Math.Pow(b.Z - a.Z, 2));
					_distances.Add(d);
				}
			}
		}

		public bool CompareDistances(Scanner other) =>
			_distances.Intersect(other._distances).Count() >= 12;
	}
}
