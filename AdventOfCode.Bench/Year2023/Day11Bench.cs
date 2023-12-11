namespace AdventOfCode.Year2023;

[MemoryDiagnoser]
public class Day11Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2023, 11).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day11(_input).Part1();

	[Benchmark]
	public long Part2() => new Day11(_input).Part2();
}
