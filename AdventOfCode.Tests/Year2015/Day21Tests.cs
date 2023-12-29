namespace AdventOfCode.Year2015;

[TestClass]
public class Day21Tests
{
	[TestMethod]
	public void PlayerWins()
	{
		var p = new Day21.Player(8, 5, 5);
		var b = new Day21.Player(12, 7, 2);

		Assert.IsTrue(Day21.PlayerWins(p, b));
	}
}
