namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day18Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 18);
	}

	[Benchmark]
	public long Part1() => new Day18(_input).Part1();

	[Benchmark]
	public long Part2() => new Day18(_input).Part2();
}
