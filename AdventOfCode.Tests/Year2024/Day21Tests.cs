namespace AdventOfCode.Year2024;

[TestClass]
public class Day21Tests
{
	private const string Input =
		"""
		029A
		980A
		179A
		456A
		379A
		""";

	[DataTestMethod]
	[DataRow(126384, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(154115708116294, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part2());
	}
}
