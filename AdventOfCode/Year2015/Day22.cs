namespace AdventOfCode.Year2015;

public class Day22(string[] input)
{
	public int Part1(int hp = 50, int mp = 500) => Solve(new(hp, 0, 0, mp, []), Parse(), false);

	public int Part2(int hp = 50, int mp = 500) => Solve(new(hp, 0, 0, mp, []), Parse(), true);

	private int Solve(Unit player, Unit boss, bool hard)
	{
		var spells = new Spell[]
		{
			new("Magic Missile", 53, 1, 4, 0, 0, 0),
			new("Drain", 73, 1, 2, 0, 2, 0),
			new("Shield", 113, 6, 0, 7, 0, 0),
			new("Poison", 173, 6, 3, 0, 0, 0),
			new("Recharge", 229, 5, 0, 0, 0, 101),
		};

		var work = new PriorityQueue<State, int>();
		work.Enqueue(new(player, boss, true), 0);

		while (work.TryDequeue(out var state, out var spent))
		{
			if (hard && state.PlayerTurn)
			{
				state = state with
				{
					Player = state.Player with
					{
						Health = state.Player.Health - 1,
					},
				};

				if (state.Player.Health <= 0)
				{
					continue;
				}
			}

			state = state with
			{
				Player = state.Player with
				{
					Health = state.Player.Health + state.Player.Effects.Sum(e => e.HealthRegen),
					Mana = state.Player.Mana + state.Player.Effects.Sum(e => e.ManaRegen),
					Damage = state.Player.Effects.Sum(e => e.Damage),
					Armor = state.Player.Effects.Sum(e => e.Armor),
					Effects = [.. state.Player.Effects.Select(e => e with { Turns = e.Turns - 1 }).Where(e => e.Turns > 0)],
				},
			};

			state = state with
			{
				Boss = state.Boss with
				{
					Health = state.Boss.Health - state.Player.Damage,
				},
			};

			if (state.Boss.Health <= 0)
			{
				return spent;
			}

			if (state.PlayerTurn)
			{
				foreach (var spell in spells.Except(state.Player.Effects).Where(e => e.Cost <= state.Player.Mana))
				{
					var next = state with
					{
						Player = state.Player with
						{
							Mana = state.Player.Mana - spell.Cost,
							Effects = [.. state.Player.Effects, spell],
						},
						PlayerTurn = false,
					};

					work.Enqueue(next, spent + spell.Cost);
				}
			}
			else
			{
				state = state with
				{
					Player = state.Player with
					{
						Health = state.Player.Health - Math.Max(1, state.Boss.Damage - state.Player.Armor),
					},
				};

				if (state.Player.Health <= 0)
				{
					continue;
				}

				work.Enqueue(state with { PlayerTurn = true }, spent);
			}
		}

		return 0;
	}

	private readonly record struct Unit(int Health, int Damage, int Armor, int Mana, Spell[] Effects);

	private readonly record struct Spell(string Name, int Cost, int Turns,
		int Damage, int Armor, int HealthRegen, int ManaRegen) : IEquatable<Spell>
	{
		public bool Equals(Spell other) => Name == other.Name;
		public override int GetHashCode() => Name.GetHashCode();
	}

	private readonly record struct State(Unit Player, Unit Boss, bool PlayerTurn);

	private Unit Parse()
	{
		var boss = new Unit();

		foreach (var line in input)
		{
			var value = line.AsSpan(line.IndexOf(':') + 1).ToInt32();

			if (line.StartsWith("Hit Points"))
			{
				boss = boss with { Health = value };
			}
			else if (line.StartsWith("Damage"))
			{
				boss = boss with { Damage = value };
			}
		}

		return boss;
	}
}
