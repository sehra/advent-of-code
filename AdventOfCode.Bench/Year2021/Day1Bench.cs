namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day1Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day1).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2021.Inputs.Day1.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day1(_input).Part1();

	[Benchmark]
	public int Part2() => new Day1(_input).Part2();
}
