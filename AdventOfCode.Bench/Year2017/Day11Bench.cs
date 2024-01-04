namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day11Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 11);
	}

	[Benchmark]
	public int Part1() => new Day11(_input).Part1();

	[Benchmark]
	public int Part2() => new Day11(_input).Part2();
}
