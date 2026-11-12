namespace AdventOfCode;

[TestClass]
public class ExtensionsTests
{
	[TestMethod]
	public void Permutations_NullSource_ThrowsImmediately()
	{
		Assert.ThrowsExactly<ArgumentNullException>(() => Extensions.Permutations<int>(null!));
	}

	[TestMethod]
	public void Permutations_EmptySource_ReturnsNoResults()
	{
		Assert.IsEmpty(Array.Empty<int>().Permutations().ToArray());
	}

	[TestMethod]
	public void Permutations_SingleItem_ReturnsOnePermutation()
	{
		var permutations = new[] { 42 }.Permutations().ToArray();

		Assert.HasCount(1, permutations);
		Assert.AreSequenceEqual([42], [.. permutations[0]]);
	}

	[TestMethod]
	public void Permutations_PreservesOriginalPositionOrderAndSnapshots()
	{
		var source = new[] { 3, 1, 2 };
		var permutations = source.Permutations().ToArray();
		int[][] expected = [[3, 1, 2], [3, 2, 1], [1, 3, 2], [1, 2, 3], [2, 3, 1], [2, 1, 3]];

		Assert.HasCount(expected.Length, permutations);

		for (var i = 0; i < expected.Length; i++)
		{
			Assert.AreSequenceEqual(expected[i], [.. permutations[i]]);
		}

		Assert.AreSequenceEqual([3, 1, 2], [.. source]);
	}

	[TestMethod]
	public void Permutations_DuplicateAndNullValues_PreservePositionalMultiplicity()
	{
		string?[] source = ["a", null, "a"];
		var permutations = source.Permutations().ToArray();
		string?[][] expected = [
			["a", null, "a"],
			["a", "a", null],
			[null, "a", "a"],
			[null, "a", "a"],
			["a", "a", null],
			["a", null, "a"]
		];

		Assert.HasCount(expected.Length, permutations);

		for (var i = 0; i < expected.Length; i++)
		{
			Assert.AreSequenceEqual(expected[i], [.. permutations[i]]);
		}
	}

	[TestMethod]
	public void Permutations_DefersAndEnumeratesSourceOnce()
	{
		var enumerations = 0;
		var permutations = Source().Permutations();

		Assert.AreEqual(0, enumerations);
		Assert.AreSequenceEqual(["123", "132", "213", "231", "312", "321"], [.. permutations.Select(p => string.Concat(p))]);
		Assert.AreEqual(1, enumerations);

		IEnumerable<int> Source()
		{
			enumerations++;
			yield return 1;
			yield return 2;
			yield return 3;
		}
	}

	[TestMethod]
	public void Permutations_CanBeEnumeratedAgainAfterEarlyExit()
	{
		var permutations = new[] { 1, 2, 3 }.Permutations();

		Assert.AreSequenceEqual([1, 2, 3], [.. permutations.First()]);
		Assert.AreSequenceEqual(["123", "132", "213", "231", "312", "321"], [.. permutations.Select(p => string.Concat(p))]);
	}

	[TestMethod]
	[DataRow(4, 24)]
	[DataRow(5, 120)]
	[DataRow(6, 720)]
	public void Permutations_ProducesEveryArrangement(int length, int expectedCount)
	{
		var source = Enumerable.Range(0, length).ToArray();
		var permutations = source.Permutations().Select(p => p.ToArray()).ToArray();

		Assert.HasCount(expectedCount, permutations);
		Assert.HasCount(expectedCount, permutations.Select(p => string.Join(",", p)).Distinct());

		foreach (var permutation in permutations)
		{
			Assert.AreSequenceEqual(source, permutation, SequenceOrder.InAnyOrder);
		}
	}

	[TestMethod]
	public void Combinations_InvalidArguments_ThrowImmediately()
	{
		Assert.ThrowsExactly<ArgumentNullException>(() => Extensions.Combinations<int>(null!, 0));
		Assert.ThrowsExactly<ArgumentOutOfRangeException>(() => Array.Empty<int>().Combinations(-1));
	}

	[TestMethod]
	public void Combinations_ZeroCount_ReturnsOneEmptyResultWithoutEnumeratingSource()
	{
		var enumerations = 0;
		var combinations = Source().Combinations(0).ToArray();

		Assert.HasCount(1, combinations);
		Assert.IsEmpty(combinations[0]);
		Assert.AreEqual(0, enumerations);

		IEnumerable<int> Source()
		{
			enumerations++;
			yield return 1;
		}
	}

	[TestMethod]
	[DataRow(0, 1)]
	[DataRow(3, 4)]
	[DataRow(3, int.MaxValue)]
	public void Combinations_CountExceedsLength_ReturnsNoResults(int length, int count)
	{
		Assert.IsEmpty(Enumerable.Range(0, length).Combinations(count).ToArray());
	}

	[TestMethod]
	public void Combinations_PreservesOriginalPositionOrderAndSnapshots()
	{
		var source = new[] { 4, 1, 3, 2 };
		var combinations = source.Combinations(2).ToArray();
		int[][] expected = [[4, 1], [4, 3], [4, 2], [1, 3], [1, 2], [3, 2]];

		Assert.HasCount(expected.Length, combinations);

		for (var i = 0; i < expected.Length; i++)
		{
			Assert.AreSequenceEqual(expected[i], [.. combinations[i]]);
		}

		Assert.AreSequenceEqual([4, 1, 3, 2], source);
	}

	[TestMethod]
	public void Combinations_DuplicateAndNullValues_PreservePositionalMultiplicity()
	{
		string?[] source = ["a", null, "a"];
		var combinations = source.Combinations(2).ToArray();
		string?[][] expected = [["a", null], ["a", "a"], [null, "a"]];

		Assert.HasCount(expected.Length, combinations);

		for (var i = 0; i < expected.Length; i++)
		{
			Assert.AreSequenceEqual(expected[i], [.. combinations[i]]);
		}
	}

	[TestMethod]
	public void Combinations_DefersAndEnumeratesSourceOncePerEnumeration()
	{
		var enumerations = 0;
		var combinations = Source().Combinations(2);

		Assert.AreEqual(0, enumerations);
		Assert.AreSequenceEqual([1, 2], [.. combinations.First()]);
		Assert.AreEqual(1, enumerations);
		Assert.AreSequenceEqual(["12", "13", "23"], [.. combinations.Select(c => string.Concat(c))]);
		Assert.AreEqual(2, enumerations);

		IEnumerable<int> Source()
		{
			enumerations++;
			if (enumerations > 2)
			{
				throw new InvalidOperationException("Source enumerated more than once per iteration.");
			}
			yield return 1;
			yield return 2;
			yield return 3;
		}
	}
}
