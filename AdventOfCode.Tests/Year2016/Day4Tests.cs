namespace AdventOfCode.Year2016;

[TestClass]
public class Day4Tests
{
	[TestMethod]
	[DataRow(123, "aaaaa-bbb-z-y-x-123[abxyz]")]
	[DataRow(987, "a-b-c-d-e-f-g-h-987[abcde]")]
	[DataRow(404, "not-a-real-room-404[oarel]")]
	[DataRow(0, "totally-real-room-200[decoy]")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day4([input]).Part1());
	}
}
