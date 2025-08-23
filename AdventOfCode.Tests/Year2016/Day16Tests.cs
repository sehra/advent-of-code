namespace AdventOfCode.Year2016;

[TestClass]
public class Day16Tests
{
	[TestMethod]
	[DataRow("100", "110010110100", 12)]
	[DataRow("01100", "10000", 20)]
	public void Part1(string expected, string input, int length)
	{
		Assert.AreEqual(expected, new Day16(input).Part1(length));
	}
}
