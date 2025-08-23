namespace AdventOfCode.Year2020;

[TestClass]
public class Day11Tests
{
	[TestMethod]
	[DataRow(37,
		"L.LL.LL.LL\n" +
		"LLLLLLL.LL\n" +
		"L.L.L..L..\n" +
		"LLLL.LL.LL\n" +
		"L.LL.LL.LL\n" +
		"L.LLLLL.LL\n" +
		"..L.L.....\n" +
		"LLLLLLLLLL\n" +
		"L.LLLLLL.L\n" +
		"L.LLLLL.LL\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part1());
	}

	[TestMethod]
	[DataRow(26,
		"L.LL.LL.LL\n" +
		"LLLLLLL.LL\n" +
		"L.L.L..L..\n" +
		"LLLL.LL.LL\n" +
		"L.LL.LL.LL\n" +
		"L.LLLLL.LL\n" +
		"..L.L.....\n" +
		"LLLLLLLLLL\n" +
		"L.LLLLLL.L\n" +
		"L.LLLLL.LL\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part2());
	}
}
