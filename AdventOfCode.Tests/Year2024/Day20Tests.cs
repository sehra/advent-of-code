namespace AdventOfCode.Year2024;

[TestClass]
public class Day20Tests
{
	private const string Input =
		"""
		###############
		#...#...#.....#
		#.#.#.#.#.###.#
		#S#...#.#.#...#
		#######.#.#.###
		#######.#.#...#
		#######.#.###.#
		###..E#...#...#
		###.#######.###
		#...###...#...#
		#.#####.#.###.#
		#.#...#.#.#...#
		#.#.#.#.#.#.###
		#...#...#...###
		###############
		""";

	[DataTestMethod]
	[DataRow(14 + 14 + 2 + 4 + 2 + 3 + 1 + 1 + 1 + 1 + 1, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part1(1));
	}

	[DataTestMethod]
	[DataRow(32 + 31 + 29 + 39 + 25 + 23 + 20 + 19 + 12 + 14 + 12 + 22 + 4 + 3, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part2(50));
	}
}
