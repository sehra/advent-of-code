namespace AdventOfCode.Year2020;

[TestClass]
public class Day5Tests
{
	[DataTestMethod]
	[DataRow(357, "FBFBBFFRLR")]
	[DataRow(567, "BFFFBBFRRR")]
	[DataRow(119, "FFFBBBFRRR")]
	[DataRow(820, "BBFFBBFRLL")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part1());
	}
}
