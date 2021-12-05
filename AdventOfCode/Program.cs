using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode;

public static class Program
{
	public static int Main(string[] args)
	{
		var command = new RootCommand()
		{
			new Option<int>(new[] { "-y", "--year" }, () => DateTime.Now.Year),
			new Option<int>(new[] { "-d", "--day" }, () => DateTime.Now.Day),
			new Option<FileInfo>(new[] { "-i", "--input" }).ExistingOnly(),
		};
		command.Handler = CommandHandler.Create(Handler);

		return command.Invoke(args);
	}

	private static void Handler(InvocationContext context, int year, int day, int part, FileInfo file)
	{
		var console = context.Console;
		console.Out.WriteLine($"Advent of Code: Year {year}, Day {day}");

		var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
		var args = file is not null
			? new[] { File.ReadAllText(file.FullName) }
			: new[] { GetEmbeddedInput(year, day) };

		console.Out.WriteLine("Part 1");
		var part1 = RunPart(type, args, 1);
		console.Out.WriteLine(part1.Elapsed.ToString());
		console.Out.WriteLine(part1.Result);

		console.Out.WriteLine("Part 2");
		var part2 = RunPart(type, args, 2);
		console.Out.WriteLine(part2.Elapsed.ToString());
		console.Out.WriteLine(part2.Result);
	}

	private static (TimeSpan Elapsed, string Result) RunPart(Type type, object[] args, int part)
	{
		var instance = Activator.CreateInstance(type, args);
		var method = type.GetMethod($"Part{part}");
		var parameters = method.GetParameters().Select(p => p.RawDefaultValue).ToArray();
		var stopwatch = Stopwatch.StartNew();
		var result = method.Invoke(instance, parameters);

		if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
		{
			result = result.GetType().GetMethod("GetAwaiter").Invoke(result, Type.EmptyTypes);
			result = result.GetType().GetMethod("GetResult").Invoke(result, Type.EmptyTypes);
		}

		return (stopwatch.Elapsed, result.ToString());
	}

	private static string GetEmbeddedInput(int year, int day)
	{
		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream($"AdventOfCode.Year{year}.Inputs.Day{day}.txt");
		using var reader = new StreamReader(stream);

		return reader.ReadToEnd();
	}
}
