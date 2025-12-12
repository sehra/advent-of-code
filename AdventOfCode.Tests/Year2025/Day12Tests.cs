namespace AdventOfCode.Year2025;

[TestClass]
public class Day12Tests
{
	private const string Input =
		"""
		0:
		###
		##.
		##.

		1:
		###
		##.
		.##

		2:
		.##
		###
		##.

		3:
		##.
		###
		##.

		4:
		###
		#..
		###

		5:
		###
		.#.
		###

		4x4: 0 0 0 0 2 0
		12x5: 1 0 1 0 2 2
		12x5: 1 0 1 0 3 2
		""";

	[TestMethod]
	[DataRow(2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}
}
