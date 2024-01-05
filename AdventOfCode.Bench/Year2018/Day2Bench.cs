namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day2Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 2).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day2(_input).Part1();

	[Benchmark]
	public string Part2() => new Day2(_input).Part2();
}
