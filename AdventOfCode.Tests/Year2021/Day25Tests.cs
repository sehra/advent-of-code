namespace AdventOfCode.Year2021;

[TestClass]
public class Day25Tests
{
	public const string Input =
		"v...>>.vv>\n" +
		".vv>>.vv..\n" +
		">>.>v>...v\n" +
		">>v>>.>.v.\n" +
		"v>v.vv.v..\n" +
		">.>>..v...\n" +
		".vv..>.>v.\n" +
		"v.v..>>v.v\n" +
		"....v..v.>\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(58, new Day25(Input.ToLines()).Part1());
	}
}
