namespace AdventOfCode.Year2015;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		1
		2
		3
		4
		5
		7
		8
		9
		10
		11
		""";

	[DataTestMethod]
	[DataRow(99, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines().ToInt64()).Part1());
	}

	[DataTestMethod]
	[DataRow(44, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines().ToInt64()).Part2());
	}
}
