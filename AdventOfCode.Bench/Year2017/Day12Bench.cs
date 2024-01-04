namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day12Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 12).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day12(_input).Part1();

	[Benchmark]
	public int Part2() => new Day12(_input).Part2();
}
