namespace AdventOfCode.Year2024;

using Vec = Vec2<int>;

public class Day15(string[] input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	public int Solve(bool part2)
	{
		var (map, pos, ins) = Parse(part2);

		foreach (var c in ins)
		{
			Vec dir = c switch
			{
				'^' => (0, -1),
				'v' => (0, +1),
				'<' => (-1, 0),
				'>' => (+1, 0),
				_ => throw new Exception("dir?"),
			};

			if (CanPush(pos, dir))
			{
				Push(pos, dir);
				pos += dir;
			}
		}

		return map
			.Where(kv => kv.Value is 'O' or '[')
			.Sum(kv => kv.Key.Y * 100 + kv.Key.X);

		bool CanPush(Vec s, Vec d)
		{
			var n = s + d;
			var c = map[n];

			if (c is '#')
			{
				return false;
			}
			else if (c is '.')
			{
				return true;
			}
			else if (d.Y is 0 || !part2)
			{
				return CanPush(n, d);
			}
			else
			{
				return CanPush(n, d) && CanPush(n + (c is '[' ? +1 : -1, 0), d);
			}
		}

		void Push(Vec s, Vec d)
		{
			var n = s + d;
			var c = map[n];

			if (c is '#')
			{
				return;
			}
			else if (c is '.')
			{
				// fall through
			}
			else if (d.Y is 0 || !part2)
			{
				Push(n, d);
			}
			else
			{
				Push(n, d);
				Push(n + (c is '[' ? +1 : -1, 0), d);
			}

			(map[s], map[n]) = (map[n], map[s]);
		}
	}

	private (Dictionary<Vec, char>, Vec, string) Parse(bool part2)
	{
		var map = new Dictionary<Vec, char>();
		var pos = default(Vec);
		var ins = "";

		for (int y = 0; y < input.Length; y++)
		{
			if (input[y] is ['#', ..])
			{
				for (int x = 0, xx = 0; x < input[y].Length; x++)
				{
					var c = input[y][x];

					if (c is '@')
					{
						pos = (x + xx, y);

						if (part2)
						{
							map[(x + xx, y)] = '.';
							map[(x + ++xx, y)] = '.';
						}
						else
						{
							map[pos] = '.';
						}
					}
					else
					{
						if (part2)
						{
							map[(x + xx, y)] = c is 'O' ? '[' : c;
							map[(x + ++xx, y)] = c is 'O' ? ']' : c;
						}
						else
						{
							map[(x, y)] = c;
						}
					}
				}
			}
			else
			{
				ins += input[y];
			}
		}

		return (map, pos, ins);
	}
}
