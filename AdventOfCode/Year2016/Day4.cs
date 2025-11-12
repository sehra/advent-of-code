namespace AdventOfCode.Year2016;

public class Day4(string[] input)
{
	public int Part1()
	{
		return input
			.Select(ValidateRoom)
			.Where(room => room.IsReal)
			.Sum(room => room.Sector);
	}

	public int Part2()
	{
		return input
			.Select(ValidateRoom)
			.Where(room => room.IsReal)
			.First(room => Decrypt(room.Name, room.Sector) == "northpole object storage")
			.Sector;

		static string Decrypt(string name, int sector) => name
			.Select(c => c is '-' ? ' ' : (char)((c - 'a' + sector) % 26 + 'a'))
			.ToString((sb, c) => sb.Append(c));
	}

	private static (bool IsReal, int Sector, string Name) ValidateRoom(string room)
	{
		var dash = room.LastIndexOf('-');
		var name = room[..dash]
			.Replace("-", "")
			.GroupBy(c => c)
			.Select(g => (Count: g.Count(), Letter: g.Key))
			.OrderByDescending(x => x.Count)
			.ThenBy(x => x.Letter);
		var sector = room[(dash + 1)..^7].ToInt32();
		var checksum = room[^6..^1];

		return (name.Zip(checksum).All(p => p.First.Letter == p.Second), sector, room[..dash]);
	}
}
