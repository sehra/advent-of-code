namespace AdventOfCode.Year2023;

[TestClass]
public class Day14Tests
{
	private const string Input =
		"""
		O....#....
		O.OO#....#
		.....##...
		OO.#O....O
		.O.....O#.
		O.#..O.#.#
		..O..#O..O
		.......O..
		#....###..
		#OO..#....
		""";

	[TestMethod]
	[DataRow(136, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(64, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part2());
	}
}
