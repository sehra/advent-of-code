namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day12Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 12).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day12(_input).Part1();

	[Benchmark]
	public long Part2() => new Day12(_input).Part2();
}
