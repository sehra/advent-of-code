namespace AdventOfCode.Year2025;

[MemoryDiagnoser]
public class Day6Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2025, 6);
	}

	[Benchmark]
	public long Part1() => new Day6(_input).Part1();

	[Benchmark]
	public long Part2() => new Day6(_input).Part2();
}
