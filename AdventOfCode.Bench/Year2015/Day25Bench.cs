namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day25Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 25);
	}

	[Benchmark]
	public int Part1() => new Day25(_input).Part1();
}
