namespace AdventOfCode.Year2016;

[Ignore("LongRunning")]
[TestClass]
public class Day5Tests
{
	[DataTestMethod]
	[DataRow("18f47a30", "abc")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part1());
	}

	[DataTestMethod]
	[DataRow("05ace8e3", "abc")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part2());
	}
}
