namespace AdventOfCode.Year2017;

[TestClass]
public class Day14Tests
{
	[DataTestMethod]
	[DataRow(8108, "flqrgnkx")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part1());
	}

	[DataTestMethod]
	[DataRow(1242, "flqrgnkx")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part2());
	}
}
