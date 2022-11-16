using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode2021;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AdventOfCode2021.Day7;

namespace AdventOfCode2021.Tests
{
	[TestClass()]
	public class SolutionDay7Tests
	{
		private List<int> heights;

		[TestInitialize]
		public void Setup()
		{
			heights = new List<int>() { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };
		}

		[TestMethod()]
		public void DetermineOptimalCrabFuelCostLinearTest()
		{
			int expectedFuelCost = 37;
			int actualFuelCost = new SolutionDay7().DetermineOptimalCrabFuelCost(heights, FuelConsumptionType.Linear);
			Assert.AreEqual(expectedFuelCost, actualFuelCost, "Fuel cost does not match");
		}

		[TestMethod()]
		public void DetermineOptimalCrabFuelCostExponentialTest()
		{
			int expectedFuelCost = 168;
			int actualFuelCost = new SolutionDay7().DetermineOptimalCrabFuelCost(heights, FuelConsumptionType.Exponential);
			Assert.AreEqual(expectedFuelCost, actualFuelCost, "Fuel cost does not match");
		}
	}
}