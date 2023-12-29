namespace AdventOfCode.Year2015;

public class Day2(string[] input)
{
	public int Part1() => Parse()
		.Sum(box => box.SurfaceArea + Math.Min(Math.Min(box.AreaXY, box.AreaXZ), box.AreaYZ));

	public int Part2() => Parse()
		.Sum(box => new[] { box.X, box.Y, box.Z }.Order().Take(2).Sum(n => n * 2) + box.Volume);

	private readonly record struct Box(int X, int Y, int Z)
	{
		public static Box Parse(string value)
		{
			var dims = value.Split('x').ToInt32();
			return new(dims[0], dims[1], dims[2]);
		}

		public int SurfaceArea => (AreaXY + AreaXZ + AreaYZ) * 2;
		public int AreaXY => X * Y;
		public int AreaXZ => X * Z;
		public int AreaYZ => Y * Z;
		public int Volume => X * Y * Z;
	}

	private Box[] Parse() => [.. input.Select(Box.Parse)];
}
