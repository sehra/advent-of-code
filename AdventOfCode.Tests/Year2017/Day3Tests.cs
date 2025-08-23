namespace AdventOfCode.Year2017;

[TestClass]
public class Day3Tests
{
	[TestMethod]
	[DataRow(0, "1")]
	[DataRow(3, "12")]
	[DataRow(2, "23")]
	[DataRow(31, "1024")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part1());
	}
}
