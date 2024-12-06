namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day6Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 6).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day6(_input).Part1();

	[Benchmark]
	public int Part2() => new Day6(_input).Part2();
}
