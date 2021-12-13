namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day25Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 25);
	}

	[Benchmark]
	public long Part1() => new Day25(_input).Part1();

	[Benchmark]
	public string Part2() => new Day25(_input).Part2();
}
