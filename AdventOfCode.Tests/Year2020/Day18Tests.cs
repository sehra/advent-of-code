namespace AdventOfCode.Year2020;

[TestClass]
public class Day18Tests
{
	[DataTestMethod]
	[DataRow(71, "1 + 2 * 3 + 4 * 5 + 6")]
	[DataRow(51, "1 + (2 * 3) + (4 * (5 + 6))")]
	[DataRow(26, "2 * 3 + (4 * 5)")]
	[DataRow(437, "5 + (8 * 3 + 9 + 3 * 4 * 3)")]
	[DataRow(12240, "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")]
	[DataRow(13632, "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")]
	[DataRow(3, "1\n2\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input).Part1());
	}

	[DataTestMethod]
	[DataRow(231, "1 + 2 * 3 + 4 * 5 + 6")]
	[DataRow(51, "1 + (2 * 3) + (4 * (5 + 6))")]
	[DataRow(46, "2 * 3 + (4 * 5)")]
	[DataRow(1445, "5 + (8 * 3 + 9 + 3 * 4 * 3)")]
	[DataRow(669060, "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))")]
	[DataRow(23340, "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2")]
	[DataRow(3, "1\n2\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input).Part2());
	}
}
