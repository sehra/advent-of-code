namespace AdventOfCode.Year2015;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"""
		.#.#.#
		...##.
		#....#
		..#...
		#.#..#
		####..
		""";

	[DataTestMethod]
	[DataRow(4, Input, 4)]
	public void Part1(int expected, string input, int steps)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part1(steps));
	}

	[DataTestMethod]
	[DataRow(17, Input, 5)]
	public void Part2(int expected, string input, int steps)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part2(steps));
	}
}
