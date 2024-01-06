namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day7Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 7).ToLines();
	}

	[Benchmark]
	public string Part1() => new Day7(_input).Part1();

	[Benchmark]
	public int Part2() => new Day7(_input).Part2();
}
