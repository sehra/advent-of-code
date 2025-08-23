namespace AdventOfCode.Year2017;

[TestClass]
public class Day8Tests
{
	private const string Input =
		"""
		b inc 5 if a > 1
		a inc 1 if b < 5
		c dec -10 if a >= 1
		c inc -20 if c == 10
		""";

	[TestMethod]
	[DataRow(1, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(10, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day8(input.ToLines()).Part2());
	}
}
