namespace AdventOfCode.Year2017;

[TestClass]
public class Day15Tests
{
	private const string Input =
		"""
		Generator A starts with 65
		Generator B starts with 8921
		""";

	[DataTestMethod]
	[DataRow(588, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(309, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day15(input.ToLines()).Part2());
	}
}
