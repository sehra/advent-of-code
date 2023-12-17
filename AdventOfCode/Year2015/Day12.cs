using System.Text.Json;

namespace AdventOfCode.Year2015;

public class Day12(string input)
{
	public int Part1() => Solve(false);

	public int Part2() => Solve(true);

	private int Solve(bool reds)
	{
		return Sum(JsonDocument.Parse(input).RootElement, reds);
	}

	private static int Sum(JsonElement elem, bool reds) => elem.ValueKind switch
	{
		JsonValueKind.Array => Sum(elem.EnumerateArray(), reds),
		JsonValueKind.Object => Sum(elem.EnumerateObject(), reds),
		JsonValueKind.Number => elem.GetInt32(),
		_ => 0,
	};

	private static int Sum(JsonElement.ArrayEnumerator arr, bool reds) =>
		arr.Sum(elem => Sum(elem, reds));

	private static int Sum(JsonElement.ObjectEnumerator obj, bool reds)
	{
		if (reds)
		{
			foreach (var prop in obj)
			{
				if (prop.Value.ValueKind == JsonValueKind.String &&
					prop.Value.ValueEquals("red"))
				{
					return 0;
				}
			}
		}

		return obj.Sum(prop => Sum(prop.Value, reds));
	}
}
