namespace AdventOfCode.Year2024;

public partial class Day14(string[] input)
{
	public int Part1(int w = 101, int h = 103)
	{
		var rs = Parse();

		for (int i = 0; i < rs.Count; i++)
		{
			var (px, py, vx, vy) = rs[i];
			rs[i] = (MathFunc.Mod(px + vx * 100, w), MathFunc.Mod(py + vy * 100, h), vx, vy);
		}

		var ul = 0;
		var ur = 0;
		var dl = 0;
		var dr = 0;
		var hw = w / 2;
		var hh = h / 2;

		foreach (var (px, py, _, _) in rs)
		{
			if (px < hw)
			{
				if (py < hh)
				{
					ul++;
				}
				else if (py > hh)
				{
					dl++;
				}
			}
			else if (px > hw)
			{
				if (py < hh)
				{
					ur++;
				}
				else if (py > hh)
				{
					dr++;
				}
			}
		}

		return ul * ur * dl * dr;
	}

	public int Part2()
	{
		const int w = 101;
		const int h = 103;

		var rs = Parse();

		for (int t = 0; t < 10000; t++)
		{
			for (int i = 0; i < rs.Count; i++)
			{
				var (px, py, vx, vy) = rs[i];
				rs[i] = (MathFunc.Mod(px + vx, w), MathFunc.Mod(py + vy, h), vx, vy);
			}

			var nbors = 0;

			foreach (var (px, py, _, _) in rs)
			{
				if (rs.Any(r => Math.Abs(r.px - px) is 1 && Math.Abs(r.py - py) is 1))
				{
					nbors++;
				}
			}

			// magic number
			if (nbors > 200)
			{
				return t + 1;
			}
		}

		throw new Exception("not found");
	}

	private List<(int px, int py, int vx, int vy)> Parse()
	{
		var rs = new List<(int px, int py, int vx, int vy)>();

		foreach (var line in input)
		{
			var m = RobotRegex.Match(line);
			rs.Add((
				m.Groups["px"].ValueSpan.ToInt32(), m.Groups["py"].ValueSpan.ToInt32(),
				m.Groups["vx"].ValueSpan.ToInt32(), m.Groups["vy"].ValueSpan.ToInt32()
			));
		}

		return rs;
	}

	[GeneratedRegex(@"p=(?<px>-?\d+),(?<py>-?\d+) v=(?<vx>-?\d+),(?<vy>-?\d+)")]
	private static partial Regex RobotRegex { get; }
}
