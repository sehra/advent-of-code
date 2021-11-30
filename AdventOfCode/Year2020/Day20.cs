using System.Diagnostics;
using System.Text;

namespace AdventOfCode.Year2020;

public class Day20
{
	private readonly string[] _input;

	public Day20(string input)
	{
		_input = input.ToLines();
	}

	public long Part1()
	{
		var tiles = Parse();
		var matches = MatchTiles(tiles);

		return matches
			.Where(s => s.Value.Count == 2)
			.Aggregate(1L, (i, j) => i *= j.Key.Id);
	}

	public long Part2()
	{
		var tiles = Parse();
		var matches = MatchTiles(tiles);

		// assume a square grid
		var count = (int)Math.Sqrt(tiles.Length);
		var grid = new Tile[count, count];

		// place a corner
		var corner = matches.First(t => t.Value.Count == 2);
		grid[0, 0] = corner.Key;
		grid[1, 0] = corner.Value[0];
		grid[0, 1] = corner.Value[1];

		// place the rest
		var used = new HashSet<Tile>()
		{
			grid[0, 0],
			grid[0, 1],
			grid[1, 0],
		};

		while (used.Count != count * count)
		{
			for (int x = 0; x < count; x++)
			{
				for (int y = 0; y < count; y++)
				{
					if (grid[x, y] is not null)
					{
						continue;
					}

					var options = tiles.Except(used).ToHashSet();
					var steps = new[]
					{
						(x: x - 1, y),
						(x: x + 1, y),
						(x, y: y - 1),
						(x, y: y + 1),
					};

					foreach (var step in steps)
					{
						if (0 <= step.x && step.x < count &&
							0 <= step.y && step.y < count &&
							grid[step.x, step.y] is not null)
						{
							options.IntersectWith(matches[grid[step.x, step.y]]);
						}
					}

					if (options.Count is 1)
					{
						grid[x, y] = options.First();
						used.Add(options.First());
					}
				}
			}
		}

		var done = false;

		// orient a corner
		for (int face = 0; !done && face < 8; face++)
		{
			grid[0, 0].SetFace(face);

			for (int i = 0; !done && i < 8; i++)
			{
				for (int j = 0; !done && j < 8; j++)
				{
					if (grid[0, 0].GetSide('D').SequenceEqual(grid[0, 1].GetSide('U', i)) &&
						grid[0, 0].GetSide('R').SequenceEqual(grid[1, 0].GetSide('L', j)))
					{
						done = true;
					}
				}
			}
		}

		// orient top row
		for (int x = 0; x < count - 1; x++)
		{
			for (int face = 0; face < 8; face++)
			{
				if (grid[x, 0].GetSide('R').SequenceEqual(grid[x + 1, 0].GetSide('L', face)))
				{
					grid[x + 1, 0].SetFace(face);
					break;
				}
			}

		}

		// orient the rest
		for (int x = 0; x < count; x++)
		{
			for (int y = 0; y < count - 1; y++)
			{
				for (int face = 0; face < 8; face++)
				{
					if (grid[x, y].GetSide('D').SequenceEqual(grid[x, y + 1].GetSide('U', face)))
					{
						grid[x, y + 1].SetFace(face);
						break;
					}
				}
			}
		}

		// assemble image
		var image = new char[count * 8, count * 8];

		for (int x = 0; x < count; x++)
		{
			for (int y = 0; y < count; y++)
			{
				grid[x, y].CopyTo(image, x * 8, y * 8);
			}
		}

		// find monsters (15 pixels total)
		var monster = new[]
		{
				"                  # ",
				"#    ##    ##    ###",
				" #  #  #  #  #  #   ",
			};

		var roughness = 0;

		for (int x = 0; x < count * 8; x++)
		{
			for (int y = 0; y < count * 8; y++)
			{
				if (image[x, y] == '#')
				{
					roughness++;
				}
			}
		}

		for (int face = 0; face < 8; face++)
		{
			var found = 0;

			for (int x = 0; x < count * 8 - monster[0].Length; x++)
			{
				for (int y = 0; y < count * 8 - monster.Length; y++)
				{
					if (IsMonster(x, y, face))
					{
						found++;
					}
				}
			}

			if (found > 0)
			{
				return roughness - found * 15;
			}
		}

		throw new Exception("not found");

		bool IsMonster(int x, int y, int face)
		{
			for (int my = 0; my < monster.Length; my++)
			{
				for (int mx = 0; mx < monster[my].Length; mx++)
				{
					if (monster[my][mx] == '#' && GetPixel(x + mx, y + my, face) != '#')
					{
						return false;
					}
				}
			}

			return true;
		}

		char GetPixel(int x, int y, int face) => face switch
		{
			0 => image[x, y],
			1 => image[count * 8 - 1 - x, count * 8 - 1 - y],
			2 => image[count * 8 - 1 - y, x],
			3 => image[y, count * 8 - 1 - x],
			4 => image[count * 8 - 1 - x, y],
			5 => image[x, count * 8 - 1 - y],
			6 => image[y, x],
			7 => image[count * 8 - 1 - y, count * 8 - 1 - x],
			_ => '?',
		};
	}

