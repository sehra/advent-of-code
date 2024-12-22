namespace AdventOfCode.Year2024;

using Key = (long, long, long, long);

public class Day22(int[] input)
{
	public long Part1()
	{
		return input.Sum(seed => Secrets(seed).Take(2000).Last());
	}

	public long Part2()
	{
		var bananas = new DefaultDictionary<Key, long>();

		foreach (var seed in input)
		{
			var seen = new HashSet<Key>();
			var nums = Secrets(seed).Take(2000).Prepend(seed).Select(n => n % 10).ToArray();
			var diff = nums.Zip(nums.Skip(1)).Select(p => p.Second - p.First).ToArray();

			for (int i = 0; i < diff.Length - 3; i++)
			{
				var seq = (diff[i], diff[i + 1], diff[i + 2], diff[i + 3]);

				if (seen.Add(seq))
				{
					bananas[seq] += nums[i + 4];
				}
			}
		}

		return bananas.Values.Max();
	}

	private static IEnumerable<long> Secrets(long state)
	{
		while (true)
		{
			state ^= state * 64;
			state %= 16777216;
			state ^= state / 32;
			state %= 16777216;
			state ^= state * 2048;
			state %= 16777216;

			yield return state;
		}
	}

	private class DefaultDictionary<K, V> : Dictionary<K, V>
	{
		public new V this[K key]
		{
			get => TryGetValue(key, out var value) ? value : default;
			set => base[key] = value;
		}
	}
}
