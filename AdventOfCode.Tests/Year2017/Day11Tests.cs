namespace AdventOfCode.Year2017;

[TestClass]
public class Day11Tests
{
	[DataTestMethod]
	[DataRow(3, "ne,ne,ne")]
	[DataRow(0, "ne,ne,sw,sw")]
	[DataRow(2, "ne,ne,s,s")]
	[DataRow(3, "se,sw,se,sw,sw")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part1());
	}
}
