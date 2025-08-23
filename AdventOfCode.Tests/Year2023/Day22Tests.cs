namespace AdventOfCode.Year2023;

[TestClass]
public class Day22Tests
{
	private const string Input =
		"""
		1,0,1~1,2,1
		0,0,2~2,0,2
		0,2,3~2,2,3
		0,0,4~0,2,4
		2,0,5~2,2,5
		0,1,6~2,1,6
		1,1,8~1,1,9
		""";

	[TestMethod]
	[DataRow(5, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(7, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day22(input.ToLines()).Part2());
	}
}
