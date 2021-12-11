namespace AdventOfCode.Year2021;

[TestClass]
public class Day11Tests
{
	private const string Input =
		"5483143223\n" +
		"2745854711\n" +
		"5264556173\n" +
		"6141336146\n" +
		"6357385478\n" +
		"4167524645\n" +
		"2176841721\n" +
		"6882881134\n" +
		"4846848554\n" +
		"5283751526\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(1656, new Day11(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(195, new Day11(Input.ToLines()).Part2());
	}
}
