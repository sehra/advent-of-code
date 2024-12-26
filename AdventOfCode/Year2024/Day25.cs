namespace AdventOfCode.Year2024;

public class Day25(string[] input)
{
	public int Part1()
	{
		var locks = new List<string[]>();
		var keys = new List<string[]>();

		foreach (var chunk in input.Chunk(7))
		{
			if (chunk[0].StartsWith('#'))
			{
				locks.Add(chunk);
			}
			else
			{
				keys.Add(chunk);
			}
		}

		var matches =
			from l in locks
			from k in keys
			let p = l.Zip(k)
			where !p.Any(r => r.First.Zip(r.Second).Any(c => c is ('#', '#')))
			select 1;

		return matches.Count();
	}

	public string Part2()
	{
		return "get 49 stars";
	}
}
