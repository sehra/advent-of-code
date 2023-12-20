namespace AdventOfCode.Year2023;

[MemoryDiagnoser]
public class Day20Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2023, 20).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day20(_input).Part1();

	[Benchmark]
	public long Part2() => new Day20(_input).Part2();
}
