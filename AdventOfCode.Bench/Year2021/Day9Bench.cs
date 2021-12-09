namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day9Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day9).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2021.Inputs.Day9.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd();
	}

	[Benchmark]
	public int Part1() => new Day9(_input).Part1();

	[Benchmark]
	public int Part2() => new Day9(_input).Part2();
}
