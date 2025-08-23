namespace AdventOfCode.Year2017;

[TestClass]
public class Day25Tests
{
	private const string Input =
		"""
		Begin in state A.
		Perform a diagnostic checksum after 6 steps.

		In state A:
		  If the current value is 0:
		    - Write the value 1.
		    - Move one slot to the right.
		    - Continue with state B.
		  If the current value is 1:
		    - Write the value 0.
		    - Move one slot to the left.
		    - Continue with state B.

		In state B:
		  If the current value is 0:
		    - Write the value 1.
		    - Move one slot to the left.
		    - Continue with state A.
		  If the current value is 1:
		    - Write the value 1.
		    - Move one slot to the right.
		    - Continue with state A.
		""";

	[TestMethod]
	[DataRow(3, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input.ToLines()).Part1());
	}
}
