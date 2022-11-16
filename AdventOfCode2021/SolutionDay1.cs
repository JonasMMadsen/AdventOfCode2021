using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
	class SolutionDay1
	{
		private const int day = 1;

		public SolutionDay1() {	}

		public int CountIncreasesInDepth()
		{
			string inputData = Util.ReadInput(day);
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			int previous = Int32.MaxValue;
			int count = 0;
			foreach (string line in lines)
			{
				int current = Convert.ToInt32(line);
				if(current > previous)
					count++;
				previous = current;
			}

			return count;
		}

		public int CountIncreasesInSlidingDepthWindow()
		{
			string inputData = Util.ReadInput(day);
			List<int> data = inputData?.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
				.Select(Int32.Parse)
				.ToList();

			int previous = Int32.MaxValue;
			int count = 0;
			for (int i = 0; i < data.Count; i++)
			{
				int current = GetWindow3Sum(i, data);
				if (current > previous)
					count++;
				previous = current;
			}

			return count;
		}

		private int GetWindow3Sum(int index, List<int> data)
		{
			if(index >= (data.Count - 1))
				return data[index];
			if (index >= (data.Count - 2))
				return data[index] + data[index + 1];
			else
				return data[index] + data[index + 1] + data[index + 2];
		}
	}
}
