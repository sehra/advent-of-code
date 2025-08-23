namespace AdventOfCode.Year2015;

[TestClass]
public class Day9Tests
{
	private const string Input =
		"""
		London to Dublin = 464
		London to Belfast = 518
		Dublin to Belfast = 141
		""";

	[TestMethod]
	[DataRow(605, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(982, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part2());
	}
}
