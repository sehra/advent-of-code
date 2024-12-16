namespace AdventOfCode.Year2016;

public class Day21(string[] input)
{
	public string Part1(string password = "abcdefgh")
	{
		var scrambled = password.ToCharArray();

		foreach (var line in input)
		{
			var split = line.Split();

			if (line.StartsWith("swap position"))
			{
				SwapPosition(scrambled, split[2].ToInt32(), split[5].ToInt32());
			}
			else if (line.StartsWith("swap letter"))
			{
				SwapLetter(scrambled, split[2][0], split[5][0]);
			}
			else if (line.StartsWith("rotate left"))
			{
				RotateLeft(scrambled, split[2].ToInt32());
			}
			else if (line.StartsWith("rotate right"))
			{
				RotateRight(scrambled, split[2].ToInt32());
			}
			else if (line.StartsWith("rotate based"))
			{
				RotateBased(scrambled, split[6][0]);
			}
			else if (line.StartsWith("reverse"))
			{
				ReversePositions(scrambled, split[2].ToInt32(), split[4].ToInt32());
			}
			else if (line.StartsWith("move"))
			{
				MovePosition(scrambled, split[2].ToInt32(), split[5].ToInt32());
			}
		}

		return new(scrambled);
	}

	public string Part2()
	{
		var password = "fbgdceah".ToCharArray();

		foreach (var line in input.Reverse())
		{
			var split = line.Split();

			if (line.StartsWith("swap position"))
			{
				SwapPosition(password, split[2].ToInt32(), split[5].ToInt32());
			}
			else if (line.StartsWith("swap letter"))
			{
				SwapLetter(password, split[2][0], split[5][0]);
			}
			else if (line.StartsWith("rotate left"))
			{
				RotateRight(password, split[2].ToInt32());
			}
			else if (line.StartsWith("rotate right"))
			{
				RotateLeft(password, split[2].ToInt32());
			}
			else if (line.StartsWith("rotate based"))
			{
				RotateBasedInverse(password, split[6][0]);
			}
			else if (line.StartsWith("reverse"))
			{
				ReversePositions(password, split[2].ToInt32(), split[4].ToInt32());
			}
			else if (line.StartsWith("move"))
			{
				MovePosition(password, split[5].ToInt32(), split[2].ToInt32());
			}
		}

		return new(password);
	}

	private static void SwapPosition(char[] word, int x, int y)
	{
		(word[x], word[y]) = (word[y], word[x]);
	}

	private static void SwapLetter(char[] word, char x, char y)
	{
		SwapPosition(word, Array.IndexOf(word, x), Array.IndexOf(word, y));
	}

	private static void RotateLeft(char[] word, int x)
	{
		Span<char> temp = stackalloc char[word.Length];

		for (int i = 0; i < word.Length; i++)
		{
			temp[i] = word[(i + x) % word.Length];
		}

		temp.CopyTo(word);
	}

	private static void RotateRight(char[] word, int x)
	{
		Span<char> temp = stackalloc char[word.Length];

		for (int i = 0; i < word.Length; i++)
		{
			temp[(i + x) % word.Length] = word[i];
		}

		temp.CopyTo(word);
	}

	private static void RotateBased(char[] word, char c)
	{
		var x = Array.IndexOf(word, c);
		RotateRight(word, x >= 4 ? x + 2 : x + 1);
	}

	private static void RotateBasedInverse(char[] word, char c)
	{
		ReadOnlySpan<int> inverse = [1, 1, 6, 2, 7, 3, 0, 4];
		RotateLeft(word, inverse[Array.IndexOf(word, c)]);
	}

	private static void ReversePositions(char[] word, int x, int y)
	{
		word.AsSpan(x, y - x + 1).Reverse();
	}

	private static void MovePosition(char[] word, int x, int y)
	{
		if (x == y)
		{
			return;
		}

		var c = word[x];

		if (x < y)
		{
			for (int i = x; i < y; i++)
			{
				word[i] = word[i + 1];
			}
		}
		else
		{
			for (int i = x; i > y; i--)
			{
				word[i] = word[i - 1];
			}
		}

		word[y] = c;
	}
}
