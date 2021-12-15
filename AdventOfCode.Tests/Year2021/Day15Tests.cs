namespace AdventOfCode.Year2021;

[TestClass]
public class Day15Tests
{
	private const string Input =
		"1163751742\n" +
		"1381373672\n" +
		"2136511328\n" +
		"3694931569\n" +
		"7463417111\n" +
		"1319128137\n" +
		"1359912421\n" +
		"3125421639\n" +
		"1293138521\n" +
		"2311944581\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(40, new Day15(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(315, new Day15(Input.ToLines()).Part2());
	}
}
