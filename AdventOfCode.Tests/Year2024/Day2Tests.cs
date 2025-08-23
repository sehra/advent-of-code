namespace AdventOfCode.Year2024;

[TestClass]
public class Day2Tests
{
	private const string Input =
		"""
		7 6 4 2 1
		1 2 7 8 9
		9 7 6 2 1
		1 3 2 4 5
		8 6 4 4 1
		1 3 6 7 9
		""";

	[TestMethod]
	[DataRow(2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(4, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
