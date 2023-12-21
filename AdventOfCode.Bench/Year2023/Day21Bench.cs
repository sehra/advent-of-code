namespace AdventOfCode.Year2023;

[MemoryDiagnoser]
public class Day21Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2023, 21).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day21(_input).Part1();

	[Benchmark]
	public long Part2() => new Day21(_input).Part2();
}
