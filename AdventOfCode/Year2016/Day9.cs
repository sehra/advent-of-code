namespace AdventOfCode.Year2016;

public class Day9(string input)
{
	public int Part1()
	{
		var count = 0;

		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] is '(')
			{
				var cross = input.IndexOf('x', i);
				var close = input.IndexOf(')', i);
				var len = input[(i + 1)..cross].ToInt32();
				var num = input[(cross + 1)..close].ToInt32();
				count += len * num;
				i += close - i + len;
			}
			else
			{
				count++;
			}
		}

		return count;
	}

	public long Part2()
	{
		return Count(input);

		static long Count(ReadOnlySpan<char> input)
		{
			var lparen = input.IndexOf('(');

			if (lparen == -1)
			{
				return input.Length;
			}
			else
			{
				var cross = input.IndexOf('x');
				var rparen = input.IndexOf(')');
				var len = input[(lparen + 1)..cross].ToInt32();
				var num = input[(cross + 1)..rparen].ToInt32();

				return lparen +
					num * Count(input.Slice(rparen + 1, len)) +
					Count(input.Slice(rparen + len + 1));
			}
		}
	}
}
