namespace AdventOfCode.Year2018;

[TestClass]
public class Day23Tests
{
	private const string Input1 =
		"""
		pos=<0,0,0>, r=4
		pos=<1,0,0>, r=1
		pos=<4,0,0>, r=3
		pos=<0,2,0>, r=1
		pos=<0,5,0>, r=3
		pos=<0,0,3>, r=1
		pos=<1,1,1>, r=1
		pos=<1,1,2>, r=1
		pos=<1,3,1>, r=1
		""";

	private const string Input2 =
		"""
		pos=<10,12,12>, r=2
		pos=<12,14,12>, r=2
		pos=<16,12,12>, r=4
		pos=<14,14,14>, r=6
		pos=<50,50,50>, r=200
		pos=<10,10,10>, r=5
		""";

	[DataTestMethod]
	[DataRow(7, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(36, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day23(input.ToLines()).Part2());
	}
}
