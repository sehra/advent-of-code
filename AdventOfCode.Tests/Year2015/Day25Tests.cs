namespace AdventOfCode.Year2015;

[TestClass]
public class Day25Tests
{
	[DataTestMethod]
	[DataRow(20151125, "row 1 col 1")]
	[DataRow(18749137, "row 1 col 2")]
	[DataRow(31916031, "row 2 col 1")]
	[DataRow(21629792, "row 2 col 2")]
	[DataRow(27995004, "row 6 col 6")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input).Part1());
	}
}
