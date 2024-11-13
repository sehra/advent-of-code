using System.Text.Json.Nodes;

namespace AdventOfCode.Year2022;

public class Day13
{
	private readonly string[] _input;

	public Day13(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		return _input
			.Select(x => JsonNode.Parse(x))
			.Buffer(2)
			.Index(1)
			.Where(x => Compare(x.Item[0], x.Item[1]) < 0)
			.Sum(x => x.Index);
	}

	public int Part2()
	{
		var key1 = JsonNode.Parse("[[2]]");
		var key2 = JsonNode.Parse("[[6]]");

		var packets = _input.Select(x => JsonNode.Parse(x)).ToList();
		packets.Add(key1);
		packets.Add(key2);
		packets.Sort(Compare);

		return (packets.IndexOf(key1) + 1) * (packets.IndexOf(key2) + 1);
	}

	private static int Compare(JsonNode left, JsonNode right) => (left, right) switch
	{
		(JsonArray larr, JsonArray rarr) => Compare(larr, rarr),
		(JsonArray larr, JsonValue rval) => Compare(larr, new JsonArray((int)rval)),
		(JsonValue lval, JsonArray rarr) => Compare(new JsonArray((int)lval), rarr),
		(JsonValue lval, JsonValue rval) => (int)lval - (int)rval,
		_ => throw new NotSupportedException(),
	};

	private static int Compare(JsonArray left, JsonArray right)
	{
		for (int i = 0; i < left.Count; i++)
		{
			if (i == right.Count)
			{
				return 1;
			}

			var c = Compare(left[i], right[i]);

			if (c is not 0)
			{
				return c;
			}
		}

		return left.Count == right.Count ? 0 : -1;
	}
}
