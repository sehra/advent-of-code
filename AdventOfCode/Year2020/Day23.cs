using System.Text;

namespace AdventOfCode.Year2020;

public class Day23
{
	private readonly int[] _input;

	public Day23(string input)
	{
		_input = input.Trim().Select(c => c - '0').ToArray();
	}

	public string Part1(int moves = 100)
	{
		var cups = RunGame(_input, moves);
		var first = cups.GetNode(1);
		var node = first.Next;
		var result = new StringBuilder();

		while (node != first)
		{
			result.Append(node.Value);
			node = node.Next;
		}

		return result.ToString();
	}

	public long Part2()
	{
		var rest = Enumerable.Range(_input.Length + 1, 1_000_000 - _input.Length);
		var cups = RunGame(_input.Concat(rest), 10_000_000);
		var first = cups.GetNode(1);

		return (long)first.Next.Value * first.Next.Next.Value;
	}

	private static CircularHashedLinkedList RunGame(IEnumerable<int> items, int moves)
	{
		var cups = new CircularHashedLinkedList(items);
		var pick = cups.GetNode(items.First());

		for (int i = 0; i < moves; i++)
		{
			var value = pick.Value;
			var next1 = pick.Next.Value;
			var next2 = pick.Next.Next.Value;
			var next3 = pick.Next.Next.Next.Value;

			do
			{
				if (--value is 0)
				{
					value = cups.Count;
				}
			} while (next1 == value || next2 == value || next3 == value);

			cups.Move(next3, value);
			cups.Move(next2, value);
			cups.Move(next1, value);

			pick = pick.Next;
		}

		return cups;
	}

	private class CircularHashedLinkedList
	{
		private readonly Dictionary<int, Node> _nodes = new();

		public CircularHashedLinkedList(IEnumerable<int> values)
		{
			Node head = null;
			Node prev = null;

			foreach (var value in values)
			{
				var node = new Node { Value = value };

				if (head is null)
				{
					head = node;
				}

				if (prev is not null)
				{
					prev.Next = node;
					node.Prev = prev;
				}

				_nodes[value] = prev = node;
			}

			head.Prev = prev;
			prev.Next = head;
		}

		public int Count => _nodes.Count;

		public Node GetNode(int value) => _nodes[value];

		public void Move(int source, int target)
		{
			var sourceNode = _nodes[source];
			var targetNode = _nodes[target];
			var targetNext = targetNode.Next;
			sourceNode.Prev.Next = sourceNode.Next;
			sourceNode.Next.Prev = sourceNode.Prev;
			targetNode.Next.Prev = sourceNode;
			targetNode.Next = sourceNode;
			sourceNode.Prev = targetNode;
			sourceNode.Next = targetNext;
		}

		public class Node
		{
			public Node Prev { get; set; }
			public Node Next { get; set; }
			public int Value { get; set; }
		}
	}
}
