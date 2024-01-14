namespace AdventOfCode.Year2018;

using Point = (int X, int Y);

public class Day17(string[] input)
{
	public int Part1() => Solve(c => c is '~' or '|');

	public int Part2() => Solve(c => c is '~');

	private int Solve(Func<char, bool> match)
	{
		var scan = Parse();
		var xmin = scan.Keys.Min(p => p.X);
		var xmax = scan.Keys.Max(p => p.X);
		var ymin = scan.Keys.Min(p => p.Y);
		var ymax = scan.Keys.Max(p => p.Y);

		var seen = new HashSet<Point>();
		var work = new Queue<Point>();
		work.Enqueue((500, 1));

		while (work.TryDequeue(out var p))
		{
			if (!seen.Add(p))
			{
				continue;
			}

			var y = NextY(p);

			if (y.HasValue)
			{
				if (scan.TryGetValue((p.X, y.Value + 1), out var b) && b is '~')
				{
					y = y.Value + 1;
				}

				FillV(p.X, p.Y, y.Value);

				while (true)
				{
					var (lx, rx, lo, ro) = NextX((p.X, y.Value));
					FillH(y.Value, lx, rx, lo || ro ? '|' : '~');

					if (lo)
					{
						work.Enqueue((lx, y.Value + 1));
					}

					if (ro)
					{
						work.Enqueue((rx, y.Value + 1));
					}

					if (lo || ro)
					{
						break;
					}

					y--;
				}
			}
			else
			{
				FillV(p.X, p.Y, ymax);
			}
		}

		return scan
			.Where(kv => ymin <= kv.Key.Y && kv.Key.Y <= ymax)
			.Count(kv => match(kv.Value));

		void FillV(int x, int ymin, int ymax)
		{
			for (int y = ymin; y <= ymax; y++)
			{
				scan[(x, y)] = '|';
			}
		}

		void FillH(int y, int xmin, int xmax, char c)
		{
			for (int x = xmin; x <= xmax; x++)
			{
				scan[(x, y)] = c;
			}
		}

		int? NextY(Point p)
		{
			for (int y = p.Y; y <= ymax; y++)
			{
				if (scan.ContainsKey((p.X, y)))
				{
					return y - 1;
				}
			}

			return null;
		}

		(int LX, int RX, bool LO, bool RO) NextX(Point p)
		{
			var lx = p.X;
			var lo = true;

			while (lx >= xmin)
			{
				if (scan.TryGetValue((lx, p.Y), out var a) && a is '#')
				{
					lx++;
					lo = false;
					break;
				}

				if (scan.TryGetValue((lx, p.Y + 1), out var b) && b is '#' or '~')
				{
					lx--;
				}
				else
				{
					break;
				}
			}

			var rx = p.X;
			var ro = true;

			while (rx <= xmax)
			{
				if (scan.TryGetValue((rx, p.Y), out var a) && a is '#')
				{
					rx--;
					ro = false;
					break;
				}

				if (scan.TryGetValue((rx, p.Y + 1), out var b) && b is '#' or '~')
				{
					rx++;
				}
				else
				{
					break;
				}
			}

			return (lx, rx, lo, ro);
		}
	}

	private Dictionary<Point, char> Parse()
	{
		var scan = new Dictionary<Point, char>();

		foreach (var line in input)
		{
			var match = Regex.Match(line, @"^([xy])=(\d+), [xy]=(\d+)\.\.(\d+)$");
			var xy = match.Groups[2].Value.ToInt32();
			var min = match.Groups[3].Value.ToInt32();
			var max = match.Groups[4].Value.ToInt32();

			if (match.Groups[1].Value is "x")
			{
				for (int y = min; y <= max; y++)
				{
					scan.TryAdd((xy, y), '#');
				}
			}
			else
			{
				for (int x = min; x <= max; x++)
				{
					scan.TryAdd((x, xy), '#');
				}
			}
		}

		return scan;
	}
}
