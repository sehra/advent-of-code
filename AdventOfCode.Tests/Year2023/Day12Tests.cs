namespace AdventOfCode.Year2023;

[TestClass]
public class Day12Tests
{
	[DataTestMethod]
	[DataRow(1, "???.### 1,1,3")]
	[DataRow(4, ".??..??...?##. 1,1,3")]
	[DataRow(1, "?#?#?#?#?#?#?#? 1,3,1,6")]
	[DataRow(1, "????.#...#... 4,1,1")]
	[DataRow(4, "????.######..#####. 1,6,5")]
	[DataRow(10, "?###???????? 3,2,1")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12([input]).Part1());
	}

	[DataTestMethod]
	[DataRow(1, "???.### 1,1,3")]
	[DataRow(16384, ".??..??...?##. 1,1,3")]
	[DataRow(1, "?#?#?#?#?#?#?#? 1,3,1,6")]
	[DataRow(16, "????.#...#... 4,1,1")]
	[DataRow(2500, "????.######..#####. 1,6,5")]
	[DataRow(506250, "?###???????? 3,2,1")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12([input]).Part2());
	}
}
