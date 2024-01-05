namespace AdventOfCode.Year2017;

public class Day24(string[] input)
{
	public int Part1() => Solve()
		.Max(b => b.Strength);

	public int Part2() => Solve()
		.OrderByDescending(b => b.Length)
		.ThenByDescending(b => b.Strength)
		.First().Strength;

	private List<(int Length, int Strength)> Solve()
	{
		var comps = Parse();
		var bridges = new List<(int Length, int Strength)>();
		var work = new Queue<Component[]>();

		// no components with 0 on B side
		foreach (var comp in comps.Where(c => c.A is 0))
		{
			work.Enqueue([comp]);
		}

		while (work.TryDequeue(out var path))
		{
			int free;

			if (path.Length is 1)
			{
				free = path[0].B;
			}
			else
			{
				if (path[^2].A == path[^1].A || path[^2].B == path[^1].A)
				{
					free = path[^1].B;
				}
				else
				{
					free = path[^1].A;
				}
			}

			var nexts = comps
				.Where(c => c.A == free || c.B == free)
				.Except(path)
				.ToArray();

			if (nexts.Length is 0)
			{
				bridges.Add((path.Length, path.Aggregate(0, (a, c) => a + c.A + c.B)));
			}
			else
			{
				foreach (var next in nexts)
				{
					work.Enqueue([.. path, next]);
				}
			}
		}

		return bridges;
	}

	private readonly record struct Component(int A, int B);

	private Component[] Parse() => input
		.Select(line => line.Split('/').ToInt32())
		.Select(line => new Component(line[0], line[1]))
		.ToArray();
}
