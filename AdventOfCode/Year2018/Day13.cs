namespace AdventOfCode.Year2018;

[SkipInputTrim]
public class Day13(string input)
{
	public string Part1()
	{
		var (track, carts) = Parse();

		while (true)
		{
			carts.Sort();

			for (int i = 0; i < carts.Count; i++)
			{
				var cart = carts[i];
				cart = cart.Step();
				cart = cart.Turn(track[cart.Y][cart.X]);
				carts[i] = cart;

				for (int j = 1; j < carts.Count; j++)
				{
					var other = carts[(i + j) % carts.Count];

					if (cart.X == other.X && cart.Y == other.Y)
					{
						return $"{cart.X},{cart.Y}";
					}
				}
			}
		}
	}

	public string Part2()
	{
		var (track, carts) = Parse();

		while (true)
		{
			carts.Sort();

			for (int i = 0; i < carts.Count; i++)
			{
				var cart = carts[i];

				if (cart.S)
				{
					continue;
				}

				cart = cart.Step();
				cart = cart.Turn(track[cart.Y][cart.X]);
				carts[i] = cart;

				for (int j = 1; j < carts.Count; j++)
				{
					var other = carts[(i + j) % carts.Count];

					if (!other.S && cart.X == other.X && cart.Y == other.Y)
					{
						carts[i] = cart with { S = true };
						carts[(i + j) % carts.Count] = other with { S = true };
						break;
					}
				}
			}

			if (carts.Count(cart => !cart.S) is 1)
			{
				var last = carts.Single(cart => !cart.S);
				return $"{last.X},{last.Y}";
			}
		}
	}

	private readonly record struct Cart(int X, int Y, char D, char T = 'L', bool S = false) : IComparable<Cart>
	{
		public Cart Step() => D switch
		{
			'U' => this with { Y = Y - 1 },
			'D' => this with { Y = Y + 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("dir?"),
		};

		public Cart Turn(char track) => (track, D, T) switch
		{
			('+', 'U', 'L') => this with { D = 'L', T = Next(T) },
			('+', 'U', 'R') => this with { D = 'R', T = Next(T) },
			('+', 'D', 'L') => this with { D = 'R', T = Next(T) },
			('+', 'D', 'R') => this with { D = 'L', T = Next(T) },
			('+', 'L', 'L') => this with { D = 'D', T = Next(T) },
			('+', 'L', 'R') => this with { D = 'U', T = Next(T) },
			('+', 'R', 'L') => this with { D = 'U', T = Next(T) },
			('+', 'R', 'R') => this with { D = 'D', T = Next(T) },
			('+', _, 'S') => this with { T = Next(T) },
			('/', 'U', _) => this with { D = 'R' },
			('/', 'D', _) => this with { D = 'L' },
			('/', 'L', _) => this with { D = 'D' },
			('/', 'R', _) => this with { D = 'U' },
			('\\', 'U', _) => this with { D = 'L' },
			('\\', 'D', _) => this with { D = 'R' },
			('\\', 'L', _) => this with { D = 'U' },
			('\\', 'R', _) => this with { D = 'D' },
			_ => this,
		};

		public int CompareTo(Cart other)
		{
			var cmp = Y.CompareTo(other.Y);
			if (cmp != 0) return cmp;
			return X.CompareTo(other.X);
		}

		private static char Next(char turn) => turn switch
		{
			'L' => 'S',
			'S' => 'R',
			'R' => 'L',
			_ => throw new Exception("turn?"),
		};
	}

	private (string[] Track, List<Cart> Carts) Parse()
	{
		var lines = input.ToLines(StringSplitOptions.None);
		var carts = new List<Cart>();

		for (int y = 0; y < lines.Length; y++)
		{
			for (int x = 0; x < lines[y].Length; x++)
			{
				var c = lines[y][x];

				if (c is '^' or 'v' or '<' or '>')
				{
					var dir = c switch
					{
						'^' => 'U',
						'v' => 'D',
						'<' => 'L',
						'>' => 'R',
						_ => throw new Exception("dir?"),
					};
					carts.Add(new(x, y, dir));
				}
			}
		}

		return (lines, carts);
	}
}
