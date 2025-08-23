namespace AdventOfCode.Year2017;

[TestClass]
public class Day6Tests
{
	private const string Input = "0\t2\t7\t0";

	[TestMethod]
	[DataRow(5, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part1());
	}

	[TestMethod]
	[DataRow(4, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part2());
	}
}
