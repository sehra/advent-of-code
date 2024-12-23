namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day19Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 19).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day19(_input).Part1();

	[Benchmark]
	public long Part2() => new Day19(_input).Part2();
}
