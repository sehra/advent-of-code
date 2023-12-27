namespace AdventOfCode.Year2015;

[TestClass]
public class Day17Tests
{
	private const string Input =
		"""
		20
		15
		10
		5
		5
		""";

	[DataTestMethod]
	[DataRow(4, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part1(25));
	}

	[DataTestMethod]
	[DataRow(3, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part2(25));
	}
}
