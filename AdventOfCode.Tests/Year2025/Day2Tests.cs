namespace AdventOfCode.Year2025;

[TestClass]
public class Day2Tests
{
	private const string Input =
		"11-22," +
		"95-115," +
		"998-1012," +
		"1188511880-1188511890," +
		"222220-222224," +
		"1698522-1698528," +
		"446443-446449," +
		"38593856-38593862," +
		"565653-565659," +
		"824824821-824824827," +
		"2121212118-2121212124";

	[TestMethod]
	[DataRow(1227775554, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part1());
	}

	[TestMethod]
	[DataRow(4174379265, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input).Part2());
	}
}
