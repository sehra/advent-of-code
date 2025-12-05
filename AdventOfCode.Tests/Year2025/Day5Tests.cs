namespace AdventOfCode.Year2025;

[TestClass]
public class Day5Tests
{
	private const string Input =
		"""
		3-5
		10-14
		16-20
		12-18

		1
		5
		8
		11
		17
		32
		""";

	[TestMethod]
	[DataRow(3, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(14, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input.ToLines()).Part2());
	}
}
