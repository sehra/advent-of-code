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
			new Option<int>(new[] { "-y", "--year" }, () => DateTime.Now.Year, "Year to run"),
			new Option<int>(new[] { "-d", "--day" }, () => DateTime.Now.Day, "Day to run"),
			new Option<FileInfo>(new[] { "-f", "--file" }, "Input file").ExistingOnly(),
			new Option<bool>(new[] { "--stdin" }, "Read input from standard input"),
		};
		command.Handler = CommandHandler.Create(Handler);

		return command.Invoke(args);
	}

	private static void Handler(InvocationContext context, int year, int day, int part, bool stdin, FileInfo file)
	{
		var console = context.Console;
		console.Out.WriteLine($"Advent of Code: Year {year}, Day {day}");

		var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
		object[] args;

		if (stdin)
		{
			args = new[] { Console.In.ReadToEnd().Trim() };
		}
		else
		{
			args = file is not null
				? new[] { File.ReadAllText(file.FullName).Trim() }
				: new[] { GetEmbeddedInput(year, day) };
		}

		RunPart(console, type, args, 1);
		RunPart(console, type, args, 2);
	}

	private static void RunPart(IConsole console, Type type, object[] args, int part)
	{
		console.Out.WriteLine($"-- Part {part} --");

		if (type.GetConstructor(new[] { typeof(string[]) }) is not null)
		{
			args = new[] { (args[0] as string).ToLines() };
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

	public static string GetEmbeddedInput(int year, int day)
	{
		using var stream = Assembly.GetExecutingAssembly()
			.GetManifestResourceStream($"AdventOfCode.Year{year}.Inputs.Day{day}.txt");
		using var reader = new StreamReader(stream);

		return reader.ReadToEnd().Trim();
	}
}
