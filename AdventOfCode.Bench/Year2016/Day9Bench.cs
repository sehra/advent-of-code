namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day9Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 9);
	}

	[Benchmark]
	public int Part1() => new Day9(_input).Part1();

	[Benchmark]
	public long Part2() => new Day9(_input).Part2();
}
