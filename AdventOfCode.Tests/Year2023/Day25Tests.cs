namespace AdventOfCode.Year2023;

[TestClass]
public class Day25Tests
{
	private const string Input =
		"""
		jqt: rhn xhk nvd
		rsh: frs pzl lsr
		xhk: hfx
		cmg: qnr nvd lhk bvb
		rhn: xhk bvb hfx
		bvb: xhk hfx
		pzl: lsr hfx nvd
		qnr: nvd
		ntq: jqt hfx bvb xhk
		nvd: lhk
		lsr: lhk
		rzs: qnr cmg lsr rsh
		frs: qnr lhk lsr
		""";

	[DataTestMethod]
	[DataRow(54, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day25(input.ToLines()).Part1());
	}
}
