namespace AdventOfCode.Year2016;

[MemoryDiagnoser]
public class Day14Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2016, 14);
	}

	[Benchmark]
	public int Part1() => new Day14(_input).Part1();

	[Benchmark]
	public int Part2() => new Day14(_input).Part2();
}
