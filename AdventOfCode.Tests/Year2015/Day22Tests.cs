namespace AdventOfCode.Year2015;

[TestClass]
public class Day22Tests
{
	[TestMethod]
	[DataRow(173 + 53, 13, 8)]
	[DataRow(229 + 113 + 73 + 173 + 53, 14, 8)]
	public void Part1(int expected, int bossHealth, int bossDamage)
	{
		var input = new[]
		{
			$"Hit Points: {bossHealth}",
			$"Damage: {bossDamage}",
		};

		Assert.AreEqual(expected, new Day22(input).Part1(10, 250));
	}
}
