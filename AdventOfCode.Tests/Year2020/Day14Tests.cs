using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day14Tests
	{
		[DataTestMethod]
		[DataRow(165,
			"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X\n" +
			"mem[8] = 11\n" +
			"mem[7] = 101\n" +
			"mem[8] = 0\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day14(input).Part1());
		}

		[DataTestMethod]
		[DataRow(208,
			"mask = 000000000000000000000000000000X1001X\n" +
			"mem[42] = 100\n" +
			"mask = 00000000000000000000000000000000X0XX\n" +
			"mem[26] = 1\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day14(input).Part2());
		}
	}
}
