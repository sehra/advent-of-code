namespace AdventOfCode.Year2024;

[TestClass]
public class Day9Tests
{
	private const string Input = "2333133121414131402";

	[DataTestMethod]
	[DataRow(1928, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part1());
	}

	[DataTestMethod]
	[DataRow(2858, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part2());
	}
}
