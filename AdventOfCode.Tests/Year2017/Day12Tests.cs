namespace AdventOfCode.Year2017;

[TestClass]
public class Day12Tests
{
	private const string Input =
		"""
		0 <-> 2
		1 <-> 1
		2 <-> 0, 3, 4
		3 <-> 2, 4
		4 <-> 2, 3, 6
		5 <-> 6
		6 <-> 4, 5
		""";

	[DataTestMethod]
	[DataRow(6, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(2, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part2());
	}
}
