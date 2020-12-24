using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day24Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day24).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day24.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public int Part1() => new Day24(_input).Part1();

		[Benchmark]
		public int Part2() => new Day24(_input).Part2();
	}
}
