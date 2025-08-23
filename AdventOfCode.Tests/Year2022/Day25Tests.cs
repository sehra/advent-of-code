namespace AdventOfCode.Year2022;

[TestClass]
public class Day25Tests
{
	private const string Input =
		"""
		1=-0-2
		12111
		2=0=
		21
		2=01
		111
		20012
		112
		1=-1=
		1-12
		12
		1=
		122
		""";

	[TestMethod]
	[DataRow("2=-1=0", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input.ToLines()).Part1());
	}
}
