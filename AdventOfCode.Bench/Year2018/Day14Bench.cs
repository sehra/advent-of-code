namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day14Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 14);
	}

	[Benchmark]
	public string Part1() => new Day14(_input).Part1();

	[Benchmark]
	public int Part2() => new Day14(_input).Part2();
}
