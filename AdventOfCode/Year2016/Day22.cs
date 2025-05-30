namespace AdventOfCode.Year2016;

public class Day22(string[] input)
{
	public int Part1()
	{
		var nodes = Parse();
		var count = 0;

		for (int i = 0; i < nodes.Length; i++)
		{
			for (int j = i + 1; j < nodes.Length; j++)
			{
				count += IsViable(nodes[i], nodes[j]) ? 1 : 0;
				count += IsViable(nodes[j], nodes[i]) ? 1 : 0;
			}
		}

		static bool IsViable(Node a, Node b) =>
			a.Used > 0 && a.Used <= b.Avail;

		return count;
	}

	public int Part2()
	{
		var nodes = Parse().ToDictionary(n => n.ToPoint(), n => n);
		var empty = nodes.Values.Single(n => n.Used is 0);
		var goal = nodes.Values.OrderBy(n => n.Y).ThenByDescending(n => n.X).First().ToPoint();

		int MoveCost()
		{
			var xmax = nodes.Values.Max(n => n.X);
			var ymax = nodes.Values.Max(n => n.Y);
			var done = new HashSet<Point>();
			var work = new PriorityQueue<Point, int>();
			work.Enqueue(empty.ToPoint(), 0);

			while (work.TryDequeue(out var node, out var cost))
			{
				if (!done.Add(node))
				{
					continue;
				}

				if (node == goal)
				{
					return cost;
				}

				foreach (var nbor in node.Neighbors())
				{
					if (nodes.TryGetValue(nbor, out var next) && next.Used <= empty.Avail)
					{
						work.Enqueue(nbor, cost + 1);
					}
				}
			}

			throw new Exception("not found");
		}

		return MoveCost() + (goal.X - 1) * 5;
	}

	private readonly record struct Point(int X, int Y)
	{
		public IEnumerable<Point> Neighbors()
		{
			yield return new(X - 1, Y);
			yield return new(X + 1, Y);
			yield return new(X, Y - 1);
			yield return new(X, Y + 1);
		}
	}

	private readonly record struct Node(int X, int Y, int Size, int Used, int Avail)
	{
		public Point ToPoint() => new(X, Y);
	}

	private Node[] Parse() => [.. input
		.Where(line => line.StartsWith("/dev/grid/node"))
		.Select(line => line.Split(" xy-T%".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)[1..].ToInt32())
		.Select(nums => new Node(nums[0], nums[1], nums[2], nums[3], nums[4]))];
}
