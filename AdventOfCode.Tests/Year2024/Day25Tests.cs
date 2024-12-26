namespace AdventOfCode.Year2024;

[TestClass]
public class Day25Tests
{
	[DataTestMethod]
	[DataRow(3,
		"""
		#####
		.####
		.####
		.####
		.#.#.
		.#...
		.....

		#####
		##.##
		.#.##
		...##
		...#.
		...#.
		.....

		.....
		#....
		#....
		#...#
		#.#.#
		#.###
		#####

		.....
		.....
		#.#..
		###..
		###.#
		###.#
		#####

		.....
		.....
		.....
		#....
		#.#..
		#.#.#
		#####
		""")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input.ToLines()).Part1());
	}
}
