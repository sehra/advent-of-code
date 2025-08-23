namespace AdventOfCode.Year2024;

[TestClass]
public class Day19Tests
{
	private const string Input =
		"""
		r, wr, b, g, bwu, rb, gb, br

		brwrr
		bggr
		gbbr
		rrbgbr
		ubwu
		bwurrg
		brgr
		bbrgwb
		""";

	[TestMethod]
	[DataRow(6, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(16, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part2());
	}
}
