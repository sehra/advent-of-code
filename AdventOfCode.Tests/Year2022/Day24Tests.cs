namespace AdventOfCode.Year2022;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		#.######
		#>>.<^<#
		#.<..<<#
		#>v.><>#
		#<^v^^>#
		######.#
		""";

	[TestMethod]
	[DataRow(18, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(54, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part2());
	}
}
