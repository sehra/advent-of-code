namespace AdventOfCode.Year2018;

[TestClass]
public class Day17Tests
{
	private const string Input =
		"""
		x=495, y=2..7
		y=7, x=495..501
		x=501, y=3..7
		x=498, y=2..4
		x=506, y=1..2
		x=498, y=10..13
		x=504, y=10..13
		y=13, x=498..504
		""";

	[DataTestMethod]
	[DataRow(57, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(29, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part2());
	}
}
