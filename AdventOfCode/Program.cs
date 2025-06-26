using System.CommandLine;
using System.Reflection;
using TextCopy;

namespace AdventOfCode;

public static class Program
{
	public static int Main(string[] args)
	{
		var command = new RootCommand()
		{
			new Option<int>("--year", "-y") { Description = "Year to run", DefaultValueFactory = _ => DateTime.Now.Year },
			new Option<int>("--day", "-d") { Description = "Day to run", DefaultValueFactory = _ => DateTime.Now.Day },
			new Option<FileInfo>("--file", "-f") { Description = "Input file" }.AcceptExistingOnly(),
			new Option<bool>("--stdin") { Description = "Read input from standard input" },
		};
		command.SetAction(result =>
		{
			Handler(result.Configuration.Output,
				result.GetValue<int>("--year"), result.GetValue<int>("--day"),
				result.GetValue<bool>("--stdin"), result.GetValue<FileInfo>("--file"));

			return 0;
		});

		return command.Parse(args).Invoke();
	}

	private static void Handler(TextWriter console, int year, int day, bool stdin, FileInfo file)
	{
		console.WriteLine($"Advent of Code: Year {year}, Day {day}");

		var type = Type.GetType($"AdventOfCode.Year{year}.Day{day}");
		var trim = !Attribute.IsDefined(type, typeof(SkipInputTrimAttribute));
		var input = stdin
			? MaybeTrim(Console.In.ReadToEnd(), trim)
			: file is not null
				? MaybeTrim(File.ReadAllText(file.FullName), trim)
				: GetEmbeddedInput(year, day, trim);

		if (input is null)
		{
			console.WriteLine("Missing puzzle input.");
		}
		else
		{
			RunPart(console, type, input, 1);
			RunPart(console, type, input, 2);
		}
	}

	private static void RunPart(TextWriter console, Type type, string input, int part)
	{
		console.WriteLine($"-- Part {part} --");
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

		try
		{
			var stopwatch = Stopwatch.StartNew();
			var result = method.Invoke(instance, parameters);

			if (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
			{
				result = result.GetType().GetMethod("GetAwaiter").Invoke(result, []);
				result = result.GetType().GetMethod("GetResult").Invoke(result, []);
			}

			var output = result.ToString();
			ClipboardService.SetText(output);

			console.WriteLine(stopwatch.Elapsed.ToString());
			console.WriteLine(output);
		}
		catch (TargetInvocationException ex) when (ex.InnerException is NotImplementedException)
		{
			console.WriteLine(ex.InnerException.Message);
		}
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
