namespace AdventOfCode.Year2017;

[TestClass]
public class Day20Tests
{
	private const string Input1 =
		"""
		p=< 3,0,0>, v=< 2,0,0>, a=<-1,0,0>
		p=< 4,0,0>, v=< 0,0,0>, a=<-2,0,0>
		""";
	private const string Input2 =
		"""
		p=<-6,0,0>, v=< 3,0,0>, a=< 0,0,0>
		p=<-4,0,0>, v=< 2,0,0>, a=< 0,0,0>
		p=<-2,0,0>, v=< 1,0,0>, a=< 0,0,0>
		p=< 3,0,0>, v=<-1,0,0>, a=< 0,0,0>
		""";

	[TestMethod]
	[DataRow(0, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(1, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input.ToLines()).Part2());
	}
}
