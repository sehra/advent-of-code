namespace AdventOfCode.Year2022;

[MemoryDiagnoser]
public class Day25Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2022, 25).ToLines();
	}

	[Benchmark]
	public string Part1() => new Day25(_input).Part1();
}
