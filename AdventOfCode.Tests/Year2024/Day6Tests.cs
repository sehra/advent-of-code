namespace AdventOfCode.Year2024;

[TestClass]
public class Day6Tests
{
	private const string Input =
		"""
		....#.....
		.........#
		..........
		..#.......
		.......#..
		..........
		.#..^.....
		........#.
		#.........
		......#...
		""";

	[DataTestMethod]
	[DataRow(41, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(6, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part2());
	}
}
