namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day3Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 3);
	}

	[Benchmark]
	public long Part1() => new Day3(_input).Part1();

	[Benchmark]
	public long Part2() => new Day3(_input).Part2();
}
