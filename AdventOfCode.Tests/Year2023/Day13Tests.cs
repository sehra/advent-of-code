namespace AdventOfCode.Year2023;

[TestClass]
public class Day13Tests
{
	private const string Input =
		"""
		#.##..##.
		..#.##.#.
		##......#
		##......#
		..#.##.#.
		..##..##.
		#.#.##.#.

		#...##..#
		#....#..#
		..##..###
		#####.##.
		#####.##.
		..##..###
		#....#..#
		""";

	[DataTestMethod]
	[DataRow(405, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input).Part1());
	}

	[DataTestMethod]
	[DataRow(400, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input).Part2());
	}
}
