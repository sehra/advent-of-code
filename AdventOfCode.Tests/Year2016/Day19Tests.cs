namespace AdventOfCode.Year2016;

[TestClass]
public class Day19Tests
{
	[TestMethod]
	[DataRow(3, "5")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part1());
	}

	[TestMethod]
	[DataRow(2, "5")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part2());
	}
}
