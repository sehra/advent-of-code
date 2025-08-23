namespace AdventOfCode.Year2017;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		pbga (66)
		xhth (57)
		ebii (61)
		havc (66)
		ktlj (57)
		fwft (72) -> ktlj, cntj, xhth
		qoyq (66)
		padx (45) -> pbga, havc, qoyq
		tknk (41) -> ugml, padx, fwft
		jptl (61)
		ugml (68) -> gyxo, ebii, jptl
		gyxo (61)
		cntj (57)
		""";

	[TestMethod]
	[DataRow("tknk", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(60, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2());
	}
}
