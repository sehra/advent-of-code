namespace AdventOfCode.Year2018;

[TestClass]
public class Day13Tests
{
	private const string Input1 =
		"""
		/->-\        
		|   |  /----\
		| /-+--+-\  |
		| | |  | v  |
		\-+-/  \-+--/
		  \------/   
		""";
	private const string Input2 =
		"""
		/>-<\  
		|   |  
		| /<+-\
		| | | v
		\>+</ |
		  |   ^
		  \<->/
		""";

	[TestMethod]
	[DataRow("7,3", Input1)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input).Part1());
	}

	[TestMethod]
	[DataRow("6,4", Input2)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day13(input).Part2());
	}
}
