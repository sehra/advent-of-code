namespace AdventOfCode.Year2021;

[TestClass]
public class Day14Tests
{
	private const string Input =
		"NNCB\n" +
		"\n" +
		"CH -> B\n" +
		"HH -> N\n" +
		"CB -> H\n" +
		"NH -> C\n" +
		"HB -> C\n" +
		"HC -> B\n" +
		"HN -> C\n" +
		"NN -> C\n" +
		"BH -> H\n" +
		"NC -> B\n" +
		"NB -> B\n" +
		"BN -> B\n" +
		"BB -> N\n" +
		"BC -> B\n" +
		"CC -> N\n" +
		"CN -> C\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(1588, new Day14(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(2188189693529, new Day14(Input.ToLines()).Part2());
	}
}
