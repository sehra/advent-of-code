namespace AdventOfCode.Year2017;

[MemoryDiagnoser]
public class Day18Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2017, 18).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day18(_input).Part1().GetAwaiter().GetResult();

	[Benchmark]
	public int Part2() => new Day18(_input).Part2().GetAwaiter().GetResult();
}
