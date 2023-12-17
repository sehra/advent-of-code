namespace AdventOfCode.Year2015;

[TestClass]
public class Day2Tests
{
	[DataTestMethod]
	[DataRow(58, "2x3x4")]
	[DataRow(43, "1x1x10")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2([input]).Part1());
	}

	[DataTestMethod]
	[DataRow(34, "2x3x4")]
	[DataRow(14, "1x1x10")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2([input]).Part2());
	}
}
