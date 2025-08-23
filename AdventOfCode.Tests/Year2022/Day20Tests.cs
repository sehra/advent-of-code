namespace AdventOfCode.Year2022;

[TestClass]
public class Day20Tests
{
	private const string Input =
		"""
		1
		2
		-3
		3
		-2
		0
		4
		""";

	[TestMethod]
	[DataRow(3, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(1623178306, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part2());
	}
}
