namespace AdventOfCode.Year2016;

public class Day7(string[] input)
{
	public int Part1()
	{
		return input.Count(SupportTls);

		static bool SupportTls(string line)
		{
			var split = line.Split('[', ']');
			var outside = false;
			var inside = true;

			for (int i = 0; i < split.Length; i++)
			{
				var abba = split[i]
					.Window(4)
					.Any(x => x[0] != x[1] && x[0] == x[3] && x[1] == x[2]);

				if (abba)
				{
					if (i % 2 == 0)
					{
						outside = true;
					}
					else
					{
						inside = false;
					}
				}
			}

			return inside && outside;
		}
	}

	public int Part2()
	{
		return input.Count(SupportSsl);

		static bool SupportSsl(string line)
		{
			var split = line.Split('[', ']');
			var abas = new HashSet<char[]>(new Comparer());

			for (int i = 0; i < split.Length; i += 2)
			{
				abas.UnionWith(split[i].Window(3).Where(x => x[0] != x[1] && x[0] == x[2]));
			}

			if (abas.Count is 0)
			{
				return false;
			}

			for (int i = 1; i < split.Length; i += 2)
			{
				var babs = split[i]
					.Window(3)
					.Where(x => x[0] != x[1] && x[0] == x[2])
					.Select(x => new[] { x[1], x[0], x[1] })
					.Any(abas.Contains);

				if (babs)
				{
					return true;
				}
			}

			return false;
		}
	}

	private class Comparer : IEqualityComparer<char[]>
	{
		public bool Equals(char[] x, char[] y) =>
			x.SequenceEqual(y);

		public int GetHashCode(char[] obj) =>
			obj.Aggregate(0, HashCode.Combine);
	}
}
