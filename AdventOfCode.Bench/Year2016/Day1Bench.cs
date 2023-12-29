namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day1Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 1);
	}

	[Benchmark]
	public int Part1() => new Day1(_input).Part1();

	[Benchmark]
	public int Part2() => new Day1(_input).Part2();
}
