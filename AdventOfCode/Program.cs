using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
				? new[] { File.ReadAllText(args[3]) }
				: new[] { GetEmbeddedInput(year, day) };

			var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
			var instance = Activator.CreateInstance(type, init);
			var method = type.GetMethod($"Part{part}");
			var parameters = method.GetParameters().Select(p => p.RawDefaultValue);
			var stopwatch = Stopwatch.StartNew();
			var result = method.Invoke(instance, parameters.ToArray());

			if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
			{
				result = result.GetType().GetMethod("GetAwaiter").Invoke(result, Type.EmptyTypes);
				result = result.GetType().GetMethod("GetResult").Invoke(result, Type.EmptyTypes);
			}

			Console.WriteLine(stopwatch.Elapsed);
			Console.WriteLine(result);
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
