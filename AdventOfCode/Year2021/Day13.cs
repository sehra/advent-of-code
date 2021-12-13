using System.Text;

namespace AdventOfCode.Year2021;

public class Day13
{
	private readonly string[] _input;

	public Day13(string[] input)
	{
		_input = input;
	}

	public int Part1()
	{
		var (paper, folds) = Parse();
		paper = Fold(paper, folds.First());

		return paper.Count;
	}

	public string Part2()
	{
		var (paper, folds) = Parse();

		foreach (var fold in folds)
		{
			paper = Fold(paper, fold);
		}

		var image = new StringBuilder();
		var xmax = paper.Max(p => p.X);
		var ymax = paper.Max(p => p.Y);

		for (int y = 0; y <= ymax; y++)
		{
			for (int x = 0; x <= xmax; x++)
			{
				image.Append(paper.Contains(new(x, y)) ? '#' : '.');
			}

			image.AppendLine();
		}

		return image.ToString();
	}

	private static HashSet<(int X, int Y)> Fold(HashSet<(int X, int Y)> paper, (int? X, int? Y) fold)
	{
		var result = new HashSet<(int X, int Y)>();

		if (fold.Y is int fy)
		{
			foreach (var p in paper)
			{
				if (p.Y < fy)
				{
					result.Add(p);
				}
				else
				{
					result.Add(p with { Y = fy * 2 - p.Y });
				}
			}
		}
		else if (fold.X is int fx)
		{
			foreach (var p in paper)
			{
				if (p.X < fx)
				{
					result.Add(p);
				}
				else
				{
					result.Add(p with { X = fx * 2 - p.X });
				}
			}
		}

		return result;
	}

	private (HashSet<(int X, int Y)> Paper, List<(int? X, int? Y)> Folds) Parse()
	{
		var paper = new HashSet<(int X, int Y)>();
		var folds = new List<(int?, int?)>();

		foreach (var line in _input)
		{
			if (!line.StartsWith("fold"))
			{
				var split = line.Split(',');
				var x = split[0].ToInt32();
				var y = split[1].ToInt32();
				paper.Add(new(x, y));
			}
			else
			{
				var split = line.Split('=');
				var v = split[1].ToInt32();

				if (split[0][^1] is 'x')
				{
					folds.Add((v, null));
				}
				else
				{
					folds.Add((null, v));
				}
			}
		}

		return (paper, folds);
	}
}
