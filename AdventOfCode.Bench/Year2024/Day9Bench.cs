namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day9Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 9);
	}

	[Benchmark]
	public long Part1() => new Day9(_input).Part1();

	[Benchmark]
	public long Part2() => new Day9(_input).Part2();
}
