namespace AdventOfCode.Year2022;

[TestClass]
public class Day14Tests
{
	private const string Input =
		"""
		498,4 -> 498,6 -> 496,6
		503,4 -> 502,4 -> 502,9 -> 494,9
		""";

	[DataTestMethod]
	[DataRow(24, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(93, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part2());
	}
}
