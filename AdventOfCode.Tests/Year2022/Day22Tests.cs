namespace AdventOfCode.Year2022;

[TestClass]
public class Day22Tests
{
	private const string Input =
		"""
		        ...#
		        .#..
		        #...
		        ....
		...#.......#
		........#...
		..#....#....
		..........#.
		        ...#....
		        .....#..
		        .#......
		        ......#.

		10R5L5R10L4R5L5
		""";

	[TestMethod]
	[DataRow(6032, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input).Part1());
	}

	[TestMethod]
	[DataRow(5031, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input).Part2());
	}
}
