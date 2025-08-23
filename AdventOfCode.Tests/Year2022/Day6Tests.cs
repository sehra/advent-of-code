namespace AdventOfCode.Year2022;

[TestClass]
public class Day6Tests
{
	[TestMethod]
	[DataRow(7, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
	[DataRow(5, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
	[DataRow(6, "nppdvjthqldpwncqszvftbrmjlhg")]
	[DataRow(10, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
	[DataRow(11, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part1());
	}

	[TestMethod]
	[DataRow(19, "mjqjpqmgbljsphdztnvjfqwrcgsmlb")]
	[DataRow(23, "bvwbjplbgvbhsrlpgdmjqwftvncz")]
	[DataRow(23, "nppdvjthqldpwncqszvftbrmjlhg")]
	[DataRow(29, "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg")]
	[DataRow(26, "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input).Part2());
	}
}
