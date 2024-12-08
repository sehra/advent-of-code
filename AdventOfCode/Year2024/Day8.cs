namespace AdventOfCode.Year2024;

using Point = (int R, int C);

public class Day8(string[] input)
{
	public int Part1() => Solve(1, 1);

	public int Part2() => Solve(0, Int32.MaxValue);

	private int Solve(int nmin, int nmax)
	{
		var map = Parse();
		var nodes = new HashSet<Point>();

		foreach (var (_, antennas) in map)
		{
			for (int i = 0; i < antennas.Count; i++)
			{
				var (ar, ac) = antennas[i];

				for (int j = i + 1; j < antennas.Count; j++)
				{
					var (br, bc) = antennas[j];
					var dr = br - ar;
					var dc = bc - ac;

					for (int n = nmin; n <= nmax; n++)
					{
						var a = (ar - dr * n, ac - dc * n);
						var b = (br + dr * n, bc + dc * n);

						if (!InBounds(a) && !InBounds(b))
						{
							break;
						}

						nodes.Add(a);
						nodes.Add(b);
					}
				}
			}
		}

		return nodes.Count(InBounds);

		bool InBounds(Point p) =>
			0 <= p.R && p.R < input.Length &&
			0 <= p.C && p.C < input[0].Length;
	}

	private Dictionary<char, List<Point>> Parse()
	{
		var map = new Dictionary<char, List<Point>>();

		for (int row = 0; row < input.Length; row++)
		{
			for (int col = 0; col < input[row].Length; col++)
			{
				var c = input[row][col];

				if (c is not '.')
				{
					if (!map.TryGetValue(c, out var value))
					{
						map[c] = value = [];
					}

					value.Add((row, col));
				}
			}
		}

		return map;
	}
}
