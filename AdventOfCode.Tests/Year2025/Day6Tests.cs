namespace AdventOfCode.Year2025;

[TestClass]
public class Day6Tests
{
	private const string Input =
		"""
		123 328  51 64 
		 45 64  387 23 
		  6 98  215 314
		*   +   *   +  
		""";

	[TestMethod]
	[DataRow(4277556, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part1());
	}

	[TestMethod]
	[DataRow(3263827, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part2());
	}
}
