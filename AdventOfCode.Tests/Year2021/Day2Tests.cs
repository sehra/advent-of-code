namespace AdventOfCode.Year2021;

[TestClass]
public class Day2Tests
{
	private const string Input =
		"forward 5\n" +
		"down 5\n" +
		"forward 8\n" +
		"up 3\n" +
		"down 8\n" +
		"forward 2\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(150, new Day2(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(900, new Day2(Input.ToLines()).Part2());
	}
}
