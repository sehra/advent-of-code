namespace AdventOfCode.Year2017;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		0/2
		2/2
		2/3
		3/4
		3/5
		0/1
		10/1
		9/10
		""";

	[DataTestMethod]
	[DataRow(31, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(19, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part2());
	}
}
