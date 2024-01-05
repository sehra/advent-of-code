namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day24Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 24).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day24(_input).Part1();

	[Benchmark]
	public int Part2() => new Day24(_input).Part2();
}
