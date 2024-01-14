namespace AdventOfCode.Year2018;

public class Day4(string[] input)
{
	public int Part1()
	{
		var guards = Solve();
		var guard = guards
			.OrderByDescending(kv => kv.Value.Sum(c => c.Value))
			.First();

		return guard.Key * guard.Value.MostCommon(1).Single().Key;
	}

	public int Part2()
	{
		var guards = Solve();
		var guard = guards
			.Where(kv => kv.Value.Count > 0)
			.OrderByDescending(kv => kv.Value.MostCommon(1).Single().Value)
			.First();

		return guard.Key * guard.Value.MostCommon(1).Single().Key;
	}

	private Dictionary<int, Counter<int>> Solve()
	{
		var guards = new Dictionary<int, Counter<int>>();
		var guard = 0;
		var sleep = 0;

		foreach (var line in input.Order())
		{
			if (line.Contains("begins shift"))
			{
				var hash = line.IndexOf('#');
				var space = line.IndexOf(' ', hash);
				guard = line[(hash + 1)..space].ToInt32();
				guards.TryAdd(guard, []);
			}
			else if (line.Contains("falls asleep"))
			{
				var colon = line.IndexOf(':');
				var brack = line.IndexOf(']', colon);
				sleep = line[(colon + 1)..brack].ToInt32();
			}
			else if (line.Contains("wakes up"))
			{
				var colon = line.IndexOf(':');
				var brack = line.IndexOf(']', colon);
				var wakes = line[(colon + 1)..brack].ToInt32();
				guards[guard].Update(Enumerable.Range(sleep, wakes - sleep));
			}
		}

		return guards;
	}
}
