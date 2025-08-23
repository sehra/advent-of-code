namespace AdventOfCode.Year2018;

[TestClass]
public class Day16Tests
{
	private const string Input =
		"""
		Before: [3, 2, 1, 1]
		9 2 1 2
		After:  [3, 2, 2, 1]
		""";

	[TestMethod]
	[DataRow(1, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day16(input.ToLines()).Part1());
	}
}
