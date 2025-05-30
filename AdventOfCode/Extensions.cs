using System.Globalization;
using System.Text;

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
				list = [];
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
		return input.Split(["\r\n", "\r", "\n"], options);
	}

	public static int ToInt32(this string value, NumberStyles style = NumberStyles.Integer) =>
		Int32.Parse(value, style, CultureInfo.InvariantCulture);
	public static int ToInt32(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer) =>
		Int32.Parse(value, style, CultureInfo.InvariantCulture);
	public static long ToInt64(this string value, NumberStyles style = NumberStyles.Integer) =>
		Int64.Parse(value, style, CultureInfo.InvariantCulture);
	public static long ToInt64(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer) =>
		Int64.Parse(value, style, CultureInfo.InvariantCulture);
	public static uint ToUInt32(this string value, NumberStyles style = NumberStyles.Integer) =>
		UInt32.Parse(value, style, CultureInfo.InvariantCulture);
	public static uint ToUInt32(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer) =>
		UInt32.Parse(value, style, CultureInfo.InvariantCulture);
	public static ulong ToUInt64(this string value, NumberStyles style = NumberStyles.Integer) =>
		UInt64.Parse(value, style, CultureInfo.InvariantCulture);
	public static ulong ToUInt64(this ReadOnlySpan<char> value, NumberStyles style = NumberStyles.Integer) =>
		UInt64.Parse(value, style, CultureInfo.InvariantCulture);

	public static int[] ToInt32(this string[] values) => [.. values.Parse<int>()];
	public static long[] ToInt64(this string[] values) => [.. values.Parse<long>()];
	public static uint[] ToUInt32(this string[] values) => [.. values.Parse<uint>()];
	public static ulong[] ToUInt64(this string[] values) => [.. values.Parse<ulong>()];

	public static IEnumerable<T> Parse<T>(this IEnumerable<string> values) where T : ISpanParsable<T> =>
		values.Select(x => T.Parse(x, CultureInfo.InvariantCulture));

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
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);

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

		return source.Except([value]);
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

	public static IEnumerable<(int Index, T Item)> Index<T>(this IEnumerable<T> source, int startIndex)
	{
		ArgumentNullException.ThrowIfNull(source);

		return source.Select((item, index) => (startIndex + index, item));
	}

	public static T Multiply<T>(this IEnumerable<T> source)
		where T : IMultiplyOperators<T, T, T>
	{
		ArgumentNullException.ThrowIfNull(source);

		return source.Aggregate((acc, value) => acc * value);
	}

	public static string ToString<T>(this IEnumerable<T> source, Action<StringBuilder, T> action)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(action);

		return source.Aggregate(
			new StringBuilder(),
			(sb, item) => { action(sb, item); return sb; },
			sb => sb.ToString());
	}

	public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> source, int count)
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentOutOfRangeException.ThrowIfNegative(count);

		return count is 0
			? EnumerableEx.Return(Enumerable.Empty<T>())
			: source.SelectMany(
				(item, index) => source
					.Skip(index + 1)
					.Combinations(count - 1)
					.Select(rest => EnumerableEx.Return(item).Concat(rest)));
	}

	public static U Sum<T, U>(this IEnumerable<T> source, Func<T, int, U> selector)
		where U : IAdditionOperators<U, U, U>, IAdditiveIdentity<U, U>
	{
		ArgumentNullException.ThrowIfNull(source);
		ArgumentNullException.ThrowIfNull(selector);

		return source
			.Index()
			.Aggregate(U.AdditiveIdentity, (acc, item) => acc + selector(item.Item, item.Index));
	}

	public static IEnumerable<IGrouping<T, T>> Group<T>(this IEnumerable<T> source)
	{
		ArgumentNullException.ThrowIfNull(source);

		return source.GroupBy(item => item);
	}

	public static IEnumerable<(T, T)> TupleWindow2<T>(this IEnumerable<T> source)
	{
		ArgumentNullException.ThrowIfNull(source);

		return Impl(source);

		static IEnumerable<(T, T)> Impl(IEnumerable<T> source)
		{
			var a = default(T);
			var b = default(T);

			using var e = source.GetEnumerator();
			if (e.MoveNext()) b = e.Current; else yield break;

			while (e.MoveNext())
			{
				yield return (a, b) = (b, e.Current);
			}
		}
	}

	public static IEnumerable<(T, T, T)> TupleWindow3<T>(this IEnumerable<T> source)
	{
		ArgumentNullException.ThrowIfNull(source);

		return Impl(source);

		static IEnumerable<(T, T, T)> Impl(IEnumerable<T> source)
		{
			var a = default(T);
			var b = default(T);
			var c = default(T);

			using var e = source.GetEnumerator();
			if (e.MoveNext()) b = e.Current; else yield break;
			if (e.MoveNext()) c = e.Current; else yield break;

			while (e.MoveNext())
			{
				yield return (a, b, c) = (b, c, e.Current);
			}
		}
	}

	public static IEnumerable<(T, T, T, T)> TupleWindow4<T>(this IEnumerable<T> source)
	{
		ArgumentNullException.ThrowIfNull(source);

		return Impl(source);

		static IEnumerable<(T, T, T, T)> Impl(IEnumerable<T> source)
		{
			var a = default(T);
			var b = default(T);
			var c = default(T);
			var d = default(T);

			using var e = source.GetEnumerator();
			if (e.MoveNext()) b = e.Current; else yield break;
			if (e.MoveNext()) c = e.Current; else yield break;
			if (e.MoveNext()) d = e.Current; else yield break;

			while (e.MoveNext())
			{
				yield return (a, b, c, d) = (b, c, d, e.Current);
			}
		}
	}

	public static void Fill<T>(this T[,] array, T item)
	{
		ArgumentNullException.ThrowIfNull(array);

		for (int r = 0; r < array.GetLength(0); r++)
		{
			for (int c = 0; c < array.GetLength(1); c++)
			{
				array[r, c] = item;
			}
		}
	}
}
