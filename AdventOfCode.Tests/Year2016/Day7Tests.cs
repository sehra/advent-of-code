namespace AdventOfCode.Year2016;

[TestClass]
public class Day7Tests
{
	[TestMethod]
	[DataRow(1, "abba[mnop]qrst")]
	[DataRow(0, "abcd[bddb]xyyx")]
	[DataRow(0, "aaaa[qwer]tyui")]
	[DataRow(1, "ioxxoj[asdfgh]zxcvbn")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7([input]).Part1());
	}

	[TestMethod]
	[DataRow(1, "aba[bab]xyz")]
	[DataRow(0, "xyx[xyx]xyx")]
	[DataRow(1, "aaa[kek]eke")]
	[DataRow(1, "zazbz[bzb]cdb")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7([input]).Part2());
	}
}
