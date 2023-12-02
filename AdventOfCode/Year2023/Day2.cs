namespace AdventOfCode.Year2023;

public class Day2(string[] input)
{
	public int Part1() => Parse()
		.Where(game =>
			game.Colors.Where(color => color.Color is "red").All(color => color.Count <= 12) &&
			game.Colors.Where(color => color.Color is "green").All(color => color.Count <= 13) &&
			game.Colors.Where(color => color.Color is "blue").All(color => color.Count <= 14)
		)
		.Sum(game => game.Id);

	public int Part2() => Parse()
		.Select(game => new
		{
			Red = game.Colors.Where(color => color.Color is "red").Max(color => color.Count),
			Green = game.Colors.Where(color => color.Color is "green").Max(color => color.Count),
			Blue = game.Colors.Where(color => color.Color is "blue").Max(color => color.Count),
		})
		.Sum(game => game.Red * game.Green * game.Blue);

	private IEnumerable<(int Id, (string Color, int Count)[] Colors)> Parse()
	{
		foreach (var line in input)
		{
			var colon = line.IndexOf(':');
			var rounds = line[(colon + 1)..]
				.Split(';', ',')
				.Select(color => color.Split(' ', StringSplitOptions.RemoveEmptyEntries))
				.Select(color => (color[1], color[0].ToInt32()));

			yield return (line[5..colon].ToInt32(), rounds.ToArray());
		}
	}
}
