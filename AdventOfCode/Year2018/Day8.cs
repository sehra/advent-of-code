namespace AdventOfCode.Year2018;

public class Day8(string input)
{
	public int Part1()
	{
		return Value(Parse());

		static int Value(Node node)
		{
			return node.Children.Sum(Value) + node.Metadata.Sum();
		}
	}

	public int Part2()
	{
		return Value(Parse());

		static int Value(Node node)
		{
			if (node.Children.Count is 0)
			{
				return node.Metadata.Sum();
			}
			else
			{
				return node.Metadata
					.Where(i => 0 < i && i <= node.Children.Count)
					.Sum(i => Value(node.Children[i - 1]));
			}
		}
	}

	private class Node
	{
		public List<Node> Children { get; } = [];
		public List<int> Metadata { get; } = [];
	}

	private Node Parse()
	{
		var data = input.Split().ToInt32();
		var span = data.AsSpan();

		return ParseNode(ref span);

		static Node ParseNode(ref Span<int> span)
		{
			var node = new Node();
			var nodes = span[0];
			var metas = span[1];
			span = span[2..];

			for (int i = 0; i < nodes; i++)
			{
				node.Children.Add(ParseNode(ref span));
			}

			node.Metadata.AddRange(span[..metas]);
			span = span[metas..];

			return node;
		}
	}
}
