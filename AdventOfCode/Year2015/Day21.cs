namespace AdventOfCode.Year2015;

public class Day21(string[] input)
{
	public int Part1()
	{
		var boss = Parse();
		var gold = Int32.MaxValue;

		foreach (var (cost, damage, armor) in ShopCombinations())
		{
			if (PlayerWins(new(100, damage, armor), boss))
			{
				gold = Math.Min(gold, cost);
			}
		}

		return gold;
	}

	public int Part2()
	{
		var boss = Parse();
		var gold = Int32.MinValue;

		foreach (var (cost, damage, armor) in ShopCombinations())
		{
			if (!PlayerWins(new(100, damage, armor), boss))
			{
				gold = Math.Max(gold, cost);
			}
		}

		return gold;
	}

	public static bool PlayerWins(Player player, Player boss)
	{
		while (true)
		{
			var dmg = Math.Max(1, player.Damage - boss.Armor);
			boss = boss with { HitPoints = boss.HitPoints - dmg };

			if (boss.HitPoints <= 0)
			{
				return true;
			}

			dmg = Math.Max(1, boss.Damage - player.Armor);
			player = player with { HitPoints = player.HitPoints - dmg };

			if (player.HitPoints <= 0)
			{
				return false;
			}
		}
	}

	private static IEnumerable<(int Cost, int Damage, int Armor)> ShopCombinations()
	{
		Item[] weapons =
		[
			new(8, 4, 0),
			new(10, 5, 0),
			new(25, 6, 0),
			new(40, 7, 0),
			new(74, 8, 0),
		];
		Item[] armor =
		[
			new(0, 0, 0),
			new(13, 0, 1),
			new(31, 0, 2),
			new(53, 0, 3),
			new(75, 0, 4),
			new(102, 0, 5),
		];
		Item[] rings =
		[
			new(0, 0, 0),
			new(0, 0, 0),
			new(25, 1, 0),
			new(50, 2, 0),
			new(100, 3, 0),
			new(20, 0, 1),
			new(40, 0, 2),
			new(80, 0, 3),
		];

		for (int w = 0; w < weapons.Length; w++)
		{
			for (int a = 0; a < armor.Length; a++)
			{
				for (int r1 = 0; r1 < rings.Length; r1++)
				{
					for (int r2 = r1 + 1; r2 < rings.Length; r2++)
					{
						var cost = weapons[w].Cost + armor[a].Cost + rings[r1].Cost + rings[r2].Cost;
						var dmg = weapons[w].Damage + rings[r1].Damage + rings[r2].Damage;
						var def = armor[a].Armor + rings[r1].Armor + rings[r2].Armor;

						yield return (cost, dmg, def);
					}
				}
			}
		}
	}

	public readonly record struct Player(int HitPoints, int Damage, int Armor);
	private readonly record struct Item(int Cost, int Damage, int Armor);

	private Player Parse()
	{
		var boss = new Player();

		foreach (var line in input)
		{
			var value = line.AsSpan(line.IndexOf(':') + 1).ToInt32();

			if (line.StartsWith("Hit Points"))
			{
				boss = boss with { HitPoints = value };
			}
			else if (line.StartsWith("Damage"))
			{
				boss = boss with { Damage = value };
			}
			else if (line.StartsWith("Armor"))
			{
				boss = boss with { Armor = value };
			}
		}

		return boss;
	}
}
