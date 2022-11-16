using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
	/// <summary>
	/// A board must have an entire row or column of numbers that have been drawn from the pool to win.
	/// 
	/// If two boards should end up winning in the same draw "round", the fist found board is declared the winner.
	/// </summary>
	class SolutionDay4
	{
		private const int day = 4;

		public SolutionDay4() {	}

		#region Part 1
		/// <summary>
		/// Read all number draw data + board data, and determines which board will win first.
		/// </summary>
		/// <returns>The value of the board that has been declared the winner.</returns>
		public int LocateScoreOfWinningBoard()
		{
			int[] drawnNumbers = ReadDrawnNumbers();
			List<Board> boards = ReadBoards();

			foreach (int drawnNumber in drawnNumbers)
			{
				foreach (Board board in boards)
				{
					int score = board.CheckNumber(drawnNumber);
					if (score > 0)
					{
						Console.WriteLine("Winner board found after number " + drawnNumber + " has been drawn.");
						Console.WriteLine(board.ToString());
						return score;
					}
				}
			}

			throw new Exception("Was not able to find a board to contains all drawn numbers!");
		}
		#endregion

		#region Part 2
		/// <summary>
		/// Read all number draw data + board data, and determines which board will win last.
		/// </summary>
		/// <returns>The value of the board that has been declared the last winner.</returns>
		public int LocateScoreOfLastWinningBoard()
		{
			int[] drawnNumbers = ReadDrawnNumbers();
			List<Board> boards = ReadBoards();

			foreach (int drawnNumber in drawnNumbers)
			{
				// As board references will be removed as they win, iteration is always performed backwards
				for (int boardIndex = boards.Count - 1; boardIndex >= 0; boardIndex--)
				{
					int score = boards[boardIndex].CheckNumber(drawnNumber);
					if (score > 0)
					{
						if (boards.Count == 1)
						{
							Console.WriteLine("Winner board found after number " + drawnNumber + " has been drawn.");
							Console.WriteLine(boards[boardIndex].ToString());
							return score;
						}
						else
							boards.RemoveAt(boardIndex);
					}
				}
			}

			throw new Exception("Was not able to find the last winning board!");
		}
		#endregion

		private int[] ReadDrawnNumbers()
		{
			string inputDataDrawnNumbers = Util.ReadInput(day);
			return inputDataDrawnNumbers.Split(',').Select(Int32.Parse).ToArray<int>();
		}

		private List<Board> ReadBoards()
		{
			string inputData = Util.ReadInput(day, "Boards");
			string[] lines = inputData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			List<string> buffer = new List<string>();
			List<Board> boards = new List<Board>();
			int boardCounter = 0;
			foreach (string line in lines)
			{
				if (String.IsNullOrWhiteSpace(line))
				{
					boardCounter++;
					boards.Add(new Board(boardCounter.ToString(), buffer));
					buffer.Clear();
				}
				else
					buffer.Add(line);
			}

			return boards;
		}
	}
}
