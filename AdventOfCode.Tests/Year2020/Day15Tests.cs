using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2020
{
	[TestClass]
	public class Day15Tests
	{
		[DataTestMethod]
		[DataRow(436, "0,3,6")]
		[DataRow(1, "1,3,2")]
		[DataRow(10, "2,1,3")]
		[DataRow(27, "1,2,3")]
		[DataRow(78, "2,3,1")]
		[DataRow(438, "3,2,1")]
		[DataRow(1836, "3,1,2")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day15(input).Part1());
		}

		[Ignore]
		[DataTestMethod]
		[DataRow(175594, "0,3,6")]
		[DataRow(2578, "1,3,2")]
		[DataRow(3544142, "2,1,3")]
		[DataRow(261214, "1,2,3")]
		[DataRow(6895259, "2,3,1")]
		[DataRow(18, "3,2,1")]
		[DataRow(362, "3,1,2")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day15(input).Part2());
		}
	}
}
