namespace AdventOfCode.Year2018;

[MemoryDiagnoser]
public class Day13Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2018, 13);
	}

	[Benchmark]
	public string Part1() => new Day13(_input).Part1();

	[Benchmark]
	public string Part2() => new Day13(_input).Part2();
}
