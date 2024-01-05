using System.Data;

namespace AdventOfCode.Year2017;

public class Day3(string input)
{
	public int Part1()
	{
		var goal = input.ToInt32();
		var ring = new List<Point>() { new(0, 0) };
		var size = 1;

		while (ring.Count < goal)
		{
			var (px, py) = ring[^1];
			var side = (size * size - ring.Count) / 4;

			for (int y = 0; y < side; y++)
			{
				ring.Add(new(px + 1, py + y));
			}

			(px, py) = ring[^1];

			for (int x = 1; x <= side; x++)
			{
				ring.Add(new(px - x, py));
			}

			(px, py) = ring[^1];

			for (int y = 1; y <= side; y++)
			{
				ring.Add(new(px, py - y));
			}

			(px, py) = ring[^1];

			for (int x = 1; x <= side; x++)
			{
				ring.Add(new(px + x, py));
			}

			size += 2;
		}

		return Math.Abs(ring[goal - 1].X) + Math.Abs(ring[goal - 1].Y);
	}

	public int Part2()
	{
		var goal = input.ToInt32();
		var pos = new Point(0, 0);
		var ring = new Dictionary<Point, int>() { [pos] = 1 };
		var size = 1;

		while (ring.Count < goal)
		{
			var (px, py) = pos;
			var val = 0;
			var side = (size * size - ring.Count) / 4;

			for (int y = 0; y < side; y++)
			{
				ring.Add(pos = new(px + 1, py + y), val = SumNbors(px + 1, py + y));

				if (val > goal)
				{
					return val;
				}
			}

			(px, py) = pos;

			for (int x = 1; x <= side; x++)
			{
				ring.Add(pos = new(px - x, py), val = SumNbors(px - x, py));

				if (val > goal)
				{
					return val;
				}
			}

			(px, py) = pos;

			for (int y = 1; y <= side; y++)
			{
				ring.Add(pos = new(px, py - y), val = SumNbors(px, py - y));

				if (val > goal)
				{
					return val;
				}
			}

			(px, py) = pos;

			for (int x = 1; x <= side; x++)
			{
				ring.Add(pos = new(px + x, py), val = SumNbors(px + x, py));

				if (val > goal)
				{
					return val;
				}
			}

			size += 2;
		}

		throw new Exception("not found");

		int SumNbors(int x, int y)
		{
			ring.TryGetValue(new(x - 1, y + 1), out var tl);
			ring.TryGetValue(new(x, y + 1), out var tc);
			ring.TryGetValue(new(x + 1, y + 1), out var tr);
			ring.TryGetValue(new(x - 1, y), out var l);
			ring.TryGetValue(new(x + 1, y), out var r);
			ring.TryGetValue(new(x - 1, y - 1), out var bl);
			ring.TryGetValue(new(x, y - 1), out var bc);
			ring.TryGetValue(new(x + 1, y - 1), out var br);

			return tl + tc + tr + l + r + bl + bc + br;
		}
	}

	private readonly record struct Point(int X, int Y);
}
