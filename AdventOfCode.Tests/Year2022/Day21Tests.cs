namespace AdventOfCode.Year2022;

[TestClass]
public class Day21Tests
{
	private const string Input =
		"""
		root: pppw + sjmn
		dbpl: 5
		cczh: sllz + lgvd
		zczc: 2
		ptdq: humn - dvpt
		dvpt: 3
		lfqf: 4
		humn: 5
		ljgn: 2
		sjmn: drzm * dbpl
		sllz: 4
		pppw: cczh / lfqf
		lgvd: ljgn * ptdq
		drzm: hmdt - zczc
		hmdt: 32
		""";

	[TestMethod]
	[DataRow(152, Input)]
	public void Part1(long expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(301, Input)]
	public void Part2(long expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part2());
	}
}
