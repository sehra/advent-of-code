namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day25Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 25).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day25(_input).Part1();

	[Benchmark]
	public string Part2() => new Day25(_input).Part2();
}
