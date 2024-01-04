namespace AdventOfCode.Year2017;

[TestClass]
public class Day17Tests
{
	[DataTestMethod]
	[DataRow(638, "3")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input).Part1());
	}
}
