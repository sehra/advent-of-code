namespace AdventOfCode.Year2021;

[TestClass]
public class Day5Tests
{
	private const string Input =
		"0,9 -> 5,9\n" +
		"8,0 -> 0,8\n" +
		"9,4 -> 3,4\n" +
		"2,2 -> 2,1\n" +
		"7,0 -> 7,4\n" +
		"6,4 -> 2,0\n" +
		"0,9 -> 2,9\n" +
		"3,4 -> 1,4\n" +
		"0,0 -> 8,8\n" +
		"5,5 -> 8,2\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(5, new Day5(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(12, new Day5(Input.ToLines()).Part2());
	}
}
