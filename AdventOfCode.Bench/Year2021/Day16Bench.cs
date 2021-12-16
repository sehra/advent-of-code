namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day16Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 16);
	}

	[Benchmark]
	public int Part1() => new Day16(_input).Part1();

	[Benchmark]
	public long Part2() => new Day16(_input).Part2();
}
