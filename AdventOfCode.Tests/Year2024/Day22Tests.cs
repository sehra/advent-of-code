namespace AdventOfCode.Year2024;

[TestClass]
public class Day22Tests
{
	[TestMethod]
	[DataRow(37327623,
		"""
		1
		10
		100
		2024
		""")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines().ToInt32()).Part1());
	}

	[TestMethod]
	[DataRow(23,
		"""
		1
		2
		3
		2024
		""")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines().ToInt32()).Part2());
	}
}
