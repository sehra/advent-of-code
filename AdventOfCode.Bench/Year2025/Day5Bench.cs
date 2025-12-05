namespace AdventOfCode.Year2025;

[MemoryDiagnoser]
public class Day5Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2025, 5).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day5(_input).Part1();

	[Benchmark]
	public long Part2() => new Day5(_input).Part2();
}
