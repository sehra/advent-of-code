namespace AdventOfCode.Year2020;

[TestClass]
public class Day2Tests
{
	[DataTestMethod]
	[DataRow(2, "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part1());
	}

	[DataTestMethod]
	[DataRow(1, "1-3 a: abcde\n1-3 b: cdefg\n2-9 c: ccccccccc")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part2());
	}
}
