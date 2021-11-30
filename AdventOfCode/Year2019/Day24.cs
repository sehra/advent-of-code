namespace AdventOfCode.Year2019;

public class Day24
{
	private readonly string _input;

	public Day24(string input)
	{
		_input = input;
	}

	public int Part1()
	{
		var curr = _input.Replace("\r", "").Replace("\n", "").Select(c => c == '#' ? 1 : 0).ToArray();
		var seen = new HashSet<string> { String.Join("", curr) };

		while (true)
		{
			var next = new int[curr.Length];

			for (int i = 0; i < next.Length; i++)
			{
				next[i] = (curr[i], GetAdj(i % 5, i / 5)) switch
				{
					(1, 1) => 1,
					(0, 1) => 1,
					(0, 2) => 1,
					(_, _) => 0,
				};
			}

			curr = next;
			var key = String.Join("", next);

			if (seen.Contains(key))
			{
				break;
			}

			seen.Add(key);
		}

		return curr.Select((v, i) => v * (int)Math.Pow(2, i)).Sum();

		int GetAdj(int x, int y) => Get(x - 1, y) + Get(x + 1, y) + Get(x, y - 1) + Get(x, y + 1);
		int Get(int x, int y) => x < 0 || x >= 5 || y < 0 || y >= 5 ? 0 : curr[(y * 5) + x];
	}

	public int Part2(int minutes = 200)
	{
		var curr = new Dictionary<int, int[]>
		{
			[0] = _input.Replace("\r", "").Replace("\n", "").Select(c => c == '#' ? 1 : 0).ToArray(),
		};

		for (int minute = 0; minute < minutes; minute++)
		{
			var next = new Dictionary<int, int[]>();

			for (int z = curr.Keys.Min() - 1; z <= curr.Keys.Max() + 1; z++)
			{
				next[z] = new int[5 * 5];
			}

			var remove = new List<int>();

			foreach (var (z, n) in next)
			{
				for (int i = 0; i < n.Length; i++)
				{
					if (i == 12)
					{
						continue;
					}

					var c = curr.ContainsKey(z) ? curr[z] : new int[5 * 5];

					n[i] = (c[i], GetAdj(i % 5, i / 5, z)) switch
					{
						(1, 1) => 1,
						(0, 1) => 1,
						(0, 2) => 1,
						(_, _) => 0,
					};
				}

				if (Array.IndexOf(n, 1) == -1)
				{
					remove.Add(z);
				}
			}

			foreach (var z in remove)
			{
				next.Remove(z);
			}

			curr = next;
		}

		return curr.Sum(kv => kv.Value.Count(c => c == 1));

		int GetAdj(int x, int y, int z)
		{
			var u = (x, y) switch
			{
				(2, 3) => Get(0, 4, z + 1) + Get(1, 4, z + 1) + Get(2, 4, z + 1) + Get(3, 4, z + 1) + Get(4, 4, z + 1),
				(_, 0) => Get(2, 1, z - 1),
				(_, _) => Get(x, y - 1, z),
			};
			var d = (x, y) switch
			{
				(2, 1) => Get(0, 0, z + 1) + Get(1, 0, z + 1) + Get(2, 0, z + 1) + Get(3, 0, z + 1) + Get(4, 0, z + 1),
				(_, 4) => Get(2, 3, z - 1),
				(_, _) => Get(x, y + 1, z),
			};
			var l = (x, y) switch
			{
				(3, 2) => Get(4, 0, z + 1) + Get(4, 1, z + 1) + Get(4, 2, z + 1) + Get(4, 3, z + 1) + Get(4, 4, z + 1),
				(0, _) => Get(1, 2, z - 1),
				(_, _) => Get(x - 1, y, z),
			};
			var r = (x, y) switch
			{
				(1, 2) => Get(0, 0, z + 1) + Get(0, 1, z + 1) + Get(0, 2, z + 1) + Get(0, 3, z + 1) + Get(0, 4, z + 1),
				(4, _) => Get(3, 2, z - 1),
				(_, _) => Get(x + 1, y, z),
			};

			return u + d + l + r;
		}

		int Get(int x, int y, int z) => x >= 0 && x < 5 && y >= 0 && y < 5
			? curr.TryGetValue(z, out var arr) ? arr[(y * 5) + x] : 0 : 0;
	}
}
