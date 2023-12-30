namespace AdventOfCode.Year2016;

[TestClass]
public class Day18Tests
{
	[DataTestMethod]
	[DataRow(6, "..^^.", 3)]
	[DataRow(38, ".^^.^.^^^^", 10)]
	public void Part1(int expected, string input, int rows)
	{
		Assert.AreEqual(expected, new Day18(input).Part1(rows));
	}

	[DataTestMethod]
	[DataRow(0, "")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input).Part2());
	}
}
