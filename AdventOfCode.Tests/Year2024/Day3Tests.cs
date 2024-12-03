namespace AdventOfCode.Year2024;

[TestClass]
public class Day3Tests
{
	[DataTestMethod]
	[DataRow(161, "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part1());
	}

	[DataTestMethod]
	[DataRow(48, "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day3(input).Part2());
	}
}
