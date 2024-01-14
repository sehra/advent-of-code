namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day23Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 23).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day23(_input).Part1();

	[Benchmark]
	public int Part2() => new Day23(_input).Part2();
}
