using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year2019
{
	[TestClass]
	public class Day16Tests
	{
		[DataTestMethod]
		[DataRow("12345678", 1, "48226158")]
		[DataRow("12345678", 2, "34040438")]
		[DataRow("12345678", 3, "03415518")]
		[DataRow("12345678", 4, "01029498")]
		[DataRow("80871224585914546619083218645595", 100, "24176176")]
		[DataRow("19617804207202209144916044189917", 100, "73745418")]
		[DataRow("69317163492948606335995924319873", 100, "52432133")]
		public void Part1(string input, int phases, string expected)
		{
			Assert.AreEqual(expected, new Day16(input).Part1(phases));
		}

		[DataTestMethod]
		[DataRow("03036732577212944063491565474664", "84462026")]
		[DataRow("02935109699940807407585447034323", "78725270")]
		[DataRow("03081770884921959731165446850517", "53553731")]
		public void Part2(string input, string expected)
		{
			Assert.AreEqual(expected, new Day16(input).Part2());
		}
	}
}
