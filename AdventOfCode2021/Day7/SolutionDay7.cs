using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day7
{
	public class SolutionDay7
	{
		private const int DAY = 7;

		public SolutionDay7() { }

		public int DetermineOptimalCrabFuelCost(FuelConsumptionType consumptionType)
		{
			string inputFishAgeString = Util.ReadInput(DAY);
			List<int> crabHeights = inputFishAgeString.Split(',').Select(Int32.Parse).ToList<int>();

			return DetermineOptimalCrabFuelCost(crabHeights, consumptionType);
		}

		public int DetermineOptimalCrabFuelCost(List<int> crabHeights, FuelConsumptionType consumptionType)
		{
			Dictionary<int, int> fuelCosts = new Dictionary<int, int>();
			for (int currentHeight = crabHeights.Min(); currentHeight < crabHeights.Max(); currentHeight++)
				fuelCosts.Add(currentHeight, CalculateFuelCost(currentHeight, crabHeights, consumptionType));

			KeyValuePair<int, int> optimalHeight = new KeyValuePair<int, int>(Int32.MaxValue, Int32.MaxValue);
			foreach (KeyValuePair<int, int> fuelCost in fuelCosts)
			{
				if (fuelCost.Value < optimalHeight.Value)
					optimalHeight = fuelCost;
			}

			Console.WriteLine("Optimal height found: " + optimalHeight.Key);

			return optimalHeight.Value;
		}

		private int CalculateFuelCost(int proposedHeight, List<int> crabHeights, FuelConsumptionType consumptionType)
		{
			int fuelCost = 0;
			foreach (int height in crabHeights)
			{
				if(consumptionType == FuelConsumptionType.Linear)
					fuelCost += Math.Abs(proposedHeight - height);
				else
				{
					int difference = Math.Abs(proposedHeight - height);
					fuelCost += Enumerable.Range(1, difference).Sum();
				}
			}

			return fuelCost;
		}

		#region More efficient solution for part 1
		/// <summary>
		/// This only works with fuel cost = 1 pr. travelled distance
		/// https://math.stackexchange.com/questions/3092033/find-a-number-having-minimum-sum-of-distances-between-a-set-of-numbers
		/// </summary>
		/// <param name="crabHeights"></param>
		/// <returns></returns>
		private int LocateOptimalHeight(List<int> crabHeights)
		{
			crabHeights.Sort();

			int middleIndex = crabHeights.Count / 2;
			if (crabHeights.Count % 2 == 0)
			{
				int lowestPossible = crabHeights[middleIndex - 1];
				int highestPossible = crabHeights[middleIndex];

				// TODO: Test each possible value within the range (both included)?

				return highestPossible;
			}
			else
				return crabHeights[middleIndex];
		}
		#endregion
	}
}
