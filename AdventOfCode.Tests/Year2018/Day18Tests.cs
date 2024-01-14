namespace AdventOfCode.Year2018;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"""
		.#.#...|#.
		.....#|##|
		.|..|...#.
		..|#.....#
		#.#|||#|#|
		...#.||...
		.|....|...
		||...#|.#|
		|.||||..|.
		...#.|..|.
		""";

	[DataTestMethod]
	[DataRow(1147, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part1());
	}
}
