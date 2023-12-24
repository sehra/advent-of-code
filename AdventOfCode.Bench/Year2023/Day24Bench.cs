namespace AdventOfCode.Year2023;

[MemoryDiagnoser]
public class Day24Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2023, 24).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day24(_input).Part1();

	[Benchmark]
	public long Part2() => new Day24(_input).Part2();
}
