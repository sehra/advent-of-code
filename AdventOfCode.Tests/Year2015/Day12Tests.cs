namespace AdventOfCode.Year2015;

[TestClass]
public class Day12Tests
{
	[TestMethod]
	[DataRow(6, "[1,2,3]")]
	[DataRow(6, "{\"a\":2,\"b\":4}")]
	[DataRow(3, "[[[3]]]")]
	[DataRow(3, "{\"a\":{\"b\":4},\"c\":-1}")]
	[DataRow(0, "{\"a\":[-1,1]}")]
	[DataRow(0, "[-1,{\"a\":1}]")]
	[DataRow(0, "[]")]
	[DataRow(0, "{}")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input).Part1());
	}

	[TestMethod]
	[DataRow(6, "[1,2,3]")]
	[DataRow(4, "[1,{\"c\":\"red\",\"b\":2},3]")]
	[DataRow(0, "{\"d\":\"red\",\"e\":[1,2,3,4],\"f\":5}")]
	[DataRow(6, "[1,\"red\",5]")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day12(input).Part2());
	}
}
