namespace AdventOfCode.Year2021;

[TestClass]
public class Day10Tests
{
	private readonly string Input =
		"[({(<(())[]>[[{[]{<()<>>\n" +
		"[(()[<>])]({[<{<<[]>>(\n" +
		"{([(<{}[<>[]}>{[]{[(<()>\n" +
		"(((({<>}<{<{<>}{[]{[]{}\n" +
		"[[<[([]))<([[{}[[()]]]\n" +
		"[{[{({}]{}}([{[{{{}}([]\n" +
		"{<[[]]>}<{[{[{[]{()[[[]\n" +
		"[<(<(<(<{}))><([]([]()\n" +
		"<{([([[(<>()){}]>(<<{{\n" +
		"<{([{{}}[<[[[<>{}]]]>[]]\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(26397, new Day10(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(288957, new Day10(Input.ToLines()).Part2());
	}
}
