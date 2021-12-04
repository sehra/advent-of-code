namespace AdventOfCode.Year2021;

[TestClass]
public class Day3Tests
{
	private const string Input =
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
		"01010\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(198, new Day3(Input).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(230, new Day3(Input).Part2());
	}
}
