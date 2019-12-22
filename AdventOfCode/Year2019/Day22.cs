using System;
using System.Linq;

namespace AdventOfCode.Year2019
{
	public class Day22
	{
		private readonly string[] _input;

		public Day22(string input)
		{
			_input = input.Split('\n').Select(line => line.Trim()).ToArray();
		}

		public int Part1(int count = 10007, int search = 2019)
		{
			var deck = Enumerable.Range(0, count).ToArray();

			foreach (var line in _input)
			{
				if (line == "deal into new stack")
				{
					Array.Reverse(deck);
				}
				else if (line.StartsWith("cut"))
				{
					var work = new int[deck.Length];
					var n = Int32.Parse(line[4..]);

					if (n < 0)
					{
						n = deck.Length + n;
					}

					deck.AsSpan(0, n).CopyTo(work.AsSpan(^n));
					deck.AsSpan(n).CopyTo(work);
					deck = work;
				}
				else if (line.StartsWith("deal with increment"))
				{
					var work = new int[deck.Length];
					var n = Int32.Parse(line[20..]);

					for (int i = 0; i < deck.Length; i++)
					{
						work[i * n % work.Length] = deck[i];
					}

					deck = work;
				}
			}

			return Array.IndexOf(deck, search);
		}

		public int Part2()
		{
			throw new NotImplementedException();
		}
	}
}
