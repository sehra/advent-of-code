param (
    $Year = (Get-Date).Year,
    $Day = (Get-Date).Day
)

function WriteFile {
	param (
		[string]$File,
		[string]$Text
	)
	
	$File = $PSScriptRoot | Join-Path -ChildPath $File
	New-Item ($File | Split-Path -Parent) -ItemType Directory -Force
	Out-File -FilePath $File -InputObject $Text -Encoding UTF8 -NoClobber
}

WriteFile -File "AdventOfCode\Year${Year}\Day${Day}.cs" -Text @"
namespace AdventOfCode.Year${Year};

public class Day${Day}(string input)
{
	public int Part1()
	{
		throw new NotImplementedException();
	}

	public int Part2()
	{
		throw new NotImplementedException();
	}
}
"@

WriteFile -File "AdventOfCode.Tests\Year${Year}\Day${Day}Tests.cs" -Text @"
namespace AdventOfCode.Year${Year};

[TestClass]
public class Day${Day}Tests
{
	[DataTestMethod]
	[DataRow(0, "")]
	public void Part1(int expected, string input)
	{
		Assert.AreEqual(expected, new Day${Day}(input).Part1());
	}

	[DataTestMethod]
	[DataRow(0, "")]
	public void Part2(int expected, string input)
	{
		Assert.AreEqual(expected, new Day${Day}(input).Part2());
	}
}
"@

WriteFile -File "AdventOfCode.Bench\Year${Year}\Day${day}Bench.cs" -Text @"
namespace AdventOfCode.Year${Year};

[MemoryDiagnoser]
public class Day${Day}Bench
{
	private string _input;

	[GlobalSetup]
	public void Setup()
	{
		_input = Program.GetEmbeddedInput(${Year}, ${Day});
	}

	[Benchmark]
	public int Part1() => new Day${Day}(_input).Part1();

	[Benchmark]
	public int Part2() => new Day${Day}(_input).Part2();
}
"@;

$InputFile = $PSScriptRoot | Join-Path -ChildPath "AdventOfCode\Year${Year}\Inputs\Day${Day}.txt"
New-Item ($InputFile | Split-Path -Parent) -ItemType Directory -Force

if (-not(Test-Path $InputFile -PathType Leaf))
{
	$Cookie = New-Object System.Net.Cookie
	$Cookie.Domain = ".adventofcode.com"
	$Cookie.Name = "session"
	$Cookie.Value = $Env:ADVENTOFCODE_SESSION

	$Session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
	$Session.Cookies.Add($Cookie)

	Invoke-WebRequest "https://adventofcode.com/${Year}/day/${Day}/input" -WebSession $Session -OutFile $InputFile
}
