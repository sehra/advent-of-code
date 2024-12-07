namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day7Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 7).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day7(_input).Part1();

	[Benchmark]
	public long Part2() => new Day7(_input).Part2();
}
