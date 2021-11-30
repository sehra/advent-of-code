namespace AdventOfCode.Year2020;

[TestClass]
public class Day21Tests
{
	[DataTestMethod]
	[DataRow(5,
		"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)\n" +
		"trh fvjkl sbzzf mxmxvkd (contains dairy)\n" +
		"sqjhc fvjkl (contains soy)\n" +
		"sqjhc mxmxvkd sbzzf (contains fish)\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input).Part1());
	}

	[DataTestMethod]
	[DataRow("mxmxvkd,sqjhc,fvjkl",
		"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)\n" +
		"trh fvjkl sbzzf mxmxvkd (contains dairy)\n" +
		"sqjhc fvjkl (contains soy)\n" +
		"sqjhc mxmxvkd sbzzf (contains fish)\n")]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input).Part2());
	}
}
