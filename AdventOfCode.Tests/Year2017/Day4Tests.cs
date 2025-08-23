namespace AdventOfCode.Year2017;

[TestClass]
public class Day4Tests
{
	[TestMethod]
	[DataRow(1, "aa bb cc dd ee")]
	[DataRow(0, "aa bb cc dd aa")]
	[DataRow(1, "aa bb cc dd aaa")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4([input]).Part1());
	}

	[TestMethod]
	[DataRow(1, "abcde fghij")]
	[DataRow(0, "abcde xyz ecdab")]
	[DataRow(1, "a ab abc abd abf abj")]
	[DataRow(1, "iiii oiii ooii oooi oooo")]
	[DataRow(0, "oiii ioii iioi iiio")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4([input]).Part2());
	}
}
