namespace AdventOfCode.Year2023;

[MemoryDiagnoser]
public class Day8Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2023, 8).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day8(_input).Part1();

	[Benchmark]
	public long Part2() => new Day8(_input).Part2();
}
