namespace AdventOfCode.Year2015;

public class Day5(string[] input)
{
	public int Part1()
	{
		var count = 0;

		foreach (var line in input)
		{
			var threeVowels = line.Count(c => c is 'a' or 'e' or 'i' or 'o' or 'u') >= 3;
			var twiceInRow = line.Window(2).Any(pair => pair[0] == pair[1]);
			var notForbidden = !new[] { "ab", "cd", "pq", "xy" }.Any(line.Contains);
			var nice = threeVowels && twiceInRow && notForbidden;

			count += nice ? 1 : 0;
		}

		return count;
	}

	public int Part2()
	{
		var count = 0;

		foreach (var line in input)
		{
			var pairOfTwoLetter =
				from i in Enumerable.Range(0, line.Length - 3)
				from j in Enumerable.Range(i + 2, line.Length - i - 3)
				let a = line.Skip(i).Take(2)
				let b = line.Skip(j).Take(2)
				select a.Zip(b).All(c => c.First == c.Second);
			var oneLetterRepeat =
				from i in Enumerable.Range(0, line.Length - 2)
				let a = line.Skip(i).First()
				let b = line.Skip(i + 2).First()
				select a == b;

			var nice = pairOfTwoLetter.Any(x => x is true) && oneLetterRepeat.Any(x => x is true);

			count += nice ? 1 : 0;
		}

		return count;
	}
}
