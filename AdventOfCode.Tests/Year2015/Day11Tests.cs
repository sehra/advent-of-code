namespace AdventOfCode.Year2015;

[TestClass]
public class Day11Tests
{
	[DataTestMethod]
	[DataRow("abcdffaa", "abcdefgh")]
	[DataRow("ghjaabcc", "ghijklmn")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input).Part1());
	}
}
