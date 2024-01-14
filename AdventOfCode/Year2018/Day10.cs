namespace AdventOfCode.Year2018;

using Vec = Vec2<int>;

public class Day10(string[] input)
{
	public string Part1() => Solve().Image;

	public int Part2() => Solve().Steps;

	private (string Image, int Steps) Solve()
	{
		var stars = Parse();
		var size = Size(stars);
		var steps = 0;

		while (true)
		{
			var nstars = stars
				.Select(s => s with { Pos = s.Pos + s.Vel })
				.ToArray();
			var nsize = Size(nstars);

			if (size.A < nsize.A)
			{
				break;
			}

			stars = nstars;
			size = nsize;
			steps++;
		}

		var image = new char[size.Y + 1][];

		for (int i = 0; i <= size.Y; i++)
		{
			image[i] = [.. Enumerable.Repeat('.', size.X + 1)];
		}

		foreach (var star in stars)
		{
			image[star.Pos.Y - size.Min.Y][star.Pos.X - size.Min.X] = '#';
		}

		return (image.ToString((sb, row) => sb.AppendLine(new(row))).Trim(), steps);

		static Size Size(Star[] stars)
		{
			var xmin = stars.Min(s => s.Pos.X);
			var xmax = stars.Max(s => s.Pos.X);
			var ymin = stars.Min(s => s.Pos.Y);
			var ymax = stars.Max(s => s.Pos.Y);

			return new((xmin, ymin), (xmax, ymax));
		}
	}

	private readonly record struct Star(Vec Pos, Vec Vel);

	private readonly record struct Size(Vec Min, Vec Max)
	{
		public long A => (long)X * Y;
		public int X => Math.Abs(Max.X - Min.X);
		public int Y => Math.Abs(Max.Y - Min.Y);
	}

	private Star[] Parse() => input
		.Select(line => line.Split('=', '<', ',', '>'))
		.Select(line => new Star(
			new(line[2].ToInt32(), line[3].ToInt32()),
			new(line[6].ToInt32(), line[7].ToInt32())
		))
		.ToArray();
}
