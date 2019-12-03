using System;
using System.Globalization;
using System.IO;

namespace AdventOfCode
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			if (args.Length < 4)
			{
				Console.WriteLine("AdventOfCode [Year] [Day] [Part] [Input]");
				return;
			}

			var year = Int32.Parse(args[0], CultureInfo.InvariantCulture);
			var day = Int32.Parse(args[1], CultureInfo.InvariantCulture);
			var part = Int32.Parse(args[2], CultureInfo.InvariantCulture);
			var init = new object[] { File.ReadAllText(args[3]) };

			var instance = Activator.CreateInstance(Type.GetType($"AdventOfCode.Year{year}.Day{day}"), init);
			var result = instance.GetType().GetMethod($"Part{part}").Invoke(instance, Type.EmptyTypes);

			Console.WriteLine("Result: {0}", result);
		}
	}
}
