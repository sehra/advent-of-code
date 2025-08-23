namespace AdventOfCode.Year2024;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"""
		5,4
		4,2
		4,5
		3,0
		2,1
		6,3
		2,4
		1,5
		0,6
		3,3
		2,6
		5,1
		1,2
		5,5
		2,5
		6,5
		1,4
		0,4
		6,4
		1,1
		6,1
		1,0
		0,5
		1,6
		2,0
		""";

	[TestMethod]
	[DataRow(22, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part1(6, 12));
	}

	[TestMethod]
	[DataRow("6,1", Input)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day18(input.ToLines()).Part2(6));
	}
}
