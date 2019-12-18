using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day18
	{
		private readonly string _input;

		public Day18(string input)
		{
			_input = input;
		}

		public int Part1()
		{
			var (map, pos) = ParseMap();

			return Solve(map, new[] { pos });
		}

		public int Part2()
		{
			var (map, pos) = ParseMap();
			map[pos] = '#';
			map[(pos.x + 1, pos.y)] = '#';
			map[(pos.x - 1, pos.y)] = '#';
			map[(pos.x, pos.y + 1)] = '#';
			map[(pos.x, pos.y - 1)] = '#';

			var bots = new[]
			{
				(pos.x + 1, pos.y + 1),
				(pos.x + 1, pos.y - 1),
				(pos.x - 1, pos.y + 1),
				(pos.x - 1, pos.y - 1),
			};

			return Solve(map, bots);
		}

		private static int Solve(Dictionary<(int, int), char> map, IEnumerable<(int x, int y)> srcs,
			string open = "", Dictionary<(string, string), int> cache = null)
		{
			cache ??= new Dictionary<(string, string), int>();
			open = new string(open.OrderBy(c => c).ToArray());
			var ckey = String.Join("", srcs.OrderBy(v => v.x).ThenBy(v => v.y));

			if (cache.TryGetValue((ckey, open), out var known))
			{
				return known;
			}

			var keys = FindKeys(map, srcs, open);

			if (keys.Count == 0)
			{
				return 0;
			}

			var best = Int32.MaxValue;

			foreach (var (pos, (key, dist, bot)) in keys)
			{
				var bots = srcs.ToList();
				bots[bot] = pos;

				best = Math.Min(best, dist + Solve(map, bots, open + ToDoor(key), cache));
			}

			cache.Add((ckey, open), best);

			return best;
		}

		private static Dictionary<(int, int), (char key, int dist, int bot)> FindKeys(
			Dictionary<(int, int), char> map, IEnumerable<(int, int)> srcs, string open)
		{
			var keys = new Dictionary<(int, int), (char, int, int)>();

			foreach (var (src, i) in srcs.Select((v, i) => (v, i)))
			{
				var done = new HashSet<(int, int)>(new[] { src });
				var next = new Queue<((int, int) pos, int dist)>();
				next.Enqueue((src, 0));

				while (next.TryDequeue(out var node))
				{
					var c = map[node.pos];

					if (IsKey(c) && !open.Contains(ToDoor(c)))
					{
						keys.TryAdd(node.pos, (c, node.dist, i));
					}

					foreach (var dir in "NSWE")
					{
						var test = Step(node.pos, dir);

						if (!done.Contains(test) && IsOpen(map, test, open))
						{
							done.Add(test);
							next.Enqueue((test, node.dist + 1));
						}
					}
				}
			}

			return keys;
		}

		private static bool IsOpen(Dictionary<(int, int), char> map, (int, int) pos, string open) =>
			map.TryGetValue(pos, out var c) && (c == '.' || IsKey(c) || open.Contains(c));

		private static bool IsKey(char c) => Char.IsLower(c);

		private static char ToDoor(char c) => Char.ToUpper(c);

		private (Dictionary<(int x, int y), char> map, (int x, int y) pos) ParseMap()
		{
			var map = new Dictionary<(int, int), char>();
			var pos = (0, 0);

			foreach (var (line, y) in _input.Split('\n').Select((line, y) => (line, y)))
			{
				foreach (var (value, x) in line.Trim().Select((value, x) => (value, x)))
				{
					if (value == '@')
					{
						pos = (x, y);
						map.Add(pos, '.');
					}
					else
					{
						map.Add((x, y), value);
					}
				}
			}

			return (map, pos);
		}

		private static (int, int) Step((int x, int y) pos, char dir) => dir switch
		{
			'N' => (pos.x, pos.y - 1),
			'S' => (pos.x, pos.y + 1),
			'W' => (pos.x - 1, pos.y),
			'E' => (pos.x + 1, pos.y),
			_ => throw new Exception("dir?"),
		};
	}
}
