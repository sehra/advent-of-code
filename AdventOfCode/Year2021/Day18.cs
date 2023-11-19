namespace AdventOfCode.Year2021;

public class Day18
{
	private readonly string[] _input;

	public Day18(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		return Sum(Parse()).Magnitude();
	}

	public int Part2()
	{
		var numbers = Parse();
		var largest = 0;

		for (int i = 0; i < numbers.Length; i++)
		{
			for (int j = 0; j < numbers.Length; j++)
			{
				if (i == j)
				{
					continue;
				}

				var magnitude = (numbers[i] + numbers[j]).Magnitude();
				largest = Math.Max(largest, magnitude);
			}
		}

		return largest;
	}

	public static Number Sum(IEnumerable<Number> numbers) =>
		numbers.Aggregate((a, b) => a + b);

	public static Number[] Parse(string[] lines) =>
		lines.Select(Number.Parse).ToArray();

	private Number[] Parse() => Parse(_input);

	public class Number : IEquatable<Number>
	{
		private readonly List<Node> _nodes = [];

		public static Number Parse(string line)
		{
			var number = new Number();
			var depth = 0;

			for (int i = 0; i < line.Length; i++)
			{
				var c = line[i];

				if (c is '[')
				{
					depth++;
				}
				else if (c is ']')
				{
					depth--;
				}
				else if (Char.IsDigit(c))
				{
					var value = 0;

					for (; i < line.Length && Char.IsDigit(line[i]); i++)
					{
						value = value * 10 + line[i] - '0';
					}

					number._nodes.Add(new(depth, value));
					i--;
				}
			}

			return number;
		}

		public int Magnitude()
		{
			var number = new List<Node>(_nodes);

			while (number.Count != 1)
			{
				for (int i = 0; i < number.Count - 1; i++)
				{
					if (number[i].Depth == number[i + 1].Depth)
					{
						var node = number[i];
						var magnitude = 3 * node.Value + 2 * number[i + 1].Value;
						number[i] = new(node.Depth - 1, magnitude);
						number.RemoveAt(i + 1);
						break;
					}
				}
			}

			return number[0].Value;
		}

		public static Number operator +(Number a, Number b)
		{
			var number = new Number();
			number._nodes.AddRange(a._nodes.Select(n => n with { Depth = n.Depth + 1 }));
			number._nodes.AddRange(b._nodes.Select(n => n with { Depth = n.Depth + 1 }));

			return number.Reduce();
		}

		public Number Reduce()
		{
			while (Explode() || Split())
			{
			}

			return this;
		}

		public bool Explode()
		{
			for (int i = 0; i < _nodes.Count - 1; i++)
			{
				if (_nodes[i].Depth > 4 && _nodes[i].Depth == _nodes[i + 1].Depth)
				{
					var first = _nodes[i];
					var second = _nodes[i + 1];

					if (i > 0)
					{
						var node = _nodes[i - 1];
						_nodes[i - 1] = node with { Value = node.Value + first.Value };
					}

					if (i < _nodes.Count - 2)
					{
						var node = _nodes[i + 2];
						_nodes[i + 2] = node with { Value = node.Value + second.Value };
					}

					_nodes[i] = new(first.Depth - 1, 0);
					_nodes.RemoveAt(i + 1);

					return true;
				}
			}

			return false;
		}

		public bool Split()
		{
			for (int i = 0; i < _nodes.Count; i++)
			{
				if (_nodes[i].Value > 9)
				{
					var node = _nodes[i];
					var (quotient, remainder) = Math.DivRem(node.Value, 2);
					_nodes[i] = new(node.Depth + 1, quotient);
					_nodes.Insert(i + 1, new(node.Depth + 1, quotient + remainder));

					return true;
				}
			}

			return false;
		}

		public bool Equals(Number other) => _nodes.SequenceEqual(other._nodes);
		
		public override bool Equals(object obj) => Equals(obj as Number);

		public override int GetHashCode() =>
			_nodes.Aggregate(0, (a, b) => HashCode.Combine(a, b));

		private readonly record struct Node(int Depth, int Value);
	}
}
