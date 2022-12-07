namespace AdventOfCode.Year2022;

[TestClass]
public class Day7Tests
{
	private const string Input =
		"""
		$ cd /
		$ ls
		dir a
		14848514 b.txt
		8504156 c.dat
		dir d
		$ cd a
		$ ls
		dir e
		29116 f
		2557 g
		62596 h.lst
		$ cd e
		$ ls
		584 i
		$ cd ..
		$ cd ..
		$ cd d
		$ ls
		4060174 j
		8033020 d.log
		5626152 d.ext
		7214296 k
		""";

	[DataTestMethod]
	[DataRow(95437, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part1());
	}

	[DataTestMethod]
	[DataRow(24933642, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day7(input.ToLines()).Part2());
	}
}
