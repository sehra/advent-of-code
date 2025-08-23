namespace AdventOfCode.Year2018;

[TestClass]
public class Day11Tests
{
	[TestMethod]
	[DataRow("33,45", "18")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part1());
	}

	[TestMethod]
	[DataRow("90,269,16", "18")]
	[DataRow("232,251,12", "42")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part2());
	}
}
