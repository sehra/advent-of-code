namespace AdventOfCode.Year2015;

public class Day25(string input)
{
	public int Part1()
	{
		var nums = Regex.Matches(input, @"\d+");
		var row = nums[0].ValueSpan.ToInt32();
		var col = nums[1].ValueSpan.ToInt32();
		var exp = (row + col - 2) * (row + col - 1) / 2 + col - 1;

		return (int)(BigInteger.ModPow(252533, exp, 33554393) * 20151125 % 33554393);
	}

	public string Part2()
	{
		return "get 49 stars";
	}
}
