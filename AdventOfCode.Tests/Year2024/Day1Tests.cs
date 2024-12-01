namespace AdventOfCode.Year2024;

[TestClass]
public class Day1Tests
{
	private const string Input =
		"""
		3   4
		4   3
		2   5
		1   3
		3   9
		3   3
		""";

	[DataTestMethod]
	[DataRow(11, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(31, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part2());
	}
}
