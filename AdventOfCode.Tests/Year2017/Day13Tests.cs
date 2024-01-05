namespace AdventOfCode.Year2017;

[TestClass]
public class Day13Tests
{
	private const string Input =
		"""
		0: 3
		1: 2
		4: 4
		6: 4
		""";

	[DataTestMethod]
	[DataRow(24, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(10, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input.ToLines()).Part2());
	}
}
