namespace AdventOfCode;

public class Counter<T> : Dictionary<T, int>
{
	public new int this[T key]
	{
		get => TryGetValue(key, out var value) ? value : 0;
		set => base[key] = value;
	}

	public IEnumerable<KeyValuePair<T, int>> MostCommon(int count)
	{
		return this.OrderByDescending(kv => kv.Value).Take(count);
	}

	public void Update(IEnumerable<T> source)
	{
		foreach (var item in source)
		{
			this[item] += 1;
		}
	}

	public void Subtract(IEnumerable<T> source)
	{
		foreach (var item in source)
		{
			this[item] -= 1;
		}
	}
}
