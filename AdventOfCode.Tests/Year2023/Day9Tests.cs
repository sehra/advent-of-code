namespace AdventOfCode.Year2023;

[TestClass]
public class Day9Tests
{
	private const string Input =
		"""
		0 3 6 9 12 15
		1 3 6 10 15 21
		10 13 16 21 30 45
		""";

	[DataTestMethod]
	[DataRow(114, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(2, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part2());
	}
}
