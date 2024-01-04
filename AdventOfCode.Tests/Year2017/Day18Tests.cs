namespace AdventOfCode.Year2017;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"""
		set a 1
		add a 2
		mul a a
		mod a 5
		snd a
		set a 0
		rcv a
		jgz a -1
		set a 1
		jgz a -2
		""";
	private const string Input2 =
		"""
		snd 1
		snd 2
		snd p
		rcv a
		rcv b
		rcv c
		rcv d
		""";

	[DataTestMethod]
	[DataRow(4, Input)]
	public async Task Part1(int expected, string input)
	{
		Assert.AreEqual(expected, await new Day18(input.ToLines()).Part1());
	}

	[Ignore("LongRunning")]
	[DataTestMethod]
	[DataRow(3, Input2)]
	public async Task Part2(int expected, string input)
	{
		Assert.AreEqual(expected, await new Day18(input.ToLines()).Part2());
	}
}
