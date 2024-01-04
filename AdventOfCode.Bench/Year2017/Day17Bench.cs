namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day17Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 17);
	}

	[Benchmark]
	public int Part1() => new Day17(_input).Part1();

	[Benchmark]
	public int Part2() => new Day17(_input).Part2();
}
