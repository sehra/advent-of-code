namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day21Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 21).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day21(_input).Part1();

	[Benchmark]
	public int Part2() => new Day21(_input).Part2();
}
