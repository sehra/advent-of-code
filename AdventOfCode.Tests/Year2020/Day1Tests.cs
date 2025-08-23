namespace AdventOfCode.Year2020;

[TestClass]
public class Day1Tests
{
	[TestMethod]
	[DataRow(514579, "1721\n979\n366\n299\n675\n1456\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[TestMethod]
	[DataRow(241861950, "1721\n979\n366\n299\n675\n1456\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
