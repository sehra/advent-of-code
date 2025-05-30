namespace AdventOfCode.Year2016;

[TestClass]
public class Day21Tests
{
	[DataTestMethod]
	[DataRow("decab",
		"""
		swap position 4 with position 0
		swap letter d with letter b
		reverse positions 0 through 4
		rotate left 1 step
		move position 1 to position 4
		move position 3 to position 0
		rotate based on position of letter b
		rotate based on position of letter d
		""")]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day21(input.ToLines()).Part1("abcde"));
	}
}
