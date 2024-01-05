namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day19Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 19);
	}

	[Benchmark]
	public string Part1() => new Day19(_input).Part1();

	[Benchmark]
	public int Part2() => new Day19(_input).Part2();
}
