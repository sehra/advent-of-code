namespace AdventOfCode.Year2018;

[TestClass]
public class Day2Tests
{
	private const string Input1 =
		"""
		abcdef
		bababc
		abbcde
		abcccd
		aabcdd
		abcdee
		ababab
		""";

	[TestMethod]
	[DataRow(12, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part1());
	}

	private const string Input2 =
		"""
		abcde
		fghij
		klmno
		pqrst
		fguij
		axcye
		wvxyz
		""";

	[TestMethod]
	[DataRow("fgij", Input2)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day2(input.ToLines()).Part2());
	}
}
