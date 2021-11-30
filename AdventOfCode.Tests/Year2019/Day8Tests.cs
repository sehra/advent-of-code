namespace AdventOfCode.Year2019;

[TestClass]
public class Day8Tests
{
	[TestMethod]
	public void Decode()
	{
		var picture = Day8.DecodePicture("123456789012", 3, 2);

		Assert.AreEqual(2, picture.Count);
		Assert.AreEqual(1, picture[0][0, 0]);
		Assert.AreEqual(2, picture[0][1, 0]);
		Assert.AreEqual(3, picture[0][2, 0]);
		Assert.AreEqual(4, picture[0][0, 1]);
		Assert.AreEqual(5, picture[0][1, 1]);
		Assert.AreEqual(6, picture[0][2, 1]);
		Assert.AreEqual(7, picture[1][0, 0]);
		Assert.AreEqual(8, picture[1][1, 0]);
		Assert.AreEqual(9, picture[1][2, 0]);
		Assert.AreEqual(0, picture[1][0, 1]);
		Assert.AreEqual(1, picture[1][1, 1]);
		Assert.AreEqual(2, picture[1][2, 1]);
	}
}
