namespace AdventOfCode.Year2015;

[TestClass]
public class Day14Tests
{
	private const string Input =
		"""
		Comet can fly 14 km/s for 10 seconds, but then must rest for 127 seconds.
		Dancer can fly 16 km/s for 11 seconds, but then must rest for 162 seconds.
		""";

	[TestMethod]
	[DataRow(1120, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part1(1000));
	}

	[TestMethod]
	[DataRow(689, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day14(input.ToLines()).Part2(1000));
	}
}
