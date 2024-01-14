namespace AdventOfCode.Year2018;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		Step C must be finished before step A can begin.
		Step C must be finished before step F can begin.
		Step A must be finished before step B can begin.
		Step A must be finished before step D can begin.
		Step B must be finished before step E can begin.
		Step D must be finished before step E can begin.
		Step F must be finished before step E can begin.
		""";

	[DataTestMethod]
	[DataRow("CABDFE", Input)]
	public void Part1(string expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(15, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2(2, 0));
	}
}
