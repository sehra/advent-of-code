namespace AdventOfCode.Year2022;

[TestClass]
public class Day8Tests
{
	private const string Input =
		"""
		30373
		25512
		65332
		33549
		35390
		""";

	[TestMethod]
	[DataRow(21, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(8, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part2());
	}
}
