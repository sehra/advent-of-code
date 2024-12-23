namespace AdventOfCode.Year2024;

[TestClass]
public class Day8Tests
{
	private const string Input =
		"""
		............
		........0...
		.....0......
		.......0....
		....0.......
		......A.....
		............
		............
		........A...
		.........A..
		............
		............
		""";

	[DataTestMethod]
	[DataRow(14, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(34, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part2());
	}
}
