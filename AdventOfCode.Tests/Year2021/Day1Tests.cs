namespace AdventOfCode.Year2021;

[TestClass]
public class Day1Tests
{
	private const string Input =
		"199\n" +
		"200\n" +
		"208\n" +
		"210\n" +
		"200\n" +
		"207\n" +
		"240\n" +
		"269\n" +
		"260\n" +
		"263\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(7, new Day1(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(5, new Day1(Input.ToLines()).Part2());
	}
}
