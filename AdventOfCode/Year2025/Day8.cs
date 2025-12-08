namespace AdventOfCode.Year2025;

using Vec = Vec3<int>;

public class Day8(string[] input)
{
	public int Part1(int count = 1000) => Solve(count);

	public int Part2() => Solve(0);

	private int Solve(int count)
	{
		// https://en.wikipedia.org/wiki/Kruskal%27s_algorithm

		var junctions = Parse();
		var circuits = junctions.Select(x => new HashSet<Vec> { x }).ToList();

		foreach (var (a, b) in Pairs(junctions).OrderBy(Distance))
		{
			var sa = circuits.First(x => x.Contains(a));
			var sb = circuits.First(x => x.Contains(b));

			if (sa != sb)
			{
				sa.UnionWith(sb);
				circuits.Remove(sb);
			}

			if (--count is 0)
			{
				return circuits
					.OrderByDescending(x => x.Count)
					.Take(3)
					.Aggregate(1, (agg, x) => agg * x.Count);
			}

			if (circuits.First().Count == junctions.Length)
			{
				return a.X * b.X;
			}
		}

		throw new Exception("not found");

		static IEnumerable<(Vec, Vec)> Pairs(Vec[] arr)
		{
			for (var i = 0; i < arr.Length; i++)
			{
				for (var j = i + 1; j < arr.Length; j++)
				{
					yield return (arr[i], arr[j]);
				}
			}
		}

		static long Distance((Vec A, Vec B) vs)
		{
			long x = vs.A.X - vs.B.X;
			long y = vs.A.Y - vs.B.Y;
			long z = vs.A.Z - vs.B.Z;

			return x * x + y * y + z * z;
		}
	}

	private Vec[] Parse() => [.. input
		.Select(line =>
		{
			var split = line.Split(',').ToInt32();
			return new Vec(split[0], split[1], split[2]);
		})];
}
