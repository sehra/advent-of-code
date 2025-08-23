namespace AdventOfCode.Year2024;

[TestClass]
public class Day10Tests
{
	private const string Input =
		"""
		89010123
		78121874
		87430965
		96549874
		45678903
		32019012
		01329801
		10456732
		""";

	[TestMethod]
	[DataRow(36, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(81, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part2());
	}
}
