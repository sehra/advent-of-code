namespace AdventOfCode.Year2015;

[MemoryDiagnoser]
public class Day23Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2015, 23).ToLines();
	}

	[Benchmark]
	public uint Part1() => new Day23(_input).Part1();

	[Benchmark]
	public uint Part2() => new Day23(_input).Part2();
}
