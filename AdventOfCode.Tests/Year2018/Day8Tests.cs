namespace AdventOfCode.Year2018;

[TestClass]
public class Day8Tests
{
	private const string Input = "2 3 0 3 10 11 12 1 1 0 1 99 2 1 1 2";

	[DataTestMethod]
	[DataRow(138, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input).Part1());
	}

	[DataTestMethod]
	[DataRow(66, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input).Part2());
	}
}
