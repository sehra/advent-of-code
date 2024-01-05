namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day22Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 22).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day22(_input).Part1();

	[Benchmark]
	public int Part2() => new Day22(_input).Part2();
}
