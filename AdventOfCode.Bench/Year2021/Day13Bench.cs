namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day13Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(2021, 13).ToLines();
	}

	[Benchmark]
	public int Part1() => new Day13(_input).Part1();

	[Benchmark]
	public string Part2() => new Day13(_input).Part2();
}
