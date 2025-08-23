namespace AdventOfCode.Year2018;

[TestClass]
public class Day22Tests
{
	private const string Input =
		"""
		depth: 510
		target: 10,10
		""";

	[TestMethod]
	[DataRow(114, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(45, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part2());
	}
}