	private Tile[] Parse()
	{
		return _input
			.Chunk(11)
			.Select(buffer => new Tile(buffer))
			.ToArray();
	}

	private static Dictionary<Tile, List<Tile>> MatchTiles(IList<Tile> tiles)
	{
		var sides = new Dictionary<Tile, List<Tile>>();

		for (int i = 0; i < tiles.Count; i++)
		{
			var tile1 = tiles[i];
			sides.TryAdd(tile1, new());

			for (int j = i + 1; j < tiles.Count; j++)
			{
				var tile2 = tiles[j];
				sides.TryAdd(tile2, new());

				if (tile1.Matches(tile2))
				{
					sides[tile1].Add(tile2);
					sides[tile2].Add(tile1);
				}
			}
		}

		return sides;
	}

	[DebuggerDisplay("{Id} {Face,nq}")]
	private class Tile
	{
		private readonly char[,,] _data = new char[8, 10, 10];
		private int _face;

		public Tile(IList<string> tile)
		{
			Id = tile[0].AsSpan(5, 4).ToInt64();

			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
				{
					_data[0, x, y] = tile[y + 1][x]; // U
				}
			}

			for (int x = 0; x < 10; x++)
			{
				for (int y = 0; y < 10; y++)
				{
					_data[1, x, y] = _data[0, 9 - x, 9 - y]; // D
					_data[2, x, y] = _data[0, 9 - y, x]; // L
					_data[3, x, y] = _data[0, y, 9 - x]; // R
					_data[4, x, y] = _data[0, 9 - x, y]; // UF
					_data[5, x, y] = _data[0, x, 9 - y]; // DF
					_data[6, x, y] = _data[0, y, x]; // LF
					_data[7, x, y] = _data[0, 9 - y, 9 - x]; // RF
				}
			}
		}

		public long Id { get; }

		public string DebugView
		{
			get
			{
				var sb = new StringBuilder();

				for (int y = 0; y < 10; y++)
				{
					for (int x = 0; x < 10; x++)
					{
						sb.Append(_data[_face, x, y]);
					}

					sb.AppendLine();
				}

				return sb.ToString();
			}
		}

		private string Face => _face switch
		{
			0 => "U",
			1 => "D",
			2 => "L",
			3 => "R",
			4 => "UF",
			5 => "DF",
			6 => "LF",
			7 => "RF",
			_ => "?",
		};

		public void SetFace(int face)
		{
			Debug.Assert(0 <= face && face <= 8);
			_face = face;
		}

		public void CopyTo(char[,] buffer, int xoff, int yoff)
		{
			for (int x = 0; x < 8; x++)
			{
				for (int y = 0; y < 8; y++)
				{
					buffer[xoff + x, yoff + y] = _data[_face, x + 1, y + 1];
				}
			}
		}

		public IEnumerable<char> GetSide(char side, int? face = default)
		{
			for (int i = 0; i < 10; i++)
			{
				var x = side switch
				{
					'L' => 0,
					'R' => 9,
					_ => i,
				};
				var y = side switch
				{
					'U' => 0,
					'D' => 9,
					_ => i,
				};

				yield return _data[face ?? _face, x, y];
			}
		}

		public bool Matches(Tile tile)
		{
			var sides = new[]
			{
				GetSide('U'),
				GetSide('D'),
				GetSide('L'),
				GetSide('R'),
			};

			for (int i = 0; i < 8; i++)
			{
				if (sides.Any(c => c.SequenceEqual(tile.GetSide('U', i))))
				{
					return true;
				}
			}

			return false;
		}
	}
}
