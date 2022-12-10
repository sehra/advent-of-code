namespace AdventOfCode.Year2022;

[MemoryDiagnoser]
public class Day10Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2022, 10).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day10(_input).Part1();

	[Benchmark]
	public string Part2() => new Day10(_input).Part2();
}
