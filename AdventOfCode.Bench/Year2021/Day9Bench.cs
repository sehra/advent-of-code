namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day9Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 9);
	}

	[Benchmark]
	public int Part1() => new Day9(_input).Part1();

	[Benchmark]
	public int Part2() => new Day9(_input).Part2();
}
