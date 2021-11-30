namespace AdventOfCode.Year2020;

public class Day17
{
	private readonly string[] _input;

	public Day17(string input)
	{
		_input = input.ToLines();
	}

	public int Part1()
	{
		var curr = new HashSet<(int X, int Y, int Z)>();

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				if (_input[y][x] == '#')
				{
					curr.Add((x, y, 0));
				}
			}
		}

		for (int i = 0; i < 6; i++)
		{
			var next = new HashSet<(int, int, int)>();

			var xmin = curr.Min(c => c.X) - 1;
			var xmax = curr.Max(c => c.X) + 1;
			var ymin = curr.Min(c => c.Y) - 1;
			var ymax = curr.Max(c => c.Y) + 1;
			var zmin = curr.Min(c => c.Z) - 1;
			var zmax = curr.Max(c => c.Z) + 1;

			for (int x = xmin; x <= xmax; x++)
			{
				for (int y = ymin; y <= ymax; y++)
				{
					for (int z = zmin; z <= zmax; z++)
					{
						var pos = (x, y, z);
						var adj = Adjacent(pos).Count(p => curr.Contains(p));

						if (curr.Contains(pos))
						{
							if (adj is 2 or 3)
							{
								next.Add(pos);
							}
						}
						else
						{
							if (adj is 3)
							{
								next.Add(pos);
							}
						}
					}
				}
			}

			curr = next;
		}

		return curr.Count;

		static IEnumerable<(int, int, int)> Adjacent((int X, int Y, int Z) pos) =>
			from x in Enumerable.Range(-1, 3)
			from y in Enumerable.Range(-1, 3)
			from z in Enumerable.Range(-1, 3)
			let p = (pos.X + x, pos.Y + y, pos.Z + z)
			where p != pos
			select p;
	}

	public int Part2()
	{
		var curr = new HashSet<(int X, int Y, int Z, int W)>();

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				if (_input[y][x] == '#')
				{
					curr.Add((x, y, 0, 0));
				}
			}
		}

		for (int i = 0; i < 6; i++)
		{
			var next = new HashSet<(int, int, int, int)>();

			var xmin = curr.Min(c => c.X) - 1;
			var xmax = curr.Max(c => c.X) + 1;
			var ymin = curr.Min(c => c.Y) - 1;
			var ymax = curr.Max(c => c.Y) + 1;
			var zmin = curr.Min(c => c.Z) - 1;
			var zmax = curr.Max(c => c.Z) + 1;
			var wmin = curr.Min(c => c.W) - 1;
			var wmax = curr.Max(c => c.W) + 1;

			for (int x = xmin; x <= xmax; x++)
			{
				for (int y = ymin; y <= ymax; y++)
				{
					for (int z = zmin; z <= zmax; z++)
					{
						for (int w = wmin; w <= wmax; w++)
						{
							var pos = (x, y, z, w);
							var adj = Adjacent(pos).Count(p => curr.Contains(p));

							if (curr.Contains(pos))
							{
								if (adj is 2 or 3)
								{
									next.Add(pos);
								}
							}
							else
							{
								if (adj is 3)
								{
									next.Add(pos);
								}
							}
						}
					}
				}
			}

			curr = next;
		}

		return curr.Count;

		static IEnumerable<(int, int, int, int)> Adjacent((int X, int Y, int Z, int W) pos) =>
			from x in Enumerable.Range(-1, 3)
			from y in Enumerable.Range(-1, 3)
			from z in Enumerable.Range(-1, 3)
			from w in Enumerable.Range(-1, 3)
			let p = (pos.X + x, pos.Y + y, pos.Z + z, pos.W + w)
			where p != pos
			select p;
	}
}
