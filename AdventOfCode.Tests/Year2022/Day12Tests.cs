namespace AdventOfCode.Year2022;

[TestClass]
public class Day12Tests
{
	private const string Input =
		"""
		Sabqponm
		abcryxxl
		accszExk
		acctuvwj
		abdefghi
		""";

	[DataTestMethod]
	[DataRow(31, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(29, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part2());
	}
}
