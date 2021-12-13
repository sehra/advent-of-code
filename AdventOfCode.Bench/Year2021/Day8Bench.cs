namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day8Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 8);
	}

	[Benchmark]
	public int Part1() => new Day8(_input).Part1();

	[Benchmark]
	public int Part2() => new Day8(_input).Part2();
}
