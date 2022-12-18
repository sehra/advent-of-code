namespace AdventOfCode.Year2022;

public class Day18
{
	private readonly string[] _input;

	public Day18(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var cubes = Parse();

		return cubes
			.SelectMany(cube => cube.Adjacent())
			.Count(cube => !cubes.Contains(cube));
	}

	public int Part2()
	{
		var cubes = Parse();
		var xmin = cubes.Min(c => c.X) - 1;
		var xmax = cubes.Max(c => c.X) + 1;
		var ymin = cubes.Min(c => c.Y) - 1;
		var ymax = cubes.Max(c => c.Y) + 1;
		var zmin = cubes.Min(c => c.Z) - 1;
		var zmax = cubes.Max(c => c.Z) + 1;

		var start = new Cube(xmin, ymin, zmin);
		var count = 0;

		var done = new HashSet<Cube>() { start };
		var work = new Stack<Cube>();
		work.Push(start);

		while (work.TryPop(out var curr))
		{
			foreach (var next in curr.Adjacent())
			{
				if (cubes.Contains(next))
				{
					count++;
				}
				else if (InBounds(next) && done.Add(next))
				{
					work.Push(next);
				}
			}
		}

		return count;

		bool InBounds(Cube c) =>
			xmin <= c.X && c.X <= xmax &&
			ymin <= c.Y && c.Y <= ymax &&
			zmin <= c.Z && c.Z <= zmax;
	}

	private HashSet<Cube> Parse() => _input.Select(Cube.Parse).ToHashSet();

	private readonly record struct Cube(int X, int Y, int Z)
	{
		public static Cube Parse(string line)
		{
			var split = line.Split(',');
			return new(split[0].ToInt32(), split[1].ToInt32(), split[2].ToInt32());
		}

		public IEnumerable<Cube> Adjacent()
		{
			yield return this with { X = X - 1 };
			yield return this with { X = X + 1 };
			yield return this with { Y = Y - 1 };
			yield return this with { Y = Y + 1 };
			yield return this with { Z = Z - 1 };
			yield return this with { Z = Z + 1 };
		}
	}
}
