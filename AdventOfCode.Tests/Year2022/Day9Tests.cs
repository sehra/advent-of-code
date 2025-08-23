namespace AdventOfCode.Year2022;

[TestClass]
public class Day9Tests
{
	private const string Input1 =
		"""
		R 4
		U 4
		L 3
		D 1
		R 4
		D 1
		L 5
		R 2
		""";

	private const string Input2 =
		"""
		R 5
		U 8
		L 8
		D 3
		R 17
		D 10
		L 25
		U 20
		""";

	[TestMethod]
	[DataRow(13, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(1, Input1)]
	[DataRow(36, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input.ToLines()).Part2());
	}
}
