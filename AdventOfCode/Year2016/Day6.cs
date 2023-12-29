namespace AdventOfCode.Year2016;

public class Day6(string[] input)
{
	public string Part1()
	{
		var message = input
			.SelectMany(line => line.Index())
			.GroupBy(x => x.Key)
			.Select(g => new
			{
				Pos = g.Key,
				Char = g.GroupBy(c => c).OrderByDescending(c => c.Count()).First().Key.Value,
			})
			.OrderBy(g => g.Pos)
			.Select(g => g.Char)
			.ToArray();

		return new string(message);
	}

	public string Part2()
	{
		var message = input
			.SelectMany(line => line.Index())
			.GroupBy(x => x.Key)
			.Select(g => new
			{
				Pos = g.Key,
				Char = g.GroupBy(c => c).OrderBy(c => c.Count()).First().Key.Value,
			})
			.OrderBy(g => g.Pos)
			.Select(g => g.Char)
			.ToArray();

		return new string(message);
	}
}
