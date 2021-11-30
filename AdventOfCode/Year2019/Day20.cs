namespace AdventOfCode.Year2019;

public class Day20
{
	private readonly string[] _input;

	public Day20(string input)
	{
		_input = input.Split('\n').Select(l => l.Trim('\r')).ToArray();
	}

	public int Part1()
	{
		var (map, jmp, src, dst, _) = ParseMap();

		var done = new HashSet<(int, int)> { src };
		var next = new Queue<((int, int) pos, int dist)>();
		next.Enqueue((src, 0));

		while (next.TryDequeue(out var node))
		{
			if (node.pos == dst)
			{
				return node.dist;
			}

			foreach (var dir in "UDLR")
			{
				var pos = jmp.ContainsKey((node.pos, dir))
					? jmp[(node.pos, dir)].pos
					: Step(node.pos, dir);

				if (!done.Contains(pos) && map.Contains(pos))
				{
					done.Add(pos);
					next.Enqueue((pos, node.dist + 1));
				}
			}
		}

		throw new Exception("not found");
	}

	public int Part2()
	{
		var (map, jmp, src, dst, lim) = ParseMap();

		var done = new HashSet<((int, int), int)> { (src, 0) };
		var next = new Queue<((int x, int y) pos, int lvl, int dist)>();
		next.Enqueue((src, 0, 0));

		while (next.TryDequeue(out var node))
		{
			if (node.lvl == 0 && node.pos == dst)
			{
				return node.dist;
			}

			foreach (var dir in "UDLR")
			{
				var pos = node.pos;
				var lvl = node.lvl;

				if (jmp.ContainsKey((pos, dir)))
				{
					if (OnOuterEdge(pos))
					{
						if (node.lvl > 0)
						{
							pos = jmp[(pos, dir)].pos;
							lvl--;
						}
					}
					else
					{
						pos = jmp[(pos, dir)].pos;
						lvl++;
					}
				}
				else
				{
					pos = Step(node.pos, dir);
				}

				if (!done.Contains((pos, lvl)) && map.Contains(pos))
				{
					done.Add((pos, lvl));
					next.Enqueue((pos, lvl, node.dist + 1));
				}
			}
		}

		throw new Exception("not found");

		bool OnOuterEdge((int x, int y) pos) =>
			pos.x == lim.xmin || pos.x == lim.xmax || pos.y == lim.ymin || pos.y == lim.ymax;
	}

	private (HashSet<(int x, int y)> map,
		Dictionary<((int x, int y) pos, char dir), ((int x, int y) pos, string dbg)> jmp,
		(int x, int y) src, (int x, int y) dst,
		(int xmin, int xmax, int ymin, int ymax) lim
		) ParseMap()
	{
		var map = new HashSet<(int, int)>();
		var loc = new Dictionary<string, List<((int, int) pos, char)>>();
		var jmp = new Dictionary<((int, int), char), ((int, int), string)>();
		var lim = (2, _input[0].Length - 3, 2, _input.Length - 3);

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				TryGet(x, y, out var c);

				if (c == '.')
				{
					map.Add((x, y));
				}
				else if (Char.IsLetter(c))
				{
					if (TryGet(x + 1, y, out var r) && Char.IsLetter(r))
					{
						var key = String.Concat(c, r);
						loc.TryAdd(key, new List<((int, int) pos, char dir)>());

						if (TryGet(x + 2, y, out var a) && a == '.')
						{
							loc[key].Add(((x + 2, y), 'L'));
						}
						else if (TryGet(x - 1, y, out var b) && b == '.')
						{
							loc[key].Add(((x - 1, y), 'R'));
						}
					}
					else if (TryGet(x, y + 1, out var d) && Char.IsLetter(d))
					{
						var key = String.Concat(c, d);
						loc.TryAdd(key, new List<((int, int), char)>());

						if (TryGet(x, y + 2, out var a) && a == '.')
						{
							loc[key].Add(((x, y + 2), 'U'));
						}
						else if (TryGet(x, y - 1, out var b) && b == '.')
						{
							loc[key].Add(((x, y - 1), 'D'));
						}
					}
				}
			}
		}

		foreach (var (key, val) in loc.Where(kv => kv.Value.Count == 2))
		{
			jmp.Add(val[0], (val[1].pos, key));
			jmp.Add(val[1], (val[0].pos, key));
		}

		return (map, jmp, loc["AA"][0].pos, loc["ZZ"][0].pos, lim);

		bool TryGet(int x, int y, out char c)
		{
			if (y < 0 || y >= _input.Length || x < 0 || x >= _input[y].Length)
			{
				c = default;
				return false;
			}

			c = _input[y][x];
			return true;
		}
	}

	private static (int, int) Step((int x, int y) pos, char dir) => dir switch
	{
		'U' => (pos.x, pos.y - 1),
		'D' => (pos.x, pos.y + 1),
		'L' => (pos.x - 1, pos.y),
		'R' => (pos.x + 1, pos.y),
		_ => throw new Exception("dir?"),
	};
}
