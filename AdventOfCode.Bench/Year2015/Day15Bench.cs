namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day15Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 15).ToLines();
	}

	[Benchmark]
	public long Part1() => new Day15(_input).Part1();

	[Benchmark]
	public long Part2() => new Day15(_input).Part2();
}
