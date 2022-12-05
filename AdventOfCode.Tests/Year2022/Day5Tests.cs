namespace AdventOfCode.Year2022;

[TestClass]
public class Day5Tests
{
	private const string Input =
		"""
		    [D]    
		[N] [C]    
		[Z] [M] [P]
		 1   2   3 

		move 1 from 2 to 1
		move 3 from 1 to 3
		move 2 from 2 to 1
		move 1 from 1 to 2
		""";

	[DataTestMethod]
	[DataRow("CMZ", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part1());
	}

	[DataTestMethod]
	[DataRow("MCD", Input)]
	public void Part2(string expected, string input)
	{
		Assert.AreEqual(expected, new Day5(input).Part2());
	}
}
