using System.CommandLine;
using System.CommandLine.Invocation;
using System.CommandLine.IO;
using System.CommandLine.NamingConventionBinder;
using System.Diagnostics;
using System.Reflection;

namespace AdventOfCode;

public static class Program
{
	public static int Main(string[] args)
	{
		var command = new RootCommand()
		{
			new Option<int>(["-y", "--year"], () => DateTime.Now.Year, "Year to run"),
			new Option<int>(["-d", "--day"], () => DateTime.Now.Day, "Day to run"),
			new Option<FileInfo>(["-f", "--file"], "Input file").ExistingOnly(),
			new Option<bool>(["--stdin"], "Read input from standard input"),
		};
		command.Handler = CommandHandler.Create(Handler);

		return command.Invoke(args);
	}

	private static void Handler(InvocationContext context, int year, int day, bool stdin, FileInfo file)
	{
		var console = context.Console;
		console.Out.WriteLine($"Advent of Code: Year {year}, Day {day}");

		var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
		var trim = type.GetCustomAttribute<SkipInputTrimAttribute>() is null;
		var input = stdin
			? MaybeTrim(Console.In.ReadToEnd(), trim)
			: file is not null
				? MaybeTrim(File.ReadAllText(file.FullName), trim)
				: GetEmbeddedInput(year, day, trim);

		if (input is null)
		{
			console.Out.WriteLine("Missing puzzle input.");
		}
		else
		{
			RunPart(console, type, input, 1);
			RunPart(console, type, input, 2);
		}
	}

	private static void RunPart(IConsole console, Type type, string input, int part)
	{
		console.Out.WriteLine($"-- Part {part} --");
		object[] args = [input];

		if (type.GetConstructor([typeof(string[])]) is not null)
		{
			args = [input.ToLines()];
		}
		else if (type.GetConstructor([typeof(int[])]) is not null)
		{
			args = [input.ToLines().ToInt32()];
		}
		else if (type.GetConstructor([typeof(long[])]) is not null)
		{
			args = [input.ToLines().ToInt64()];
		}

		var instance = Activator.CreateInstance(type, args);
		var method = type.GetMethod($"Part{part}");
		var parameters = method.GetParameters().Select(p => p.RawDefaultValue).ToArray();
		var stopwatch = Stopwatch.StartNew();
		var result = method.Invoke(instance, parameters);

		if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
		{
			result = result.GetType().GetMethod("GetAwaiter").Invoke(result, []);
			result = result.GetType().GetMethod("GetResult").Invoke(result, []);
		}

		console.Out.WriteLine(stopwatch.Elapsed.ToString());
		console.Out.WriteLine(result.ToString());
	}

	public static string GetEmbeddedInput(int year, int day, bool trim = true)
	{
		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream($"AdventOfCode.Year{year}.Inputs.Day{day}.txt");

		if (stream is null)
		{
			return null;
		}

		using var reader = new StreamReader(stream);

		return MaybeTrim(reader.ReadToEnd(), trim);
	}

	private static string MaybeTrim(string value, bool trim) => trim ? value.Trim() : value;
}

[AttributeUsage(AttributeTargets.Class)]
public class SkipInputTrimAttribute : Attribute
{
}
