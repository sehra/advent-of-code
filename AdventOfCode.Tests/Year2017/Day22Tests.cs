namespace AdventOfCode.Year2017;

[TestClass]
public class Day22Tests
{
	private const string Input =
		"""
		..#
		#..
		...
		""";

	[DataTestMethod]
	[DataRow(5587, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(2511944, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part2());
	}
}
