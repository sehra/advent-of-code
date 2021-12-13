namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day23Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 23);
	}

	[Benchmark]
	public string Part1() => new Day23(_input).Part1();

	[Benchmark]
	public long Part2() => new Day23(_input).Part2();
}
