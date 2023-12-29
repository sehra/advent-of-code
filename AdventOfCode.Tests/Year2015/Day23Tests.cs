namespace AdventOfCode.Year2015;

[TestClass]
public class Day23Tests
{
	[TestMethod]
	public void Computer()
	{
		var prog =
			"""
			inc a
			jio a, +2
			tpl a
			inc a
			""";

		var comp = new Day23.Computer(prog.ToLines());
		comp.Run();

		Assert.AreEqual(2u, comp.A);
	}
}
