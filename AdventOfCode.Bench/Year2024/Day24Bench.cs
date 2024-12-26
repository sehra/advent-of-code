namespace AdventOfCode.Year2024;

[MemoryDiagnoser]
public class Day24Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2024, 24).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day24(_input).Part1();

	[Benchmark]
	public string Part2() => new Day24(_input).Part2();
}
