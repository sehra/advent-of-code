namespace AdventOfCode.Year2021;

public class Day17
{
	private readonly string _input;

	public Day17(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Solve().Ytop;
	}

	public int Part2()
	{
		return Solve().Hits;
	}

	private (int Ytop, int Hits) Solve()
	{
		var target = Target.Parse(_input);
		var xvelmin = 0;

		for (int i = 0; i < target.Xmin; i += xvelmin)
		{
			xvelmin++;
		}

		var ytop = 0;
		var hits = 0;

		for (int yvel = target.Ymin; yvel <= -target.Ymin; yvel++)
		{
			for (int xvel = xvelmin; xvel <= target.Xmax; xvel++)
			{
				var probe = new Probe(xvel, yvel);

				while (probe.CanHit(target))
				{
					probe.Tick();

					if (probe.IsHit(target))
					{
						ytop = Math.Max(ytop, probe.Ytop);
						hits++;
						break;
					}
				}
			}
		}

		return (ytop, hits);
	}

	private record struct Probe(int Xvel, int Yvel, int X = 0, int Y = 0, int Ytop = 0)
	{
		public readonly bool CanHit(Target target) =>
			X <= target.Xmax && target.Ymin <= Y;

		public readonly bool IsHit(Target target) =>
			target.Xmin <= X && X <= target.Xmax &&
			target.Ymin <= Y && Y <= target.Ymax;

		public void Tick()
		{
			X += Xvel;
			Y += Yvel;
			Xvel -= Math.Sign(Xvel);
			Yvel--;
			Ytop = Math.Max(Ytop, Y);
		}
	}

	private readonly record struct Target(int Xmin, int Xmax, int Ymin, int Ymax)
	{
		public static Target Parse(string input)
		{
			var match = Regex.Match(input, @"x=(-?\d+)\.\.(-?\d+), y=(-?\d+)\.\.(-?\d+)$");
			var xmin = match.Groups[1].Value.ToInt32();
			var xmax = match.Groups[2].Value.ToInt32();
			var ymin = match.Groups[3].Value.ToInt32();
			var ymax = match.Groups[4].Value.ToInt32();

			return new(xmin, xmax, ymin, ymax);
		}
	}
}
