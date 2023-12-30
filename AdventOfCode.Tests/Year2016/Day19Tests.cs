namespace AdventOfCode.Year2016;

[TestClass]
public class Day19Tests
{
	[DataTestMethod]
	[DataRow(3, "5")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part1());
	}

	[DataTestMethod]
	[DataRow(2, "5")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part2());
	}
}
