namespace AdventOfCode.Year2024;

[TestClass]
public class Day11Tests
{
	[DataTestMethod]
	[DataRow(55312, "125 17")]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part1());
	}

	[DataTestMethod]
	[DataRow(65601038650482, "125 17")]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part2());
	}
}
