using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day6Tests
	{
		[DataTestMethod]
		[DataRow(6,
			"abcx\n" +
			"abcy\n" +
			"abcz\n")]
		[DataRow(11,
			"abc\n" +
			"\n" +
			"a\n" +
			"b\n" +
			"c\n" +
			"\n" +
			"ab\n" +
			"ac\n" +
			"\n" +
			"a\n" +
			"a\n" +
			"a\n" +
			"a\n" +
			"\n" +
			"b\n")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day6(input).Part1());
		}

		[DataTestMethod]
		[DataRow(6,
			"abc\n" +
			"\n" +
			"a\n" +
			"b\n" +
			"c\n" +
			"\n" +
			"ab\n" +
			"ac\n" +
			"\n" +
			"a\n" +
			"a\n" +
			"a\n" +
			"a\n" +
			"\n" +
			"b\n")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day6(input).Part2());
		}
	}
}
