using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day8Tests
	{
		[DataTestMethod]
		[DataRow(5,
			"nop +0\n" +
			"acc +1\n" +
			"jmp +4\n" +
			"acc +3\n" +
			"jmp -3\n" +
			"acc -99\n" +
			"acc +1\n" +
			"jmp -4\n" +
			"acc +6\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day8(input).Part1());
		}

		[DataTestMethod]
		[DataRow(8,
			"nop +0\n" +
			"acc +1\n" +
			"jmp +4\n" +
			"acc +3\n" +
			"jmp -3\n" +
			"acc -99\n" +
			"acc +1\n" +
			"jmp -4\n" +
			"acc +6\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day8(input).Part2());
		}
	}
}
