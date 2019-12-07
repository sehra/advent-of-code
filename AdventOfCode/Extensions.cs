using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
	public static class Extensions
	{
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
	}
}
