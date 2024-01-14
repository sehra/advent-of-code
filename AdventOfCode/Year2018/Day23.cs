using Microsoft.Z3;

namespace AdventOfCode.Year2018;

using Bot = (int X, int Y, int Z, int R);

public class Day23(string[] input)
{
	public int Part1()
	{
		var bots = Parse();
		var strongest = bots.MaxBy(b => b.R);
		var count = 0;

		for (int i = 0; i < bots.Count; i++)
		{
			if (TaxiDist(strongest, bots[i]) <= strongest.R)
			{
				count++;
			}
		}

		return count;

		static int TaxiDist(Bot a, Bot b) =>
			Math.Abs(b.X - a.X) + Math.Abs(b.Y - a.Y) + Math.Abs(b.Z - a.Z);
	}

	public int Part2()
	{
		var bots = Parse();

		using var ctx = new Context();
		var px = ctx.MkIntConst("px");
		var py = ctx.MkIntConst("py");
		var pz = ctx.MkIntConst("pz");

		var near = ctx.MkInt(0) as ArithExpr;

		foreach (var (x, y, z, r) in bots)
		{
			var dist = MkAbs(px - x) + MkAbs(py - y) + MkAbs(pz - z);
			near += ctx.MkITE(dist <= r, ctx.MkInt(1), ctx.MkInt(0)) as ArithExpr;
		}

		var opt = ctx.MkOptimize();
		var max = opt.MkMaximize(near);
		var min = opt.MkMinimize(MkAbs(px) + MkAbs(py) + MkAbs(pz));

		if (opt.Check() == Status.SATISFIABLE)
		{
			return (min.Value as IntNum).Int;
		}
		else
		{
			throw new Exception("not found");
		}

		ArithExpr MkAbs(ArithExpr e) => ctx.MkITE(e >= 0, e, -e) as ArithExpr;
	}

	private List<Bot> Parse() => input
		.Select(line => Regex.Match(line, @"^pos=<(-?\d+),(-?\d+),(-?\d+)>, r=(\d+)$"))
		.Select(match =>
		(
			match.Groups[1].ValueSpan.ToInt32(), match.Groups[2].ValueSpan.ToInt32(),
			match.Groups[3].ValueSpan.ToInt32(), match.Groups[4].ValueSpan.ToInt32()
		))
		.ToList();
}
