using System.Diagnostics.CodeAnalysis;
using Microsoft.Z3;

namespace AdventOfCode.Year2024;

public partial class Day13(string[] input)
{
	public long Part1() => SolveFast();

	public long Part2() => SolveFast(10_000_000_000_000);

	[SuppressMessage("CodeQuality", "IDE0051")]
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
			var a = IntRegex.Matches(lines[0]);
			var b = IntRegex.Matches(lines[1]);
			var p = IntRegex.Matches(lines[2]);

			yield return (
				a[0].ValueSpan.ToInt32(), a[1].ValueSpan.ToInt32(),
				b[0].ValueSpan.ToInt32(), b[1].ValueSpan.ToInt32(),
				p[0].ValueSpan.ToInt32(), p[1].ValueSpan.ToInt32()
			);
		}
	}

	[GeneratedRegex(@"\d+")]
	private partial Regex IntRegex { get; }
}
