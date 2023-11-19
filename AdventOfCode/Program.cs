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
		object[] args;

		if (stdin)
		{
			args = [MaybeTrim(Console.In.ReadToEnd(), trim)];
		}
		else
		{
			args = file is not null
				? [MaybeTrim(File.ReadAllText(file.FullName), trim)]
				: [GetEmbeddedInput(year, day, trim)];
		}

		RunPart(console, type, args, 1);
		RunPart(console, type, args, 2);
	}

	private static void RunPart(IConsole console, Type type, object[] args, int part)
	{
		console.Out.WriteLine($"-- Part {part} --");

		if (type.GetConstructor([typeof(string[])]) is not null)
		{
			args = [(args[0] as string).ToLines()];
		}

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

		console.Out.WriteLine(stopwatch.Elapsed.ToString());
		console.Out.WriteLine(result.ToString());
	}

	public static string GetEmbeddedInput(int year, int day, bool trim = true)
	{
		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream($"AdventOfCode.Year{year}.Inputs.Day{day}.txt");
		using var reader = new StreamReader(stream);

		return MaybeTrim(reader.ReadToEnd(), trim);
	}

	private static string MaybeTrim(string value, bool trim) => trim ? value.Trim() : value;
}

[AttributeUsage(AttributeTargets.Class)]
public class SkipInputTrimAttribute : Attribute
{
}
