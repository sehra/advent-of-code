namespace AdventOfCode.Year2020;

[TestClass]
public class Day25Tests
{
	[DataTestMethod]
	[DataRow(14897079, "5764801\n17807724\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input).Part1());
	}

	[DataTestMethod]
	[DataRow("get 49 stars", "")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input).Part2());
	}
}
