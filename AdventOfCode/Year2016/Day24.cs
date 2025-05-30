namespace AdventOfCode.Year2016;

public class Day24(string[] input)
{
	public int Part1()
	{
		var grid = Parse();
		var dists = PairDists(grid);
		var nums = grid.Values.Except(['0', '.']).ToArray();
		var best = Int32.MaxValue;
		
		foreach (var path in nums.Permutations())
		{
			var dist = path
				.Prepend('0')
				.Window(2)
				.Aggregate(0, (d, p) => d + dists[(p[0], p[1])]);
			best = Math.Min(best, dist);
		}

		return best;
	}

	public int Part2()
	{
		var grid = Parse();
		var dists = PairDists(grid);
		var nums = grid.Values.Except(['0', '.']).ToArray();
		var best = Int32.MaxValue;

		foreach (var path in nums.Permutations())
		{
			var dist = path
				.Prepend('0')
				.Append('0')
				.Window(2)
				.Aggregate(0, (d, p) => d + dists[(p[0], p[1])]);
			best = Math.Min(best, dist);
		}

		return best;
	}

	private static Dictionary<(char, char), int> PairDists(Dictionary<Point, char> grid)
	{
		var visit = grid.Where(kv => kv.Value != '.').ToArray();
		var dists = new Dictionary<(char, char), int>();

		for (int i = 0; i < visit.Length; i++)
		{
			for (int j = i + 1; j < visit.Length; j++)
			{
				var dist = Dist(grid, visit[i].Key, visit[j].Key);
				dists.Add((visit[i].Value, visit[j].Value), dist);
				dists.Add((visit[j].Value, visit[i].Value), dist);
			}
		}

		return dists;
	}

	private static int Dist(Dictionary<Point, char> grid, Point a, Point b)
	{
		var seen = new HashSet<Point>();
		var work = new PriorityQueue<Point, int>();
		work.Enqueue(a, 0);

		while (work.TryDequeue(out var curr, out var steps))
		{
			if (!seen.Add(curr))
			{
				continue;
			}

			if (curr == b)
			{
				return steps;
			}

			foreach (var dir in "NSEW")
			{
				var next = curr.Step(dir);

				if (grid.ContainsKey(next))
				{
					work.Enqueue(next, steps + 1);
				}
			}
		}

		throw new Exception("not found");
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'N' => this with { Y = Y - 1 },
			'S' => this with { Y = Y + 1 },
			'E' => this with { X = X + 1 },
			'W' => this with { X = X - 1 },
			_ => throw new Exception("dir?"),
		};
	}

	private Dictionary<Point, char> Parse()
	{
		var grid = new Dictionary<Point, char>();

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[y].Length; x++)
			{
				var c = input[y][x];

				if (c != '#')
				{
					grid[new(x, y)] = c;
				}
			}
		}

		return grid;
	}
}
