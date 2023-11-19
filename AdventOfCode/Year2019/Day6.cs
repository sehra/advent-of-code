namespace AdventOfCode.Year2019;

public class Day6
{
	private readonly string[][] _input;

	public Day6(string input)
	{
		_input = input.Split('\n').Select(x => x.Split(')').Select(y => y.Trim()).ToArray()).ToArray();
	}

	public int Part1()
	{
		var orbits = GetOrbits();

		return orbits.Sum(x => CountOrbits(orbits, x.Key));
	}

	public int Part2()
	{
		var orbits = GetOrbits();

		return CountTransfers(orbits, "YOU", "SAN");
	}

	public Dictionary<string, HashSet<string>> GetOrbits()
	{
		var result = new Dictionary<string, HashSet<string>>(StringComparer.Ordinal);

		foreach (var orbit in _input)
		{
			if (!result.ContainsKey(orbit[0]))
			{
				result.Add(orbit[0], new HashSet<string>(StringComparer.Ordinal));
			}

			if (!result.ContainsKey(orbit[1]))
			{
				result.Add(orbit[1], new HashSet<string>(StringComparer.Ordinal));
			}

			result[orbit[0]].Add(orbit[1]);
		}

		return result;
	}

	public static int CountOrbits(Dictionary<string, HashSet<string>> orbits, string planet)
	{
		return orbits[planet].Count + orbits[planet].Sum(child => CountOrbits(orbits, child));
	}

	public static int CountTransfers(Dictionary<string, HashSet<string>> orbits, string src, string dst)
	{
		var srcPath = GetPathToRoot(orbits, src, []);
		var dstPath = GetPathToRoot(orbits, dst, []);
		var common = srcPath.Intersect(dstPath, StringComparer.Ordinal).First();

		return srcPath.IndexOf(common) + dstPath.IndexOf(common);
	}

	private static List<string> GetPathToRoot(Dictionary<string, HashSet<string>> orbits, string planet,
		List<string> path)
	{
		var parent = orbits.FirstOrDefault(x => x.Value.Contains(planet));

		if (parent.Key == null)
		{
			return path;
		}

		path.Add(parent.Key);

		return GetPathToRoot(orbits, parent.Key, path);
	}
}
