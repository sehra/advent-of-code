namespace AdventOfCode.Year2021;

[TestClass]
public class Day9Tests
{
	private readonly string Input =
		"2199943210\n" +
		"3987894921\n" +
		"9856789892\n" +
		"8767896789\n" +
		"9899965678\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(15, new Day9(Input).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(1134, new Day9(Input).Part2());
	}
}
