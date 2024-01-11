namespace AdventOfCode.Year2018;

[TestClass]
public class Day20Tests
{
	[DataTestMethod]
	[DataRow(3, "^WNE$")]
	[DataRow(10, "^ENWWW(NEEE|SSE(EE|N))$")]
	[DataRow(18, "^ENNWSWW(NEWS|)SSSEEN(WNSE|)EE(SWEN|)NNN$")]
	[DataRow(23, "^ESSWWN(E|NNENN(EESS(WNSE|)SSS|WWWSSSSE(SW|NNNE)))$")]
	[DataRow(31, "^WSSEESWWWNW(S|NENNEEEENN(ESSSSW(NWSW|SSEN)|WSWWN(E|WWS(E|SS))))$")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day20(input).Part1());
	}
}
