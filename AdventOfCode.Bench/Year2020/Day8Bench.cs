﻿using System.IO;
using BenchmarkDotNet.Attributes;

namespace AdventOfCode.Year2020
{
	[MemoryDiagnoser]
	public class Day8Bench
	{
		private string _input;

		[GlobalSetup]
		public void Setup()
		{
			using var stream = typeof(Day8).Assembly
				.GetManifestResourceStream("AdventOfCode.Year2020.Inputs.Day8.txt");
			using var reader = new StreamReader(stream);
			_input = reader.ReadToEnd();
		}

		[Benchmark]
		public int Part1() => new Day8(_input).Part1();

		[Benchmark]
		public int Part2() => new Day8(_input).Part2();
	}
}
