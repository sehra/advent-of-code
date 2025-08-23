namespace AdventOfCode.Year2017;

[TestClass]
public class Day5Tests
{
	private const string Input =
		"""
		0
		3
		0
		1
		-3
		""";

	[TestMethod]
	[DataRow(5, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(10, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part2());
	}
}
