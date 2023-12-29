namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day11Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 11);
	}

	[Benchmark]
	public string Part1() => new Day11(_input).Part1();

	[Benchmark]
	public string Part2() => new Day11(_input).Part2();
}
