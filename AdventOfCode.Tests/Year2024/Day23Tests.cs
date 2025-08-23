namespace AdventOfCode.Year2024;

[TestClass]
public class Day23Tests
{
	private const string Input =
		"""
		kh-tc
		qp-kh
		de-cg
		ka-co
		yn-aq
		qp-ub
		cg-tb
		vc-aq
		tb-ka
		wh-tc
		yn-cg
		kh-ub
		ta-co
		de-co
		tc-td
		tb-wq
		wh-td
		ta-ka
		td-qp
		aq-cg
		wq-ub
		ub-vc
		de-ta
		wq-aq
		wq-vc
		wh-yn
		ka-de
		kh-ta
		co-tc
		wh-qp
		tb-vc
		td-yn
		""";

	[TestMethod]
	[DataRow(7, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow("co,de,ka,ta", Input)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part2());
	}
}
