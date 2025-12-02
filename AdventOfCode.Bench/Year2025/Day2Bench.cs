namespace AdventOfCode.Year2025;

[MemoryDiagnoser]
public class Day2Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2025, 2);
	}

	[Benchmark]
	public long Part1() => new Day2(_input).Part1();

	[Benchmark]
	public long Part2() => new Day2(_input).Part2();
}
