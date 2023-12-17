namespace AdventOfCode.Year2015;

[TestClass]
public class Day5Tests
{
	[DataTestMethod]
	[DataRow(1, "ugknbfddgicrmopn")]
	[DataRow(1, "aaa")]
	[DataRow(0, "jchzalrnumimnmhp")]
	[DataRow(0, "haegwjzuvuyypxyu")]
	[DataRow(0, "dvszwmarrgswjxmb")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5([input]).Part1());
	}

	[DataTestMethod]
	[DataRow(1, "qjhvhtzxzqqjkmpb")]
	[DataRow(1, "xxyxx")]
	[DataRow(0, "uurcxstgmygtbstg")]
	[DataRow(0, "ieodomkazucvgmuy")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5([input]).Part2());
	}
}
