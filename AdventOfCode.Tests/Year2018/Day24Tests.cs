namespace AdventOfCode.Year2018;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"""
		Immune System:
		17 units each with 5390 hit points (weak to radiation, bludgeoning) with an attack that does 4507 fire damage at initiative 2
		989 units each with 1274 hit points (immune to fire; weak to bludgeoning, slashing) with an attack that does 25 slashing damage at initiative 3

		Infection:
		801 units each with 4706 hit points (weak to radiation) with an attack that does 116 bludgeoning damage at initiative 1
		4485 units each with 2961 hit points (immune to radiation; weak to fire, cold) with an attack that does 12 slashing damage at initiative 4
		""";

	[TestMethod]
	[DataRow(5216, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(51, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input.ToLines()).Part2());
	}
}
