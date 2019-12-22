using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day22Tests
	{
		[DataTestMethod]
		[DataRow(0,
			"deal with increment 7\n" +
			"deal into new stack\n" +
			"deal into new stack")]
		[DataRow(1,
			"cut 6\n" +
			"deal with increment 7\n" +
			"deal into new stack")]
		[DataRow(2,
			"deal with increment 7\n" +
			"deal with increment 9\n" +
			"cut -2")]
		[DataRow(7,
			"deal into new stack\n" +
			"cut -2\n" +
			"deal with increment 7\n" +
			"cut 8\n" +
			"cut -4\n" +
			"deal with increment 7\n" +
			"cut 3\n" +
			"deal with increment 9\n" +
			"deal with increment 3\n" +
			"cut -1")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day22(input).Part1(10, 0));
		}
	}
}
