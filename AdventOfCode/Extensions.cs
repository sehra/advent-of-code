using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AdventOfCode
{
	public static class Extensions
	{
		public static IEnumerable<IEnumerable<T>> GroupWhile<T>(this IEnumerable<T> items, Func<T, T, bool> condition)
		{
			var prev = items.First();
			var list = new List<T> { prev };

			foreach (var item in items.Skip(1))
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

		public static IEnumerable<IEnumerable<T>> Permutations<T>(this IEnumerable<T> items)
		{
			if (items == null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			return PermutationsImpl(items);

			static IEnumerable<IEnumerable<T>> PermutationsImpl(IEnumerable<T> items)
			{
				var count = items.Count();

				if (count == 1)
				{
					yield return items;
				}
				else
				{
					for (var i = 0; i < count; i++)
					{
						foreach (var permutation in PermutationsImpl(items.Take(i).Concat(items.Skip(i + 1))))
						{
							yield return items.Skip(i).Take(1).Concat(permutation);
						}
					}
				}
			}
		}

		public static string[] ToLines(this string input,
			StringSplitOptions options = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
		{
			return input.Split(new[] { "\r", "\n", "\r\n" }, options);
		}

		public static int ToInt32(this string value) => Int32.Parse(value, CultureInfo.InvariantCulture);
		public static int ToInt32(this ReadOnlySpan<char> value) => Int32.Parse(value);
		public static long ToInt64(this string value) => Int64.Parse(value, CultureInfo.InvariantCulture);
		public static long ToInt64(this ReadOnlySpan<char> value) => Int64.Parse(value);

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

		public static IEnumerable<IList<T>> Window<T>(this IEnumerable<T> items, int size)
		{
			if (items is null)
			{
				throw new ArgumentNullException(nameof(items));
			}

			if (size <= 0)
			{
				throw new ArgumentOutOfRangeException(nameof(size));
			}

			return WindowImpl(items, size);

			IEnumerable<IList<T>> WindowImpl(IEnumerable<T> items, int size)
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
	}
}
