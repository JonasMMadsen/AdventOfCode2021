using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace AdventOfCode2021.Day6
{
	public class SolutionDay6Fast
	{
		private const int DAY = 6;
		private const int LANTERN_FISH_START_AGE = 8;
		private const int RESET_AGE = 6;

		private Stopwatch stopWatch;

		public SolutionDay6Fast() { this.stopWatch = new Stopwatch(); }

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// Current fish population is read from Solution input file.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days)
		{
			string inputFishAgeString = Util.ReadInput(DAY);
			List<sbyte> fishSchool = inputFishAgeString.Split(',').Select(SByte.Parse).ToList<sbyte>();

			return CalculateLanternFish(days, fishSchool);
		}

		/// <summary>
		/// Calculate the total number of present lantern fish, after a given set of days has passed.
		/// </summary>
		/// <param name="days">The number of days the collection of lantern fish is allowed to breed.</param>
		/// <param name="fishSchool">Collection of initialized <see cref="LanternFish"/> to breed.</param>
		/// <returns>The total number of found lantern fish.</returns>
		public long CalculateLanternFish(int days, List<sbyte> fishSchool)
		{
			for (int i = 0; i < days; i++)
			{
				stopWatch.Start();
				// For debug purposes
				//PrintFishes(i, fishSchool);

				// TODO: How to store more than 2 billion elements (arrays cannot be adressed using a long)

				// Stop current loop after all current elements have been processed (ignoring all newly added).
				int iterationCount = fishSchool.Count;
				for (int j = 0; j < iterationCount; j++)
				{
					fishSchool[j]--;

					if (fishSchool[j] < 0)
					{
						fishSchool[j] = RESET_AGE;
						fishSchool.Add(LANTERN_FISH_START_AGE);
					}
				}
		
				stopWatch.Stop();

				Console.WriteLine("Fish after day {0}: {1} - Time taken {2}", i, fishSchool.Count, stopWatch.Elapsed);
				stopWatch.Reset();
			}

			return fishSchool.Count;
		}

		private void PrintFishes(int day, List<sbyte> fishSchool)
		{
			Console.WriteLine("{0}: {1}", day, String.Join(",", fishSchool));
		}
	}
}
