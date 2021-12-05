namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day5Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day5).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2021.Inputs.Day5.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd().ToLines();
	}

	[Benchmark]
	public int Part1() => new Day5(_input).Part1();

	[Benchmark]
	public int Part2() => new Day5(_input).Part2();
}
