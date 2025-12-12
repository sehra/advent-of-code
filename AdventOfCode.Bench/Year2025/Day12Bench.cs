namespace AdventOfCode.Year2025;

[MemoryDiagnoser]
public class Day12Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2025, 12).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day12(_input).Part1();
}
