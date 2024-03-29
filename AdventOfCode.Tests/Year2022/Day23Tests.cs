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

	[DataTestMethod]
	[DataRow(110, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(20, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part2());
	}
}
