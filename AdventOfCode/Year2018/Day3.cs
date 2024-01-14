namespace AdventOfCode.Year2018;

public class Day3(string[] input)
{
	public int Part1()
	{
		var claims = Parse();
		var fabric = new Dictionary<(int, int), int>();

		foreach (var claim in claims)
		{
			for (int x = 0; x < claim.Width; x++)
			{
				for (int y = 0; y < claim.Height; y++)
				{
					var pos = (claim.Left + x, claim.Top + y);

					if (fabric.TryGetValue(pos, out int val))
					{
						fabric[pos] = val + 1;
					}
					else
					{
						fabric.Add(pos, 1);
					}
				}
			}
		}

		return fabric.Values.Count(v => v > 1);
	}

	public int Part2()
	{
		var claims = Parse();
		var fabric = new Dictionary<(int, int), List<int>>();

		foreach (var claim in claims)
		{
			for (int x = 0; x < claim.Width; x++)
			{
				for (int y = 0; y < claim.Height; y++)
				{
					var pos = (claim.Left + x, claim.Top + y);

					if (fabric.TryGetValue(pos, out var ids))
					{
						ids.Add(claim.Id);
					}
					else
					{
						fabric.Add(pos, [claim.Id]);
					}
				}
			}
		}

		return claims
			.Select(c => c.Id)
			.Except(fabric.Values.Where(v => v.Count > 1).SelectMany(v => v))
			.Single();
	}

	private readonly record struct Claim(int Id, int Left, int Top, int Width, int Height);

	private Claim[] Parse() => input
		.Select(line => line.Split(" #@,:x".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToInt32())
		.Select(line => new Claim(line[0], line[1], line[2], line[3], line[4]))
		.ToArray();
}
