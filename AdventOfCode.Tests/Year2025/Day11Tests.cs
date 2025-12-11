namespace AdventOfCode.Year2025;

[TestClass]
public class Day11Tests
{
	private const string Input1 =
		"""
		aaa: you hhh
		you: bbb ccc
		bbb: ddd eee
		ccc: ddd eee fff
		ddd: ggg
		eee: out
		fff: out
		ggg: out
		hhh: ccc fff iii
		iii: out
		""";
	private const string Input2 =
		"""
		svr: aaa bbb
		aaa: fft
		fft: ccc
		bbb: tty
		tty: ccc
		ccc: ddd eee
		ddd: hub
		hub: fff
		eee: dac
		dac: fff
		fff: ggg hhh
		ggg: out
		hhh: out
		""";

	[TestMethod]
	[DataRow(5, Input1)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input.ToLines()).Part1());
	}

	[TestMethod]
	[DataRow(2, Input2)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day11(input.ToLines()).Part2());
	}
}
