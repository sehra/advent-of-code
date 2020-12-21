using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day21Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day21).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day21.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public int Part1() => new Day21(_input).Part1();

		[Benchmark]
		public string Part2() => new Day21(_input).Part2();
	}
}
