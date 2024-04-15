using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MatrixAreasProblem
{
	[TestFixture]
	internal class Tests
	{
		[TestCase("1,0,1;0,1,0", 3)]
		[TestCase("1,0,1;1,1,0", 2)]
		[TestCase("1,1,1,0;0,1,0,0", 1)]
		[TestCase("0,0,0;0,0,0", 0)]
		[TestCase("1,1,1;1,1,1", 1)]
		[TestCase("1,1,1,1,1;1,0,0,0,1;1,0,1,0,1;1,0,0,0,1;1,1,1,1,1", 2)]
		[TestCase("1,0,0,1,0;0,1,0,1,0;0,0,1,0,0;0,1,0,1,0;1,0,0,1,0", 7)]
		[TestCase("1,1,0,0,0;1,1,0,0,0;0,0,1,1,0;0,0,1,1,0;0,0,0,0,1", 3)]
		[TestCase("1,1,1,1,1,1;1,1,1,1,1,1;1,1,1,1,1,1;1,1,1,1,1,1;1,1,1,1,1,1;1,1,1,1,1,1", 1)]
		[TestCase("1,0,1,0,1;0,1,0,1,0;1,0,1,0,1;0,1,0,1,0;1,0,1,0,1", 13)]
		public void TestCountConnectedAreas(string input, int expected)
		{
			int result = Program.Main([input]);
			Assert.That(expected == result);
		}
	}
}
