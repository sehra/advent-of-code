namespace AdventOfCode.Year2018;

[TestClass]
public class Day6Tests
{
	private const string Input =
		"""
		1, 1
		1, 6
		8, 3
		3, 4
		5, 5
		8, 9
		""";

	[TestMethod]
	[DataRow(17, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(16, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part2(32));
	}
}
