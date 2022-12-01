using System.Globalization;

namespace AdventOfCode;

public static class Extensions
{
	public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> source, Func<T, T, bool> condition)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(condition);

		var prev = source.First();
		var list = new List<T> { prev };

		foreach (var item in source.Skip(1))
		{
			if (!condition(prev, item))
			{
				yield return list;
				list = new List<T>();
			}

			list.Add(item);
			prev = item;
		}

		yield return list;
	}

	public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> source)
	{
		ArgumentNullException.ThrowIfNull(source);

		return PermutationsImpl(source);

		static IEnumerable<IEnumerable<T>> PermutationsImpl(IEnumerable<T> source)
		{
			var count = source.Count();

			if (count == 1)
			{
				yield return source;
			}
			else
			{
				for (var i = 0; i < count; i++)
				{
					foreach (var permutation in PermutationsImpl(source.Take(i).Concat(source.Skip(i + 1))))
					{
						yield return source.Skip(i).Take(1).Concat(permutation);
					}
				}
			}
		}
	}

	public static string[] ToLines(this string input,
		StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
	{
		return input.Split(new[] { "\r\n", "\r", "\n" }, options);
	}

	public static int ToInt32(this string value) => Int32.Parse(value, CultureInfo.InvariantCulture);
	public static int ToInt32(this ReadOnlySpan<char> value) => Int32.Parse(value, provider: CultureInfo.InvariantCulture);
	public static long ToInt64(this string value) => Int64.Parse(value, CultureInfo.InvariantCulture);
	public static long ToInt64(this ReadOnlySpan<char> value) => Int64.Parse(value, provider: CultureInfo.InvariantCulture);
	public static uint ToUInt32(this string value) => UInt32.Parse(value, CultureInfo.InvariantCulture);
	public static uint ToUInt32(this ReadOnlySpan<char> value) => UInt32.Parse(value, provider: CultureInfo.InvariantCulture);
	public static ulong ToUInt64(this string value) => UInt64.Parse(value, CultureInfo.InvariantCulture);
	public static ulong ToUInt64(this ReadOnlySpan<char> value) => UInt64.Parse(value, provider: CultureInfo.InvariantCulture);

	public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
		TKey key, Func<TValue, TValue> updateValue, TValue insertValue)
	{
		if (dictionary.TryGetValue(key, out var value))
		{
			dictionary[key] = updateValue(value);
		}
		else
		{
			dictionary[key] = insertValue;
		}
	}

	public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
		TKey key, Func<TValue, TValue> updateValue, Func<TValue> insertValueFactory)
	{
		if (dictionary.TryGetValue(key, out var value))
		{
			dictionary[key] = updateValue(value);
		}
		else
		{
			dictionary[key] = insertValueFactory();
		}
	}

	public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
		TKey key, Action<TValue> updateValue, TValue insertValue)
	{
		if (dictionary.TryGetValue(key, out var value))
		{
			updateValue(value);
		}
		else
		{
			dictionary[key] = insertValue;
		}
	}

	public static void Upsert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
		TKey key, Action<TValue> updateValue, Func<TValue> defaultValueFactory)
	{
		if (dictionary.TryGetValue(key, out var value))
		{
			updateValue(value);
		}
		else
		{
			dictionary[key] = defaultValueFactory();
		}
	}

	public static IEnumerable<T[]> Window<T>(this IEnumerable<T> source, int size)
	{
		ArgumentNullException.ThrowIfNull(source);

		if (size <= 0)
		{
			throw new ArgumentOutOfRangeException(nameof(size));
		}

		return WindowImpl(source, size);

		static IEnumerable<T[]> WindowImpl(IEnumerable<T> items, int size)
		{
			using var enumerator = items.GetEnumerator();

			var curr = new T[size];
			var i = 0;

			for (i = 0; i < size && enumerator.MoveNext(); i++)
			{
				curr[i] = enumerator.Current;
			}

			if (i < size)
			{
				yield break;
			}

			while (enumerator.MoveNext())
			{
				var next = new T[size];
				curr.AsSpan(1).CopyTo(next);
				next[^1] = enumerator.Current;

				yield return curr;
				curr = next;
			}

			yield return curr;
		}
	}

	public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T value)
	{
		ArgumentNullException.ThrowIfNull(source);

		return source.Except(new[] { value });
	}

	public static IEnumerable<(int Index0, int Index1, T Value)> AsEnumerable<T>(this T[,] array)
	{
		ArgumentNullException.ThrowIfNull(array);

		for (int i0 = 0; i0 < array.GetLength(0); i0++)
		{
			for (int i1 = 0; i1 < array.GetLength(1); i1++)
			{
				yield return (i0, i1, array[i0, i1]);
			}
		}
	}

	public static T Next<T>(this IEnumerator<T> enumerator)
	{
		ArgumentNullException.ThrowIfNull(enumerator);

		if (!enumerator.MoveNext())
		{
			throw new InvalidOperationException("empty sequence");
		}

		return enumerator.Current;
	}
}
