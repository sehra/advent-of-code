namespace AdventOfCode.Year2022;

[TestClass]
public class Day23Tests
{
	private const string Input =
		"""
		....#..
		..###.#
		#...#.#
		.#...##
		#.###..
		##.#.##
		.#..#..
		""";

	[TestMethod]
	[DataRow(110, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(20, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part2());
	}
}
