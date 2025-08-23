namespace AdventOfCode.Year2022;

[TestClass]
public class Day4Tests
{
	private const string Input =
		"""
		2-4,6-8
		2-3,4-5
		5-7,7-9
		2-8,3-7
		6-6,4-6
		2-6,4-8
		""";

	[TestMethod]
	[DataRow(2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(4, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4(input.ToLines()).Part2());
	}
}
