namespace AdventOfCode.Year2024;

public class Day1(string[] input)
{
	public int Part1()
	{
		var (ls, rs) = Parse();

		return ls.Zip(rs).Sum(p => Math.Abs(p.First - p.Second));
	}

	public int Part2()
	{
		var (ls, rs) = Parse();

		return ls.Sum(l => l * rs.Count(r => r == l));
	}

	private (List<int>, List<int>) Parse()
	{
		var ls = new List<int>(input.Length);
		var rs = new List<int>(input.Length);

		foreach (var line in input)
		{
			var s = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			ls.Add(s[0].ToInt32());
			rs.Add(s[1].ToInt32());
		}

		ls.Sort();
		rs.Sort();

		return (ls, rs);
	}
}
