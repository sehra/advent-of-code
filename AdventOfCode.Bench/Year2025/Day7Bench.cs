namespace AdventOfCode.Year2025;

[MemoryDiagnoser]
public class Day7Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2025, 7).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day7(_input).Part1();

	[Benchmark]
	public long Part2() => new Day7(_input).Part2();
}
