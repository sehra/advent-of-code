namespace AdventOfCode.Year2015;

[TestClass]
public class Day1Tests
{
	[DataTestMethod]
	[DataRow(0, "(())")]
	[DataRow(0, "()()")]
	[DataRow(3, "(((")]
	[DataRow(3, "(()(()(")]
	[DataRow(3, "))(((((")]
	[DataRow(-1, "())")]
	[DataRow(-1, "))(")]
	[DataRow(-3, ")))")]
	[DataRow(-3, ")())())")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[DataTestMethod]
	[DataRow(1, ")")]
	[DataRow(5, "()())")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
