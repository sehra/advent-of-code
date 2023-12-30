namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day16Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 16);
	}

	[Benchmark]
	public string Part1() => new Day16(_input).Part1();

	[Benchmark]
	public string Part2() => new Day16(_input).Part2();
}
