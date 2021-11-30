namespace AdventOfCode.Year2020;

[MemoryDiagnoser]
public class Day11Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day11).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day11.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day11(_input).Part1();

	[Benchmark]
	public int Part2() => new Day11(_input).Part2();
}
