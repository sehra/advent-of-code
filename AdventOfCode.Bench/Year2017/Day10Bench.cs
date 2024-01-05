namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day10Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 10);
	}

	[Benchmark]
	public int Part1() => new Day10(_input).Part1();

	[Benchmark]
	public string Part2() => new Day10(_input).Part2();
}
