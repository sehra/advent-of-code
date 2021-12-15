namespace AdventOfCode.Year2021;

public class Day15
{
	private readonly string[] _input;

	public Day15(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Solve(Parse());
	}

	public int Part2()
	{
		return Solve(Expand(Parse()));
	}

	private static int Solve(Dictionary<Point, int> risks)
	{
		var source = new Point(0, 0);
		var target = new Point(risks.Keys.Max(p => p.X), risks.Keys.Max(p => p.Y));

		var costs = new DefaultDictionary<Point, int>(Int32.MaxValue)
		{
			[source] = 0,
		};

		var queue = new PriorityQueue<Point, int>();
		queue.Enqueue(source, 0);

		while (queue.TryDequeue(out var current, out var cost))
		{
			if (current == target)
			{
				return cost;
			}

			foreach (var direction in "UDLR")
			{
				var point = current.Step(direction);

				if (!risks.TryGetValue(point, out var risk))
				{
					continue;
				}

				var newCost = cost + risk;

				if (newCost < costs[point])
				{
					costs[point] = newCost;
					queue.Enqueue(point, newCost);
				}
			}
		}

		throw new Exception("not found");
	}

	private static Dictionary<Point, int> Expand(Dictionary<Point, int> risks)
	{
		var result = new Dictionary<Point, int>();
		var height = risks.Keys.Max(p => p.X) + 1;
		var width = risks.Keys.Max(p => p.Y) + 1;

		foreach (var (point, value) in risks)
		{
			for (int x = 0; x < 5; x++)
			{
				for (int y = 0; y < 5; y++)
				{
					var px = point.X + x * height;
					var py = point.Y + y * width;
					var pv = (value + x + y - 1) % 9 + 1;
					result.Add(new(px, py), pv);
				}
			}
		}

		return result;
	}

	private Dictionary<Point, int> Parse()
	{
		var risks = new Dictionary<Point, int>();

		for (int y = 0; y < _input.Length; y++)
		{
			for (int x = 0; x < _input[y].Length; x++)
			{
				risks.Add(new(x, y), _input[y][x] - '0');
			}
		}

		return risks;
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'U' => this with { Y = Y - 1 },
			'D' => this with { Y = Y + 1 },
			'L' => this with { X = X - 1 },
			'R' => this with { X = X + 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private class DefaultDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		private readonly TValue _value;

		public DefaultDictionary(TValue value)
		{
			_value = value;
		}

		public new TValue this[TKey key]
		{
			get => TryGetValue(key, out var value) ? value : _value;
			set => base[key] = value;
		}
	}
}
