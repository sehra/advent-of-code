namespace AdventOfCode.Year2020;

[TestClass]
public class Day9Tests
{
	[TestMethod]
	[DataRow(127,
		"35\n" +
		"20\n" +
		"15\n" +
		"25\n" +
		"47\n" +
		"40\n" +
		"62\n" +
		"55\n" +
		"65\n" +
		"95\n" +
		"102\n" +
		"117\n" +
		"150\n" +
		"182\n" +
		"127\n" +
		"219\n" +
		"299\n" +
		"277\n" +
		"309\n" +
		"576\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part1(5));
	}

	[TestMethod]
	[DataRow(62,
		"35\n" +
		"20\n" +
		"15\n" +
		"25\n" +
		"47\n" +
		"40\n" +
		"62\n" +
		"55\n" +
		"65\n" +
		"95\n" +
		"102\n" +
		"117\n" +
		"150\n" +
		"182\n" +
		"127\n" +
		"219\n" +
		"299\n" +
		"277\n" +
		"309\n" +
		"576\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part2(5));
	}
}
