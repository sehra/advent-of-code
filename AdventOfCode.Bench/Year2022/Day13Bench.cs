namespace AdventOfCode.Year2022;

[MemoryDiagnoser]
public class Day13Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2022, 13).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day13(_input).Part1();

	[Benchmark]
	public int Part2() => new Day13(_input).Part2();
}
