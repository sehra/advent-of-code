namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day6Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 6).ToLines();
	}

	[Benchmark]
	public string Part1() => new Day6(_input).Part1();

	[Benchmark]
	public string Part2() => new Day6(_input).Part2();
}
