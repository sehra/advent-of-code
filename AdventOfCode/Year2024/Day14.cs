namespace AdventOfCode.Year2024;

public partial class Day14(string[] input)
{
	public int Part1(int w = 101, int h = 103)
	{
		var ul = 0;
		var ur = 0;
		var dl = 0;
		var dr = 0;
		var hw = w / 2;
		var hh = h / 2;

		foreach (var (px, py, vx, vy) in Parse())
		{
			var x = MathFunc.Mod(px + vx * 100, w);
			var y = MathFunc.Mod(py + vy * 100, h);

			if (x < hw)
			{
				if (y < hh)
				{
					ul++;
				}
				else if (y > hh)
				{
					dl++;
				}
			}
			else if (x > hw)
			{
				if (y < hh)
				{
					ur++;
				}
				else if (y > hh)
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

		var robots = Parse();
		var floor = new bool[w * h].AsSpan();
		var match = Enumerable.Repeat(true, 16).ToArray();

		for (int t = 0; t < 10000; t++)
		{
			floor.Clear();

			foreach (var (px, py, vx, vy) in robots)
			{
				var x = MathFunc.Mod(px + vx * t, w);
				var y = MathFunc.Mod(py + vy * t, h);
				floor[w * y + x] = true;
			}

			if (floor.IndexOf(match) != -1)
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

	[GeneratedRegex(@"^p=(?<px>-?\d+),(?<py>-?\d+) v=(?<vx>-?\d+),(?<vy>-?\d+)$")]
	private static partial Regex RobotRegex { get; }
}
