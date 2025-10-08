using System.Numerics;

namespace AdventOfCode.Year2019;

[TestClass]
public class Day9Tests
{
    public TestContext TestContext { get; set; }

    [TestMethod]
	[DataRow("109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99", "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99")]
	[DataRow("1102,34915192,34915192,7,4,7,99,0", "1219070632396864")]
	[DataRow("104,1125899906842624,99", "1125899906842624")]
	public async Task AddressingModeAndBigInteger(string memory, string expected)
	{
		var results = new List<BigInteger>();
		var intcode = new IntcodeComputer(memory)
		{
			Output = value => { results.Add(value); return Task.CompletedTask; },
		};
		await intcode.RunAsync(TestContext.CancellationToken);

		Assert.AreEqual(expected, String.Join(',', results));
	}
}
