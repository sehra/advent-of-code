using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day23Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day23).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day23.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public string Part1() => new Day23(_input).Part1();

		[Benchmark]
		public long Part2() => new Day23(_input).Part2();
	}
}
