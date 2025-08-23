namespace AdventOfCode.Year2016;

[TestClass]
public class Day1Tests
{
	[TestMethod]
	[DataRow(5, "R2, L3")]
	[DataRow(2, "R2, R2, R2")]
	[DataRow(12, "R5, L5, R5, R3")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[TestMethod]
	[DataRow(4, "R8, R4, R4, R8")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
