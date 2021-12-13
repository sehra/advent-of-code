namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day10Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 10).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day10(_input).Part1();

	[Benchmark]
	public long Part2() => new Day10(_input).Part2();
}
