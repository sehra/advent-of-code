namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day11Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 11).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day11(_input).Part1();

	[Benchmark]
	public int Part2() => new Day11(_input).Part2();
}
