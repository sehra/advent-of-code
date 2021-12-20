using static AdventOfCode.Year2021.Day18;

namespace AdventOfCode.Year2021;

[TestClass]
public class Day18Tests
{
	private const string Input =
		"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]\n" +
		"[[[5,[2,8]],4],[5,[[9,9],0]]]\n" +
		"[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]\n" +
		"[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]\n" +
		"[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]\n" +
		"[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]\n" +
		"[[[[5,4],[7,7]],8],[[8,3],8]]\n" +
		"[[9,3],[[9,9],[6,[4,9]]]]\n" +
		"[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]\n" +
		"[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(4140, new Day18(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(3993, new Day18(Input.ToLines()).Part2());
	}

	[DataTestMethod]
	[DataRow("[[[[0,9],2],3],4]", "[[[[[9,8],1],2],3],4]")]
	[DataRow("[7,[6,[5,[7,0]]]]", "[7,[6,[5,[4,[3,2]]]]]")]
	[DataRow("[[6,[5,[7,0]]],3]", "[[6,[5,[4,[3,2]]]],1]")]
	[DataRow("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]")]
	[DataRow("[[3,[2,[8,0]]],[9,[5,[7,0]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
	public void ExplodeTest(string expected, string input)
	{
		var number = Number.Parse(input);
		Assert.IsTrue(number.Explode());
		Assert.AreEqual(Number.Parse(expected), number);
	}

	[DataTestMethod]
	[DataRow("[5,5]", "10")]
	[DataRow("[5,6]", "11")]
	[DataRow("[6,6]", "12")]
	public void SplitTest(string expected, string input)
	{
		var number = Number.Parse(input);
		Assert.IsTrue(number.Split());
		Assert.AreEqual(Number.Parse(expected), number);
	}

	[DataTestMethod]
	[DataRow("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]")]
	public void ReduceTest(string expected, string input)
	{
		var number = Number.Parse(input).Reduce();
		Assert.AreEqual(Number.Parse(expected), number);
	}

	private const string Sum1 =
		"[1,1]\n" +
		"[2,2]\n" +
		"[3,3]\n" +
		"[4,4]\n";

	private const string Sum2 =
		"[1,1]\n" +
		"[2,2]\n" +
		"[3,3]\n" +
		"[4,4]\n" +
		"[5,5]\n";

	private const string Sum3 =
		"[1,1]\n" +
		"[2,2]\n" +
		"[3,3]\n" +
		"[4,4]\n" +
		"[5,5]\n" +
		"[6,6]\n";

	private const string Sum4 =
		"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]\n" +
		"[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]\n" +
		"[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]\n" +
		"[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]\n" +
		"[7,[5,[[3,8],[1,4]]]]\n" +
		"[[2,[2,2]],[8,[8,1]]]\n" +
		"[2,9]\n" +
		"[1,[[[9,3],9],[[9,0],[0,7]]]]\n" +
		"[[[5,[7,4]],7],1]\n" +
		"[[[[4,2],2],6],[8,7]]";

	[DataTestMethod]
	[DataRow("[[[[1,1],[2,2]],[3,3]],[4,4]]", Sum1)]
	[DataRow("[[[[3,0],[5,3]],[4,4]],[5,5]]", Sum2)]
	[DataRow("[[[[5,0],[7,4]],[5,5]],[6,6]]", Sum3)]
	[DataRow("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", Sum4)]
	public void SumTest(string expected, string input)
	{
		var numbers = Parse(input.ToLines());
		Assert.AreEqual(Number.Parse(expected), Sum(numbers));
	}

	[DataTestMethod]
	[DataRow(143, "[[1,2],[[3,4],5]]")]
	[DataRow(1384, "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
	[DataRow(445, "[[[[1,1],[2,2]],[3,3]],[4,4]]")]
	[DataRow(791, "[[[[3,0],[5,3]],[4,4]],[5,5]]")]
	[DataRow(1137, "[[[[5,0],[7,4]],[5,5]],[6,6]]")]
	[DataRow(3488, "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
	public void MagnitudeTest(int expected, string input)
	{
		Assert.AreEqual(expected, Number.Parse(input).Magnitude());
	}
}
