namespace AdventOfCode.Year2021;

[TestClass]
public class Day2Tests
{
	[DataTestMethod]
	[DataRow(150,
		"forward 5\n" +
		"down 5\n" +
		"forward 8\n" +
		"up 3\n" +
		"down 8\n" +
		"forward 2\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part1());
	}

	[DataTestMethod]
	[DataRow(900,
		"forward 5\n" +
		"down 5\n" +
		"forward 8\n" +
		"up 3\n" +
		"down 8\n" +
		"forward 2\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part2());
	}
}
