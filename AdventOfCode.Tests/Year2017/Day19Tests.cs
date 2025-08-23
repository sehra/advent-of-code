namespace AdventOfCode.Year2017;

[TestClass]
public class Day19Tests
{
	private const string Input =
		"""
		     |          
		     |  +--+    
		     A  |  C    
		 F---|----E|--+ 
		     |  |  |  D 
		     +B-+  +--+ 
		""";

	[TestMethod]
	[DataRow("ABCDEF", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part1());
	}

	[TestMethod]
	[DataRow(38, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day19(input).Part2());
	}
}
