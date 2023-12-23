namespace AdventOfCode.Year2023;

[TestClass]
public class Day23Tests
{
	private const string Input =
		"""
		#.#####################
		#.......#########...###
		#######.#########.#.###
		###.....#.>.>.###.#.###
		###v#####.#v#.###.#.###
		###.>...#.#.#.....#...#
		###v###.#.#.#########.#
		###...#.#.#.......#...#
		#####.#.#.#######.#.###
		#.....#.#.#.......#...#
		#.#####.#.#.#########v#
		#.#...#...#...###...>.#
		#.#.#v#######v###.###v#
		#...#.>.#...>.>.#.###.#
		#####v#.#.###v#.#.###.#
		#.....#...#...#.#.#...#
		#.#########.###.#.#.###
		#...###...#...#...#.###
		###.###.#.###v#####v###
		#...#...#.#.>.>.#.>.###
		#.###.###.#.###.#.#v###
		#.....###...###...#...#
		#####################.#
		""";

	[DataTestMethod]
	[DataRow(94, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(154, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part2());
	}
}
