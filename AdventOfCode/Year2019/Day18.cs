﻿namespace AdventOfCode.Year2019;

public class Day18
{
	private readonly string[] _input;

	public Day18(string input)
	{
		_input = input.Split('\n').Select(l => l.Trim()).ToArray();
	}

	public int Part1()
	{
		var (map, _) = ParseMap();

		return Solve(CalculateKeyMap(map), "@", "", new Dictionary<string, int>(StringComparer.Ordinal));
	}

	public int Part2()
	{
		var (map, pos) = ParseMap();
		map[pos] = '#';
		map[(pos.x + 1, pos.y)] = '#';
		map[(pos.x - 1, pos.y)] = '#';
		map[(pos.x, pos.y + 1)] = '#';
		map[(pos.x, pos.y - 1)] = '#';
		map[(pos.x + 1, pos.y + 1)] = '1';
		map[(pos.x + 1, pos.y - 1)] = '2';
		map[(pos.x - 1, pos.y + 1)] = '3';
		map[(pos.x - 1, pos.y - 1)] = '4';

		return Solve(CalculateKeyMap(map), "1234", "", new Dictionary<string, int>(StringComparer.Ordinal));
	}

	private static Dictionary<char, List<(char, string, int)>> CalculateKeyMap(
		Dictionary<(int x, int y), char> map)
	{
		var keys = new Dictionary<char, List<(char, string, int)>>();
		var allkeys = map.Where(kv => Char.IsLower(kv.Value) || Char.IsDigit(kv.Value) || kv.Value == '@');

		foreach (var (src, key) in allkeys)
		{
			keys.Add(key, []);

			var done = new HashSet<(int, int)> { src };
			var next = new Queue<((int, int) pos, string need, int dist)>();
			next.Enqueue((src, "", 0));

			while (next.TryDequeue(out var node))
			{
				var need = node.need;
				var c = map[node.pos];

				if (c != key && Char.IsLower(c))
				{
					keys[key].Add((c, node.need.ToLower(), node.dist));
				}
				else if (Char.IsUpper(c))
				{
					need += c;
				}

				foreach (var dir in "UDLR")
				{
					var pos = Step(node.pos, dir);

					if (!done.Contains(pos) && map.TryGetValue(pos, out c) && c != '#')
					{
						done.Add(pos);
						next.Enqueue((pos, need, node.dist + 1));
					}
				}
			}
		}

		return keys;

		static (int, int) Step((int x, int y) pos, char dir) => dir switch
		{
			'U' => (pos.x, pos.y - 1),
			'D' => (pos.x, pos.y + 1),
			'L' => (pos.x - 1, pos.y),
			'R' => (pos.x + 1, pos.y),
			_ => throw new Exception("dir?"),
		};
	}

	private static List<(char bot, char key, int dist)> FindKeys(
		Dictionary<char, List<(char bot, string need, int dist)>> keymap, string bots, string open)
	{
		var keys = new List<(char bot, char key, int dist)>();

		foreach (var bot in bots)
		{
			foreach (var (key, need, dist) in keymap[bot])
			{
				if (open.Contains(key) || !need.All(open.Contains))
				{
					continue;
				}

				keys.Add((bot, key, dist));
			}
		}

		return keys;
	}

	private static int Solve(Dictionary<char, List<(char, string, int)>> keymap, string bots, string open,
		Dictionary<string, int> cache)
	{
		var ckey = String.Concat(Sort(bots), ".", Sort(open));

		if (cache.TryGetValue(ckey, out var known))
		{
			return known;
		}

		var keys = FindKeys(keymap, bots, open);

		if (keys.Count == 0)
		{
			return 0;
		}

		var dists = new List<int>(keys.Count);

		foreach (var (bot, key, dist) in keys)
		{
			dists.Add(dist + Solve(keymap, bots.Replace(bot, key), open + key, cache));
		}

		return cache[ckey] = dists.Min();

		static string Sort(string value)
		{
			var chars = value.ToCharArray();
			Array.Sort(chars);

			return new string(chars);
		}
	}

	private (Dictionary<(int x, int y), char> map, (int x, int y) pos) ParseMap()
	{
		var map = new Dictionary<(int, int), char>();
		var pos = (0, 0);

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				var c = _input[y][x];

				if (c == '@')
				{
					pos = (x, y);
				}

				map.Add((x, y), c);
			}
		}

		return (map, pos);
	}
}
