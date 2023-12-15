namespace AdventOfCode.Year2023;

public class Day15(string input)
{
	public int Part1() => Parse().Sum(Hash);

	public int Part2()
	{
		var boxes = new Dictionary<int, List<(string Label, int Focal)>>();

		foreach (var step in Parse())
		{
			var split = step.Split('=', '-');
			var label = split[0];
			var hash = Hash(label);

			if (!boxes.TryGetValue(hash, out var box))
			{
				box = boxes[hash] = [];
			}

			var pos = box.FindIndex(l => l.Label == label);

			if (step.Contains('='))
			{
				var focal = split[1].ToInt32();

				if (pos is -1)
				{
					box.Add((label, focal));
				}
				else
				{
					box[pos] = (label, focal);
				}
			}
			else if (pos is not -1)
			{
				box.RemoveAt(pos);
			}
		}

		return boxes.Sum(box => box.Value.Sum((lens, pos) => (box.Key + 1) * (pos + 1) * lens.Focal));
	}

	private static int Hash(string data) => data
		.Aggregate(0, (h, c) => (h + c) * 17 % 256);

	private string[] Parse() => input.Split(',');
}
