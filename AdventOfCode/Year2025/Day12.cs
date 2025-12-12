namespace AdventOfCode.Year2025;

using Cache = Dictionary<bool[,], List<bool[,]>>;
using Shape = bool[,];

public class Day12(string[] input)
{
	public int Part1()
	{
		var (shapes, regions) = Parse();
		var cache = shapes.ToDictionary(s => s, s => UniqueVariants(s).ToList());
		var count = 0;

		foreach (var (x, y, needs) in regions)
		{
			var have = new List<Shape>();
			var used = 0;

			for (int s = 0; s < needs.Length; s++)
			{
				var shape = shapes[s];
				var area = 0;

				for (int sy = 0; sy < 3; sy++)
				{
					for (int sx = 0; sx < 3; sx++)
					{
						if (shape[sx, sy])
						{
							area++;
						}
					}
				}

				for (int n = 0; n < needs[s]; n++)
				{
					have.Add(shapes[s]);
					used += area;
				}
			}

			if (used > x * y)
			{
				continue;
			}

			if (CanFitAll(cache, have, 0, new bool[x, y]))
			{
				count++;
			}
		}

		return count;
	}

	public static string Part2()
	{
		return "get 23 stars";
	}

	private static bool CanFitAll(Cache cache, List<Shape> have, int index, bool[,] region,
		(int v, int ry, int rx)? last = null)
	{
		if (index >= have.Count)
		{
			return true;
		}

		var shape = have[index];
		var variants = cache[shape];

		var sv = 0;
		var sry = 0;
		var srx = 0;

		if (index > 0 && have[index - 1] == shape && last.HasValue)
		{
			sv = last.Value.v;
			sry = last.Value.ry;
			srx = last.Value.rx;
		}

		for (int v = sv; v < variants.Count; v++)
		{
			var variant = variants[v];
			var cry = (v == sv) ? sry : 0;

			for (int ry = cry; ry <= region.GetLength(1) - 3; ry++)
			{
				var crx = (v == sv && ry == sry) ? srx : 0;

				for (int rx = crx; rx <= region.GetLength(0) - 3; rx++)
				{
					if (TryPlace(variant, region, rx, ry))
					{
						if (CanFitAll(cache, have, index + 1, region, (v, ry, rx)))
						{
							return true;
						}

						Remove(variant, region, rx, ry);
					}
				}
			}
		}

		return false;
	}

	private static bool TryPlace(Shape shape, bool[,] region, int rx, int ry)
	{
		for (int sy = 0; sy < 3; sy++)
		{
			for (int sx = 0; sx < 3; sx++)
			{
				if (shape[sx, sy] && region[rx + sx, ry + sy])
				{
					return false;
				}
			}
		}

		for (int sy = 0; sy < 3; sy++)
		{
			for (int sx = 0; sx < 3; sx++)
			{
				if (shape[sx, sy])
				{
					region[rx + sx, ry + sy] = true;
				}
			}
		}

		return true;
	}

	private static void Remove(Shape shape, bool[,] region, int rx, int ry)
	{
		for (int sy = 0; sy < 3; sy++)
		{
			for (int sx = 0; sx < 3; sx++)
			{
				if (shape[sx, sy])
				{
					region[rx + sx, ry + sy] = false;
				}
			}
		}
	}

	private static IEnumerable<Shape> UniqueVariants(Shape shape)
	{
		var seen = new List<bool[,]>();

		foreach (var variant in Variants(shape))
		{
			if (!seen.Any(s => ShapeEquals(s, variant)))
			{
				seen.Add(variant);
				yield return variant;
			}
		}

		static bool ShapeEquals(bool[,] a, bool[,] b)
		{
			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					if (a[x, y] != b[x, y])
					{
						return false;
					}
				}
			}

			return true;
		}
	}

	private static IEnumerable<Shape> Variants(Shape shape)
	{
		foreach (var rotation in Rotations(shape))
		{
			yield return rotation;

			var flipped = new bool[3, 3];

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					flipped[x, y] = rotation[2 - x, y];
				}
			}

			yield return flipped;
		}
	}

	private static IEnumerable<Shape> Rotations(Shape shape)
	{
		var current = shape;

		for (int i = 0; i < 4; i++)
		{
			var rotated = new bool[3, 3];

			for (int y = 0; y < 3; y++)
			{
				for (int x = 0; x < 3; x++)
				{
					rotated[x, y] = current[2 - y, x];
				}
			}

			yield return current = rotated;
		}
	}

	private record Region(int X, int Y, int[] Need)
	{
		public static Region Parse(string line)
		{
			var split = line.Split(": ");
			var coords = split[0].Split('x').ToInt32();
			var shapes = split[1].Split().ToInt32();
			return new Region(coords[0], coords[1], shapes);
		}
	}

	private (Shape[], Region[]) Parse()
	{
		var shapes = input.Chunk(4).Take(6).Select(ParseShape).ToArray();
		var regions = input.Skip(4 * 6).Select(Region.Parse).ToArray();

		return (shapes, regions);

		static bool[,] ParseShape(string[] lines)
		{
			var shape = new bool[3, 3];

			for (int y = 0; y < 3; y++)
			{
				var line = lines[y + 1];

				for (int x = 0; x < 3; x++)
				{
					shape[x, y] = line[x] is '#';
				}
			}

			return shape;
		}
	}
}
