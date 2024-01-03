namespace AdventOfCode.Year2017;

[TestClass]
public class Day2Tests
{
	private const string Input1 =
		"""
		5 1 9 5
		7 5 3
		2 4 6 8
		""";
	private const string Input2 =
		"""
		5 9 2 8
		9 4 7 3
		3 8 6 5
		""";

	[DataTestMethod]
	[DataRow(18, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(9, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
