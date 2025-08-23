namespace AdventOfCode.Year2022;

[TestClass]
public class Day13Tests
{
	private const string Input =
		"""
		[1,1,3,1,1]
		[1,1,5,1,1]

		[[1],[2,3,4]]
		[[1],4]

		[9]
		[[8,7,6]]

		[[4,4],4,4]
		[[4,4],4,4,4]

		[7,7,7,7]
		[7,7,7]

		[]
		[3]

		[[[]]]
		[[]]

		[1,[2,[3,[4,[5,6,7]]]],8,9]
		[1,[2,[3,[4,[5,6,0]]]],8,9]
		""";

	[TestMethod]
	[DataRow(13, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(140, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input.ToLines()).Part2());
	}
}
