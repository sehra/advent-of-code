using Microsoft.Z3;

namespace AdventOfCode.Year2023;

public class Day24(string[] input)
{
	public int Part1(long min = 200_000_000_000_000, long max = 400_000_000_000_000)
	{
		var hails = Parse();
		var count = 0;

		for (int i = 0; i < hails.Length; i++)
		{
			for (int j = i + 1; j < hails.Length; j++)
			{
				var a = hails[i];
				var b = hails[j];
				var hit = Vec2.Intersect(XY(a.Pos), XY(a.Vel), XY(b.Pos), XY(b.Vel));

				if (min <= hit.X && hit.X <= max &&
					min <= hit.Y && hit.Y <= max &&
					Math.Sign(hit.X - a.Pos.X) == Math.Sign(a.Vel.X) &&
					Math.Sign(hit.Y - a.Pos.Y) == Math.Sign(a.Vel.Y) &&
					Math.Sign(hit.X - b.Pos.X) == Math.Sign(b.Vel.X) &&
					Math.Sign(hit.Y - b.Pos.Y) == Math.Sign(b.Vel.Y))
				{
					count++;
				}

				static Vec2<double> XY(Vec3<long> vec) => new(vec.X, vec.Y);
			}
		}

		return count;
	}

	public long Part2()
	{
		var hails = Parse();

		using var c = new Context();
		var px = c.MkIntConst("px");
		var py = c.MkIntConst("py");
		var pz = c.MkIntConst("pz");
		var vx = c.MkIntConst("vx");
		var vy = c.MkIntConst("vy");
		var vz = c.MkIntConst("vz");
		var s = c.MkSolver();

		for (int i = 0; i < 3; i++)
		{
			var h = hails[i];
			var t = c.MkIntConst($"t{i}");
			s.Assert(c.MkEq(c.MkAdd(px, c.MkMul(vx, t)), c.MkAdd(c.MkInt(h.Pos.X), c.MkMul(c.MkInt(h.Vel.X), t))));
			s.Assert(c.MkEq(c.MkAdd(py, c.MkMul(vy, t)), c.MkAdd(c.MkInt(h.Pos.Y), c.MkMul(c.MkInt(h.Vel.Y), t))));
			s.Assert(c.MkEq(c.MkAdd(pz, c.MkMul(vz, t)), c.MkAdd(c.MkInt(h.Pos.Z), c.MkMul(c.MkInt(h.Vel.Z), t))));
			s.Assert(c.MkGt(t, c.MkInt(0)));
		}

		if (s.Check() is Status.SATISFIABLE)
		{
			var x = s.Model.Eval(px) as IntNum;
			var y = s.Model.Eval(py) as IntNum;
			var z = s.Model.Eval(pz) as IntNum;

			return x.Int64 + y.Int64 + z.Int64;
		}

		throw new Exception("not found");
	}

	private readonly record struct Hail(Vec3<long> Pos, Vec3<long> Vel);

	private Hail[] Parse() => input
		.Select(line => line.Split(["@", ","], StringSplitOptions.TrimEntries).ToInt64())
		.Select(line => new Hail(new(line[0], line[1], line[2]), new(line[3], line[4], line[5])))
		.ToArray();

}
