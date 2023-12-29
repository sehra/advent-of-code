namespace AdventOfCode.Year2015;

[TestClass]
public class Day6Tests
{
	[DataTestMethod]
	[DataRow(1_000_000, "turn on 0,0 through 999,999")]
	[DataRow(1_000, "toggle 0,0 through 999,0")]
	[DataRow(0, "turn off 499,499 through 500,500")]
	[DataRow(4, "turn on 499,499 through 500,500")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6([input]).Part1());
	}

	[DataTestMethod]
	[DataRow(1, "turn on 0,0 through 0,0")]
	[DataRow(2_000_000, "toggle 0,0 through 999,999")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6([input]).Part2());
	}
}
