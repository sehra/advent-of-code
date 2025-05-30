namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day5Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 5);
	}

	[Benchmark]
	public string Part1() => new Day5(_input).Part1();

	[Benchmark]
	public string Part2() => new Day5(_input).Part2();
}
