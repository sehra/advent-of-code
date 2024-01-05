namespace AdventOfCode.Year2018;

[TestClass]
public class Day5Tests
{
	[DataTestMethod]
	[DataRow(0, "aA")]
	[DataRow(0, "abBA")]
	[DataRow(4, "abAB")]
	[DataRow(6, "aabAAB")]
	[DataRow(10, "dabAcCaCBAcCcaDA")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part1());
	}

	[DataTestMethod]
	[DataRow(4, "dabAcCaCBAcCcaDA")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part2());
	}
}
