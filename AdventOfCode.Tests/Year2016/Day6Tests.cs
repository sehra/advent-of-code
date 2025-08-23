namespace AdventOfCode.Year2016;

[TestClass]
public class Day6Tests
{
	private const string Input =
		"""
		eedadn
		drvtee
		eandsr
		raavrd
		atevrs
		tsrnev
		sdttsa
		rasrtv
		nssdts
		ntnada
		svetve
		tesnvt
		vntsnd
		vrdear
		dvrsen
		enarar
		""";

	[TestMethod]
	[DataRow("easter", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow("advent", Input)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day6(input.ToLines()).Part2());
	}
}
