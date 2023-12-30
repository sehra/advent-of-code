namespace AdventOfCode.Year2016;

[TestClass]
public class Day9Tests
{
	[DataTestMethod]
	[DataRow(6, "ADVENT")]
	[DataRow(7, "A(1x5)BC")]
	[DataRow(9, "(3x3)XYZ")]
	[DataRow(11, "A(2x2)BCD(2x2)EFG")]
	[DataRow(6, "(6x1)(1x3)A")]
	[DataRow(18, "X(8x2)(3x3)ABCY")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part1());
	}

	[DataTestMethod]
	[DataRow(9, "(3x3)XYZ")]
	[DataRow(20, "X(8x2)(3x3)ABCY")]
	[DataRow(241920, "(27x12)(20x12)(13x14)(7x10)(1x12)A")]
	[DataRow(445, "(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day9(input).Part2());
	}
}
