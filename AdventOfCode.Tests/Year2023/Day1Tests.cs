namespace AdventOfCode.Year2023;

[TestClass]
public class Day1Tests
{
	private const string Input1 =
		"""
		1abc2
		pqr3stu8vwx
		a1b2c3d4e5f
		treb7uchet
		""";
	private const string Input2 =
		"""
		two1nine
		eightwothree
		abcone2threexyz
		xtwone3four
		4nineeightseven2
		zoneight234
		7pqrstsixteen
		""";

	[DataTestMethod]
	[DataRow(142, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(281, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day1(input.ToLines()).Part2());
	}
}
