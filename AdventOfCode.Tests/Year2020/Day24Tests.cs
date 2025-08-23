namespace AdventOfCode.Year2020;

[TestClass]
public class Day24Tests
{
	private const string Input =
		"sesenwnenenewseeswwswswwnenewsewsw\n" +
		"neeenesenwnwwswnenewnwwsewnenwseswesw\n" +
		"seswneswswsenwwnwse\n" +
		"nwnwneseeswswnenewneswwnewseswneseene\n" +
		"swweswneswnenwsewnwneneseenw\n" +
		"eesenwseswswnenwswnwnwsewwnwsene\n" +
		"sewnenenenesenwsewnenwwwse\n" +
		"wenwwweseeeweswwwnwwe\n" +
		"wsweesenenewnwwnwsenewsenwwsesesenwne\n" +
		"neeswseenwwswnwswswnw\n" +
		"nenwswwsewswnenenewsenwsenwnesesenew\n" +
		"enewnwewneswsewnwswenweswnenwsenwsw\n" +
		"sweneswneswneneenwnewenewwneswswnese\n" +
		"swwesenesewenwneswnwwneseswwne\n" +
		"enesenwswwswneneswsenwnewswseenwsese\n" +
		"wnwnesenesenenwwnenwsewesewsesesew\n" +
		"nenewswnwewswnenesenwnesewesw\n" +
		"eneswnwswnwsenenwnwnwwseeswneewsenese\n" +
		"neswnwewnwnwseenwseesewsenwsweewe\n" +
		"wseweeenwnesenwwwswnew\n";

	[TestMethod]
	[DataRow(10, Input)]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input).Part1());
	}

	[TestMethod]
	[DataRow(2208, Input)]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day24(input).Part2());
	}
}
