namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day25Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 25).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day25(_input).Part1();
}
