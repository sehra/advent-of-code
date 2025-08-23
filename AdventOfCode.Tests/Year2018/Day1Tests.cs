namespace AdventOfCode.Year2018;

[TestClass]
public class Day1Tests
{
	[TestMethod]
	[DataRow(3, "+1, -2, +3, +1")]
	[DataRow(3, "+1, +1, +1")]
	[DataRow(0, "+1, +1, -2")]
	[DataRow(-6, "-1, -2, -3")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.Split(',')).Part1());
	}

	[TestMethod]
	[DataRow(2, "+1, -2, +3, +1")]
	[DataRow(0, "+1, -1")]
	[DataRow(10, "+3, +3, +4, -2, -4")]
	[DataRow(5, "-6, +3, +8, +5, -6")]
	[DataRow(14, "+7, +7, -2, -7, -4")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.Split(',')).Part2());
	}
}
