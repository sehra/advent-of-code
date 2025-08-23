namespace AdventOfCode.Year2016;

[TestClass]
public class Day10Tests
{
	public const string Input =
		"""
		value 5 goes to bot 2
		bot 2 gives low to bot 1 and high to bot 0
		value 3 goes to bot 1
		bot 1 gives low to output 1 and high to bot 0
		bot 0 gives low to output 2 and high to output 0
		value 2 goes to bot 2
		""";

	[TestMethod]
	[DataRow(2, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input.ToLines()).Part1(2, 5));
	}
}
