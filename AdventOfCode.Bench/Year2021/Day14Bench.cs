namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day14Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 14).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day14(_input).Part1();

	[Benchmark]
	public long Part2() => new Day14(_input).Part2();
}
