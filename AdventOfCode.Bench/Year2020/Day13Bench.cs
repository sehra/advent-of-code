namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day13Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2020, 13);
	}

	[Benchmark]
	public int Part1() => new Day13(_input).Part1();

	[Benchmark]
	public long Part2() => new Day13(_input).Part2();
}
