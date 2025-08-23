namespace AdventOfCode.Year2015;

[TestClass]
public class Day10Tests
{
	[TestMethod]
	[DataRow(2, "1")]
	[DataRow(2, "11")]
	[DataRow(4, "21")]
	[DataRow(6, "1211")]
	[DataRow(6, "111221")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input).Part1(1));
	}
}
