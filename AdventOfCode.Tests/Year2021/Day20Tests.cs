namespace AdventOfCode.Year2021;

[TestClass]
public class Day20Tests
{
	private const string Input =
		"..#.#..#####.#.#.#.###.##.....###.##.#..###.####..#####..#....#..#..##..##" +
		"#..######.###...####..#..#####..##..#.#####...##.#.#..#.##..#.#......#.###" +
		".######.###.####...#.##.##..#..#..#####.....#.#....###..#.##......#.....#." +
		".#..#..##..#...##.######.####.####.#.#...#.......#..#.#.#...####.##.#....." +
		".#..#...##.#.##..#...##.#.##..###.#......#.#.......#.#.#.####.###.##...#.." +
		"...####.#..#..#.##.#....##..#.####....##...##..#...#......#.#.......#....." +
		"..##..####..#...#.#.#...##..#.#..###..#####........#..####......#..#\n" +
		"\n" +
		"#..#.\n" +
		"#....\n" +
		"##..#\n" +
		"..#..\n" +
		"..###\n";

	[TestMethod]
	public void Part1()
	{
		Assert.AreEqual(35, new Day20(Input.ToLines()).Part1());
	}

	[TestMethod]
	public void Part2()
	{
		Assert.AreEqual(3351, new Day20(Input.ToLines()).Part2());
	}
}
