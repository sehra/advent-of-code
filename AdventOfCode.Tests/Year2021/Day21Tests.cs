namespace AdventOfCode.Year2021;

[TestClass]
public class Day21Tests
{
	private const string Input =
		"Player 1 starting position: 4\n" +
		"Player 2 starting position: 8\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(739785, new Day21(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(444356092776315, new Day21(Input.ToLines()).Part2());
	}
}
