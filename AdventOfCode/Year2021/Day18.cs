using System.Text.Json;

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
		return Number.Sum(Parse()).Magnitude;
	}

	public int Part2()
	{
		var largest = 0;

		for (int i = 0; i < _input.Length; i++)
		{
			for (int j = 0; j < _input.Length; j++)
			{
				if (i == j)
				{
					continue;
				}

				var l = Number.Parse(_input[i]);
				var r = Number.Parse(_input[j]);

				largest = Math.Max(largest, l.Add(r).Magnitude);
			}
		}

		return largest;
	}

	private Number[] Parse() => Number.Parse(_input);

	public abstract class Number
	{
		public Number(ArrNumber parent)
		{
			Parent = parent;
		}

		public int Depth
		{
			get
			{
				var parent = Parent;
				var depth = 0;

				while (parent is not null)
				{
					depth++;
					parent = parent.Parent;
				}

				return depth;
			}
		}

		public abstract int Magnitude { get; }
		public ArrNumber Parent { get; set; }

		public Number Add(Number other)
		{
			var number = new ArrNumber(null, this, other);
			Parent = number;
			other.Parent = number;

			return number.Reduce();
		}

		public static Number Sum(IEnumerable<Number> numbers) =>
			numbers.Aggregate((l, r) => l.Add(r));

		public Number Reduce()
		{
			while (true)
			{
				if (Explode() || Split())
				{
					continue;
				}

				return this;
			}
		}

		public bool Explode()
		{
			if (this is not ArrNumber number)
			{
				return false;
			}

			if (number is { Depth: >= 4, Left: LitNumber left, Right: LitNumber right })
			{
				MoveUpLeft(number, left.Value);
				MoveUpRight(number, right.Value);

				var zero = new LitNumber(number.Parent, 0);

				if (number.Parent.Left == number)
				{
					number.Parent.Left = zero;
				}
				else
				{
					number.Parent.Right = zero;
				}

				return true;
			}
			else
			{
				return number.Left.Explode() || number.Right.Explode();
			}

			static void MoveUpLeft(ArrNumber number, int value)
			{
				var parent = number.Parent;

				if (parent is null)
				{
					return;
				}

				if (parent.Right == number)
				{
					if (parent.Left is LitNumber left)
					{
						left.Value += value;
					}
					else
					{
						MoveDownLeft(parent.Left as ArrNumber, value);
					}
				}
				else
				{
					MoveUpLeft(parent, value);
				}
			}

			static void MoveDownLeft(ArrNumber number, int value)
			{
				if (number.Right is LitNumber right)
				{
					right.Value += value;
				}
				else
				{
					MoveDownLeft(number.Right as ArrNumber, value);
				}
			}

			static void MoveUpRight(ArrNumber number, int value)
			{
				var parent = number.Parent;

				if (parent is null)
				{
					return;
				}

				if (parent.Left == number)
				{
					if (parent.Right is LitNumber right)
					{
						right.Value += value;
					}
					else
					{
						MoveDownRight(parent.Right as ArrNumber, value);
					}
				}
				else
				{
					MoveUpRight(parent, value);
				}
			}

			static void MoveDownRight(ArrNumber number, int value)
			{
				if (number.Left is LitNumber left)
				{
					left.Value += value;
				}
				else
				{
					MoveDownRight(number.Left as ArrNumber, value);
				}
			}
		}

		public bool Split()
		{
			if (this is not ArrNumber number)
			{
				return false;
			}

			if (number.Left is LitNumber { Value: > 9 } left)
			{
				return Split(number, left);
			}

			if (number.Left.Split())
			{
				return true;
			}

			if (number.Right is LitNumber { Value: > 9 } right)
			{
				return Split(number, right);
			}

			return number.Right.Split();

			static bool Split(ArrNumber parent, LitNumber number)
			{
				var (quotient, remainder) = Math.DivRem(number.Value, 2);
				var inserted = new ArrNumber(parent);
				inserted.Left = new LitNumber(inserted, quotient);
				inserted.Right = new LitNumber(inserted, quotient + remainder);

				if (parent.Left == number)
				{
					parent.Left = inserted;
				}
				else
				{
					parent.Right = inserted;
				}

				return true;
			}
		}

		public static Number Parse(string line) =>
			Parse(null, JsonSerializer.Deserialize<JsonElement>(line));

		public static Number[] Parse(string[] lines) =>
			lines.Select(Parse).ToArray();

		private static Number Parse(ArrNumber parent, JsonElement element)
		{
			if (element.ValueKind is JsonValueKind.Number)
			{
				return new LitNumber(parent, element.GetInt32());
			}
			else if (element.ValueKind is JsonValueKind.Array)
			{
				var children = element.EnumerateArray().ToArray();
				var number = new ArrNumber(parent);
				number.Left = Parse(number, children[0]);
				number.Right = Parse(number, children[1]);

				return number;
			}

			throw new Exception("kind?");
		}
	}

	public class LitNumber : Number
	{
		public LitNumber(ArrNumber parent, int value)
			: base(parent)
		{
			Value = value;
		}

		public override int Magnitude => Value;
		public int Value { get; set; }

		public override string ToString() => Value.ToString();
	}

	public class ArrNumber : Number
	{
		public ArrNumber(ArrNumber parent, Number left = null, Number right = null)
			: base(parent)
		{
			Left = left;
			Right = right;
		}

		public override int Magnitude => 3 * Left.Magnitude + 2 * Right.Magnitude;
		public Number Left { get; set; }
		public Number Right { get; set; }

		public override string ToString() => $"[{Left},{Right}]";
	}
}
