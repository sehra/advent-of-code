namespace AdventOfCode.Year2021;

[TestClass]
public class Day12Tests
{
	private const string Input1 =
		"start-A\n" +
		"start-b\n" +
		"A-c\n" +
		"A-b\n" +
		"b-d\n" +
		"A-end\n" +
		"b-end\n";

	private const string Input2 =
		"dc-end\n" +
		"HN-start\n" +
		"start-kj\n" +
		"dc-start\n" +
		"dc-HN\n" +
		"LN-dc\n" +
		"HN-end\n" +
		"kj-sa\n" +
		"kj-HN\n" +
		"kj-dc\n";

	private const string Input3 =
		"fs-end\n" +
		"he-DX\n" +
		"fs-he\n" +
		"start-DX\n" +
		"pj-DX\n" +
		"end-zg\n" +
		"zg-sl\n" +
		"zg-pj\n" +
		"pj-he\n" +
		"RW-he\n" +
		"fs-DX\n" +
		"pj-RW\n" +
		"zg-RW\n" +
		"start-pj\n" +
		"he-WI\n" +
		"zg-he\n" +
		"pj-fs\n" +
		"start-RW\n";

	[TestMethod]
	[DataRow(10, Input1)]
	[DataRow(19, Input2)]
	[DataRow(226, Input3)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(36, Input1)]
	[DataRow(103, Input2)]
	[DataRow(3509, Input3)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input.ToLines()).Part2());
	}
}
