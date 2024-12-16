namespace AdventOfCode.Year2024;

[TestClass]
public class Day16Tests
{
	private const string Input1 =
		"""
		###############
		#.......#....E#
		#.#.###.#.###.#
		#.....#.#...#.#
		#.###.#####.#.#
		#.#.#.......#.#
		#.#.#####.###.#
		#...........#.#
		###.#.#####.#.#
		#...#.....#.#.#
		#.#.#.###.#.#.#
		#.....#...#.#.#
		#.###.#.#.#.#.#
		#S..#.....#...#
		###############
		""";
	private const string Input2 =
		"""
		#################
		#...#...#...#..E#
		#.#.#.#.#.#.#.#.#
		#.#.#.#...#...#.#
		#.#.#.#.###.#.#.#
		#...#.#.#.....#.#
		#.#.#.#.#.#####.#
		#.#...#.#.#.....#
		#.#.#####.#.###.#
		#.#.#.......#...#
		#.#.###.#####.###
		#.#.#...#.....#.#
		#.#.#.#####.###.#
		#.#.#.........#.#
		#.#.#.#########.#
		#S#.............#
		#################
		""";

	[DataTestMethod]
	[DataRow(7036, Input1)]
	[DataRow(11048, Input2)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(45, Input1)]
	[DataRow(64, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input.ToLines()).Part2());
	}
}
