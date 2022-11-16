using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day2
{
	class SolutionDay2
	{
		private const int day = 2;

		public SolutionDay2() {	}

		public int NavigateSubmarine()
		{
			string inputData = Util.ReadInput(day);
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			int horisontalPosition = 0;
			int depth = 0;
			foreach (string line in lines)
			{
				string[] temp = line.Split(new char[] { ' ' });
				string instruction = temp[0];
				int distance = Convert.ToInt32(temp[1]);
				switch (instruction)
				{
					case "forward":
						horisontalPosition += distance;
						break;
					case "down":
						depth += distance;
						break;
					case "up":
						depth += distance * -1;
						break;
					default:
						throw new Exception("Unknown instruction: " + instruction);
				}
			}

			return horisontalPosition * depth;
		}

		public int NavigateSubmarineWithAim()
		{
			string inputData = Util.ReadInput(day);
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			int horisontalPosition = 0;
			int depth = 0;
			int aim = 0;
			foreach (string line in lines)
			{
				string[] temp = line.Split(new char[] { ' ' });
				string instruction = temp[0];
				int distance = Convert.ToInt32(temp[1]);
				switch (instruction)
				{
					case "forward":
						horisontalPosition += distance;
						depth += aim * distance;
						break;
					case "down":
						aim += distance;
						break;
					case "up":
						aim -= distance;
						break;
					default:
						throw new Exception("Unknown instruction: " + instruction);
				}
			}

			return horisontalPosition * depth;
		}
	}
}
