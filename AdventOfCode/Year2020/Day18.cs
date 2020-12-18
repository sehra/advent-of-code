using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020
{
	public class Day18
	{
		private readonly string[] _input;

		public Day18(string input)
		{
			_input = input.ToLines();
		}

		public long Part1()
		{
			return _input.Sum(expr => Evaluate(expr, false));
		}

		public long Part2()
		{
			return _input.Sum(expr => Evaluate(expr, true));
		}

		private static long Evaluate(string expression, bool precedence)
		{
			// https://en.wikipedia.org/wiki/Shunting-yard_algorithm

			var operators = new Stack<char>();
			var outputs = new Stack<long>();

			foreach (var token in expression)
			{
				if (Char.IsDigit(token))
				{
					outputs.Push(token - '0');
				}
				else if (token is '+' or '*')
				{
					while (operators.Count > 0 && operators.Peek() is not '(' &&
						(!precedence || (token is '*' && operators.Peek() is '+')))
					{
						OperatorOnce();
					}

					operators.Push(token);
				}
				else if (token is '(')
				{
					operators.Push(token);
				}
				else if (token is ')')
				{
					while (operators.Count > 0 && operators.Peek() is not '(')
					{
						OperatorOnce();
					}

					if (operators.Peek() is '(')
					{
						operators.Pop();
					}
				}
			}

			while (operators.Count > 0)
			{
				OperatorOnce();
			}

			return outputs.Pop();

			void OperatorOnce()
			{
				var lhs = outputs.Pop();
				var rhs = outputs.Pop();

				outputs.Push(operators.Pop() switch
				{
					'+' => lhs + rhs,
					'*' => lhs * rhs,
					_ => throw new Exception("operator?"),
				});
			}
		}
	}
}
