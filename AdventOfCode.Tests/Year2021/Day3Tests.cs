namespace AdventOfCode.Year2021;

[TestClass]
public class Day3Tests
{
	[DataTestMethod]
	[DataRow(198,
		"00100\n" +
		"11110\n" +
		"10110\n" +
		"10111\n" +
		"10101\n" +
		"01111\n" +
		"00111\n" +
		"11100\n" +
		"10000\n" +
		"11001\n" +
		"00010\n" +
		"01010\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part1());
	}

	[DataTestMethod]
	[DataRow(230,
		"00100\n" +
		"11110\n" +
		"10110\n" +
		"10111\n" +
		"10101\n" +
		"01111\n" +
		"00111\n" +
		"11100\n" +
		"10000\n" +
		"11001\n" +
		"00010\n" +
		"01010\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part2());
	}
}
