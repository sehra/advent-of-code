using System.Text;

namespace AdventOfCode.Year2015;

public class Day10(string input)
{
	public int Part1(int n = 40) => Solve(n);

	public int Part2() => Solve(50);

	private int Solve(int n)
	{
		var curr = Parse(input);

		for (int i = 0; i < n; i++)
		{
			var temp = new StringBuilder();

			foreach (var (digit, count) in curr)
			{
				temp.Append(count);
				temp.Append(digit);
			}

			curr = Parse(temp.ToString());
		}

		return curr.Sum(group => group.Count - '0');
	}

	private static List<(char Digit, char Count)> Parse(string number)
	{
		var num = new List<(char, char)>();

		for (int i = 0; i < number.Length; )
		{
			var c = number[i];
			var n = '0';

			while (i < number.Length && number[i] == c)
			{
				n++;
				i++;
			}

			num.Add((c, n));
		}

		return num;
	}
}
