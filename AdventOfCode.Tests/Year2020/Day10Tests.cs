namespace AdventOfCode.Year2020;

[TestClass]
public class Day10Tests
{
	[DataTestMethod]
	[DataRow(7 * 5, "16\n10\n15\n5\n1\n11\n7\n19\n6\n12\n4\n")]
	[DataRow(22 * 10,
		"28\n33\n18\n42\n31\n14\n46\n20\n48\n47\n24\n23\n49\n45\n19\n" +
		"38\n39\n11\n1\n32\n25\n35\n8\n17\n7\n9\n4\n2\n34\n10\n3\n")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input).Part1());
	}

	[DataTestMethod]
	[DataRow(8, "16\n10\n15\n5\n1\n11\n7\n19\n6\n12\n4\n")]
	[DataRow(19208,
		"28\n33\n18\n42\n31\n14\n46\n20\n48\n47\n24\n23\n49\n45\n19\n" +
		"38\n39\n11\n1\n32\n25\n35\n8\n17\n7\n9\n4\n2\n34\n10\n3\n")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day10(input).Part2());
	}
}
