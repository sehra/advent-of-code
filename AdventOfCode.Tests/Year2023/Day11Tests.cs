namespace AdventOfCode.Year2023;

[TestClass]
public class Day11Tests
{
	private const string Input =
		"""
		...#......
		.......#..
		#.........
		..........
		......#...
		.#........
		.........#
		..........
		.......#..
		#...#.....
		""";

	[DataTestMethod]
	[DataRow(374, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(1030, Input, 10)]
	[DataRow(8410, Input, 100)]
	public void Part2(long expected, string input, int expansion)
	{
		Assert.AreEqual(expected, new Day11(input.ToLines()).Part2(expansion));
	}
}
