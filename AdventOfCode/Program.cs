using System;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length < 3)
			{
				Console.WriteLine("AdventOfCode [Year] [Day] [Part] (Input)");
				return;
			}

			var year = Int32.Parse(args[0], CultureInfo.InvariantCulture);
			var day = Int32.Parse(args[1], CultureInfo.InvariantCulture);
			var part = Int32.Parse(args[2], CultureInfo.InvariantCulture);
			var init = args.Length == 4
				? new object[] { File.ReadAllText(args[3]) }
				: new object[] { GetEmbeddedInput(year, day) };

			var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
			var instance = Activator.CreateInstance(type, init);
			var result = type.GetMethod($"Part{part}").Invoke(instance, Type.EmptyTypes);

			Console.WriteLine("Result: {0}", result);
		}

		private static string GetEmbeddedInput(int year, int day)
		{
			using var stream = Assembly.GetExecutingAssembly()
				.GetManifestResourceStream($"AdventOfCode.Year{year}.Inputs.Day{day}.txt");
			using var reader = new StreamReader(stream);

			return reader.ReadToEnd();
		}
	}
}
