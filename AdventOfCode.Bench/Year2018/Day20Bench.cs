namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day20Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 20);
	}

	[Benchmark]
	public int Part1() => new Day20(_input).Part1();

	[Benchmark]
	public int Part2() => new Day20(_input).Part2();
}
