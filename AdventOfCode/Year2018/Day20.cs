namespace AdventOfCode.Year2018;

public class Day20(string input)
{
	public int Part1() => Solve().Max();

	public int Part2() => Solve().Count(dist => dist >= 1000);

	private List<int> Solve()
	{
		var graph = new Dictionary<Point, HashSet<Point>>();
		var point = new Point();
		var stack = new Stack<Point>();

		foreach (var c in input.Skip(1).SkipLast(1))
		{
			if (c is 'N' or 'S' or 'E' or 'W')
			{
				var curr = point;
				var next = point.Step(c);
				graph.TryAdd(curr, []);
				graph.TryAdd(next, []);
				graph[curr].Add(next);
				graph[next].Add(curr);
				point = next;
			}
			else if (c is '(')
            {
                stack.Push(point);
            }
			else if (c is ')')
			{
				point = stack.Pop();
			}
			else if (c is '|')
			{
				point = stack.Peek();
			}
        }

		var dists = new Dictionary<Point, int>();
		var work = new PriorityQueue<Point, int>();
		work.Enqueue(new(), 0);

		while (work.TryDequeue(out var curr, out var dist))
		{
			if (!dists.TryAdd(curr, dist))
			{
				continue;
			}

			foreach (var next in graph[curr])
			{
				work.Enqueue(next, dist + 1);
			}
		}

		return [.. dists.Values];
	}

	private readonly record struct Point(int X, int Y)
	{
		public Point Step(char dir) => dir switch
		{
			'N' => new(X, Y + 1),
			'S' => new(X, Y - 1),
			'E' => new(X + 1, Y),
			'W' => new(X - 1, Y),
			_ => throw new Exception("dir?"),
		};
	}
}
