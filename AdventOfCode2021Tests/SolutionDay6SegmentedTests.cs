using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021.Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Tests
{
	[TestClass()]
	public class SolutionDay6SegmentedTests
	{
		private List<int> fishSchool;

		[TestInitialize]
		public void Setup()
		{
			fishSchool = new List<int>();
			fishSchool.Add(3);
			fishSchool.Add(4);
			fishSchool.Add(3);
			fishSchool.Add(1);
			fishSchool.Add(2);
		}

		[TestMethod()]
		public void CalculateLanternFishTest18Days()
		{
			int days = 18;
			long lanternFishCount = new SolutionDay6Segmented().CalculateLanternFish(days, fishSchool);
			long expectedCount = 26;
			Assert.AreEqual(expectedCount, lanternFishCount, "Lantern fish count after " + days + " days");
		}

		[TestMethod()]
		public void CalculateLanternFishTest80Days()
		{
			int days = 80;
			long lanternFishCount = new SolutionDay6Segmented().CalculateLanternFish(days, fishSchool);
			long expectedCount = 5934;
			Assert.AreEqual(expectedCount, lanternFishCount, "Lantern fish count after " + days + " days");
		}

		[TestMethod()]
		public void CalculateLanternFishTest256Days()
		{
			int days = 256;
			long lanternFishCount = new SolutionDay6Segmented().CalculateLanternFish(days, fishSchool);
			long expectedCount = 26984457539;
			Assert.AreEqual(expectedCount, lanternFishCount, "Lantern fish count after " + days + " days");
		}
	}
}