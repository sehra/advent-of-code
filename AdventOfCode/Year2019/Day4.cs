namespace AdventOfCode.Year2019;

public class Day4
{
	private readonly int[] _input;

	public Day4(string input)
	{
		_input = input.Split('-').Select(Int32.Parse).ToArray();
	}

	public int Part1()
	{
		return Enumerable.Range(_input[0], _input[1] - _input[0] + 1)
			.Select(x => x.ToString())
			.Count(IsValid1);
	}

	public int Part2()
	{
		return Enumerable.Range(_input[0], _input[1] - _input[0] + 1)
			.Select(x => x.ToString())
			.Count(IsValid2);
	}

	public static bool IsValid1(string password) =>
		IsSorted(password) && password.GroupBy(c => c).Any(g => g.Count() >= 2);

	public static bool IsValid2(string password) =>
		IsSorted(password) && password.GroupBy(c => c).Any(g => g.Count() == 2);

	private static bool IsSorted(string password)
	{
		for (int i = 1; i < password.Length; i++)
		{
			if (password[i - 1] > password[i])
			{
				return false;
			}
		}

		return true;
	}
}
