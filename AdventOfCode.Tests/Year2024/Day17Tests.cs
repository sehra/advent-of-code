namespace AdventOfCode.Year2024;

[TestClass]
public class Day17Tests
{
	[TestMethod]
	[DataRow("4,6,3,5,6,3,5,2,1,0",
		"""
		Register A: 729
		Register B: 0
		Register C: 0

		Program: 0,1,5,4,3,0
		""")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(117440,
		"""
		Register A: 2024
		Register B: 0
		Register C: 0

		Program: 0,3,5,4,3,0
		""")]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day17(input.ToLines()).Part2(true));
	}
}
