using Microsoft.Z3;

namespace AdventOfCode.Year2024;

public class Day13(string[] input)
{
	public long Part1() => SolveFast();

	public long Part2() => SolveFast(10_000_000_000_000);

	private long SolveSlow(long add = 0)
	{
		var tokens = 0L;

		foreach (var (ax, ay, bx, by, px, py) in Parse())
		{
			using var c = new Context();
			var na = c.MkIntConst("na");
			var nb = c.MkIntConst("nb");

			var o = c.MkOptimize();
			o.Add(na >= 0);
			o.Add(nb >= 0);
			o.Add(c.MkEq(c.MkInt(px + add), na * ax + nb * bx));
			o.Add(c.MkEq(c.MkInt(py + add), na * ay + nb * by));
			var r = o.MkMinimize(na * 3 + nb);

			if (o.Check() is Status.SATISFIABLE)
			{
				tokens += (r.Value as IntNum).Int64;
			}
		}

		return tokens;
	}

	private long SolveFast(long add = 0)
	{
		// https://en.wikipedia.org/wiki/Cramer%27s_rule

		var tokens = 0L;

		foreach (var (ax, ay, bx, by, px, py) in Parse())
		{
			var det = ax * by - ay * bx;
			var (naq, nar) = Math.DivRem(by * (px + add) - bx * (py + add), det);
			var (nbq, nbr) = Math.DivRem(ax * (py + add) - ay * (px + add), det);

			if (nar is 0 && nbr is 0 && naq >= 0 && nbq >= 0)
			{
				tokens += naq * 3 + nbq;
			}
		}

		return tokens;
	}

	private IEnumerable<(int, int, int, int, int, int)> Parse()
	{
		foreach (var lines in input.Chunk(3))
		{
			var a = Regex.Match(lines[0], @"X\+(\d+), Y\+(\d+)");
			var b = Regex.Match(lines[1], @"X\+(\d+), Y\+(\d+)");
			var p = Regex.Match(lines[2], @"X=(\d+), Y=(\d+)");

			yield return (
				a.Groups[1].ValueSpan.ToInt32(), a.Groups[2].ValueSpan.ToInt32(),
				b.Groups[1].ValueSpan.ToInt32(), b.Groups[2].ValueSpan.ToInt32(),
				p.Groups[1].ValueSpan.ToInt32(), p.Groups[2].ValueSpan.ToInt32()
			);
		}
	}
}
