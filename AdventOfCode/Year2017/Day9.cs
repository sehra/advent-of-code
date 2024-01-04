namespace AdventOfCode.Year2017;

public class Day9(string input)
{
	public int Part1()
	{
		var trash = false;
		var level = 0;
		var score = 0;

		for (int i = 0; i < input.Length; i++)
		{
			var c = input[i];

			if (trash)
			{
				if (c is '>')
				{
					trash = false;
				}
				else if (c is '!')
				{
					i++;
				}
			}
			else
			{
				if (c is '<')
				{
					trash = true;
				}
				else if (c is '{')
				{
					level++;
				}
				else if (c is '}')
				{
					score += level;
					level--;
				}
			}
		}

		return score;
	}

	public int Part2()
	{
		var trash = false;
		var count = 0;

		for (int i = 0; i < input.Length; i++)
		{
			var c = input[i];

			if (trash)
			{
				if (c is '>')
				{
					trash = false;
				}
				else if (c is '!')
				{
					i++;
				}
				else
				{
					count++;
				}
			}
			else if (c is '<')
			{
				trash = true;
			}
		}

		return count;
	}
}
