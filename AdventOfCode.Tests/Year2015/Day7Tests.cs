namespace AdventOfCode.Year2015;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		123 -> x
		456 -> y
		x AND y -> d
		x OR y -> e
		x LSHIFT 2 -> f
		y RSHIFT 2 -> g
		NOT x -> h
		NOT y -> i
		""";

	[TestMethod]
	[DataRow(72, Input, "d")]
	[DataRow(507, Input, "e")]
	[DataRow(492, Input, "f")]
	[DataRow(114, Input, "g")]
	[DataRow(65412, Input, "h")]
	[DataRow(65079, Input, "i")]
	[DataRow(123, Input, "x")]
	[DataRow(456, Input, "y")]
	public void Part1(int expected, string input, string wire)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1(wire));
	}

	//[DataTestMethod]
	//[DataRow(0, "")]
	//public void Part2(int expected, string input)
	//{
	//	Assert.AreEqual(expected, new Day7(input).Part2());
	//}
}
