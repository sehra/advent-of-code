namespace AdventOfCode.Year2021;

[MemoryDiagnoser]
public class Day13Bench
{
	private string[] _input;

	[GlobalSetup]
	public void Setup()
	{
		using var stream = typeof(Day13).Assembly
			.GetManifestResourceStream("AdventOfCode.Year2021.Inputs.Day13.txt");
		using var reader = new StreamReader(stream);
		_input = reader.ReadToEnd().ToLines();
	}

	[Benchmark]
	public int Part1() => new Day13(_input).Part1();

	[Benchmark]
	public string Part2() => new Day13(_input).Part2();
}
