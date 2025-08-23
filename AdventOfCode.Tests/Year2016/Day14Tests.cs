namespace AdventOfCode.Year2016;

[TestClass]
public class Day14Tests
{
	[TestMethod]
	[DataRow(22728, "abc")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part1());
	}

	[Ignore("LongRunning")]
	[TestMethod]
	[DataRow(22551, "abc")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part2());
	}
}
