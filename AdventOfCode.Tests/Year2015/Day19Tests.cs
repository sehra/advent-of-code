namespace AdventOfCode.Year2015;

[TestClass]
public class Day19Tests
{
	private const string Input1 =
		"""
		H => HO
		H => OH
		O => HH

		HOH
		""";
	private const string Input2 =
		"""
		H => HO
		H => OH
		O => HH

		HOHOHO
		""";

	[DataTestMethod]
	[DataRow(4, Input1)]
	[DataRow(7, Input2)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(3, Input1)]
	//[DataRow(6, Input2)]
	public void Part2(int expected, string input)
	{
		var e1 = "e => H";
		var e2 = "e => O";

		Assert.AreEqual(expected, new Day19([e1, e2, .. input.ToLines()]).Part2());
	}
}
