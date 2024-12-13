using Microsoft.Z3;

namespace AdventOfCode.Year2024;

public class Day13(string[] input)
{
	public long Part1()
	{
		var tokens = 0;

		foreach (var (ax, ay, bx, by, px, py) in Parse())
		{
			var cost = int.MaxValue;

			for (int na = 0; na <= 100; na++)
			{
				for (int nb = 0; nb <= 100; nb++)
				{
					var x = na * ax + nb * bx;
					var y = na * ay + nb * by;
					var c = na * 3 + nb;	

					if (x == px && y == py && c < cost)
					{
						cost = c;
					}
				}
			}

			if (cost < int.MaxValue)
			{
				tokens += cost;
			}
		}

		return tokens;
	}

	public long Part2()
	{
		var tokens = 0L;

		foreach (var (ax, ay, bx, by, px, py) in Parse())
		{
			using var c = new Context();
			var add = c.MkInt(10_000_000_000_000);
			var na = c.MkIntConst("na");
			var nb = c.MkIntConst("nb");

			var o = c.MkOptimize();
			o.Add(na >= 0);
			o.Add(nb >= 0);
			o.Add(c.MkEq(px + add, na * ax + nb * bx));
			o.Add(c.MkEq(py + add, na * ay + nb * by));
			var r = o.MkMinimize(na * 3 + nb);

			if (o.Check() is Status.SATISFIABLE)
			{
				tokens += (r.Value as IntNum).Int64;
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
