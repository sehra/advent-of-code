using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day24
	{
		private readonly string[] _input;

		public Day24(string input)
		{
			_input = input.ToLines();
		}

		public int Part1()
		{
			return Parse().Count;
		}

		public int Part2()
		{
			var curr = Parse();

			for (int i = 0; i < 100; i++)
			{
				var next = new HashSet<Tile>();
				var xmin = curr.Min(t => t.X) - 1;
				var xmax = curr.Max(t => t.X) + 1;
				var ymin = curr.Min(t => t.Y) - 1;
				var ymax = curr.Max(t => t.Y) + 1;
				var zmin = curr.Min(t => t.Z) - 1;
				var zmax = curr.Max(t => t.Z) + 2;

				for (int x = xmin; x <= xmax; x++)
				{
					for (int y = ymin; y <= ymax; y++)
					{
						for (int z = zmin; z <= zmax; z++)
						{
							if (x + y + z is 0)
							{
								var tile = new Tile(x, y, z);
								var count =
									(curr.Contains(tile.E()) ? 1 : 0) +
									(curr.Contains(tile.SW()) ? 1 : 0) +
									(curr.Contains(tile.SE()) ? 1 : 0) +
									(curr.Contains(tile.W()) ? 1 : 0) +
									(curr.Contains(tile.NW()) ? 1 : 0) +
									(curr.Contains(tile.NE()) ? 1 : 0);

								if (curr.Contains(tile))
								{
									if (count is 1 or 2)
									{
										next.Add(tile);
									}
								}
								else if (count is 2)
								{
									next.Add(tile);
								}
							}
						}
					}
				}

				curr = next;
			}

			return curr.Count;
		}

		private record Tile(int X, int Y, int Z)
		{
			public Tile E() => new(X + 1, Y - 1, Z);
			public Tile SE() => new(X, Y - 1, Z + 1);
			public Tile SW() => new(X - 1, Y, Z + 1);
			public Tile W() => new(X - 1, Y + 1, Z);
			public Tile NW() => new(X, Y + 1, Z - 1);
			public Tile NE() => new(X + 1, Y, Z - 1);
		}

		private HashSet<Tile> Parse()
		{
			var floor = new HashSet<Tile>();

			for (int i = 0; i < _input.Length; i++)
			{
				var line = _input[i].AsSpan();
				var tile = new Tile(0, 0, 0);

				while (!line.IsEmpty)
				{
					if (line[0] is 'e')
					{
						tile = tile.E();
					}
					else if (line[0] is 'w')
					{
						tile = tile.W();
					}
					else if (line[0] is 's')
					{
						if (line[1] is 'e')
						{
							tile = tile.SE();
						}
						else if (line[1] is 'w')
						{
							tile = tile.SW();
						}

						line = line.Slice(1);
					}
					else if (line[0] is 'n')
					{
						if (line[1] is 'e')
						{
							tile = tile.NE();
						}
						else if (line[1] is 'w')
						{
							tile = tile.NW();
						}

						line = line.Slice(1);
					}

					line = line.Slice(1);
				}

				if (floor.Contains(tile))
				{
					floor.Remove(tile);
				}
				else
				{
					floor.Add(tile);
				}
			}

			return floor;
		}
	}
}
