namespace AdventOfCode.Year2021;

[TestClass]
public class Day1Tests
{
	[DataTestMethod]
	[DataRow(7,
		"199\n" +
		"200\n" +
		"208\n" +
		"210\n" +
		"200\n" +
		"207\n" +
		"240\n" +
		"269\n" +
		"260\n" +
		"263\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part1());
	}

	[DataTestMethod]
	[DataRow(5,
		"199\n" +
		"200\n" +
		"208\n" +
		"210\n" +
		"200\n" +
		"207\n" +
		"240\n" +
		"269\n" +
		"260\n" +
		"263\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input).Part2());
	}
}
