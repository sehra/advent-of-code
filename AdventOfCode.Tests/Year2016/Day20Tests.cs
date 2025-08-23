namespace AdventOfCode.Year2016;

[TestClass]
public class Day20Tests
{
	private const string Input =
		"""
		5-8
		0-2
		4-7
		""";

	[TestMethod]
	[DataRow(3u, Input)]
	public void Part1(uint expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part1(0, 9));
	}

	[TestMethod]
	[DataRow(2, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part2(0, 9));
	}
}
