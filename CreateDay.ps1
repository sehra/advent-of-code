param (
    $year = (Get-Date).Year,
    $day = (Get-Date).Day
)

$code = @"
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year${year}
{
	public class Day${day}
	{
		private readonly string _input;

		public Day${day}(string input)
		{
			_input = input;
		}

		public int Part1()
		{
			throw new NotImplementedException();
		}

		public int Part2()
		{
			throw new NotImplementedException();
		}
	}
}
"@;

$test = @"
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCode.Year${year}
{
	[TestClass]
	public class Day${day}Tests
	{
		[DataTestMethod]
		[DataRow(0, "")]
		public void Part1(int expected, string input)
		{
			Assert.AreEqual(expected, new Day${day}(input).Part1());
		}

		[DataTestMethod]
		[DataRow(0, "")]
		public void Part2(int expected, string input)
		{
			Assert.AreEqual(expected, new Day${day}(input).Part2());
		}
	}
}
"@

Out-File "${PSScriptRoot}/AdventOfCode/Year${year}/Day${day}.cs" -InputObject $code -Encoding UTF8
Out-File "${PSScriptRoot}/AdventOfCode.Tests/Year${year}/Day${day}Tests.cs" -InputObject $test -Encoding UTF8

$cookie = New-Object System.Net.Cookie
$cookie.Domain = ".adventofcode.com"
$cookie.Name = "session"
$cookie.Value = $env:ADVENTOFCODE_SESSION

$session = New-Object Microsoft.PowerShell.Commands.WebRequestSession
$session.Cookies.Add($cookie)

Invoke-WebRequest "https://adventofcode.com/${year}/day/${day}/input" -WebSession $session -OutFile "${PSScriptRoot}/AdventOfCode/Year${year}/Inputs/Day${day}.txt"
