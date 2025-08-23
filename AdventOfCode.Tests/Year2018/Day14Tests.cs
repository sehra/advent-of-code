namespace AdventOfCode.Year2018;

[TestClass]
public class Day14Tests
{
	[TestMethod]
	[DataRow("5158916779", "9")]
	[DataRow("0124515891", "5")]
	[DataRow("9251071085", "18")]
	[DataRow("5941429882", "2018")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part1());
	}

	[TestMethod]
	[DataRow(9, "51589")]
	[DataRow(5, "01245")]
	[DataRow(18, "92510")]
	[DataRow(2018, "59414")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input).Part2());
	}
}
