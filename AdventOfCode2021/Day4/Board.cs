using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode2021.Day4
{
	/// <summary>
	/// A bingo board, that is initialized using lines of numbers separated but spaces.
	/// Each line must contain the same number count.
	/// 
	/// Each board can be a different size, but only contain a number once. 
	/// </summary>
	class Board
	{
		private List<List<NumberCell>> board;
		private Dictionary<int, NumberCell> allNumbers;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name">Name of the board.</param>
		/// <param name="boardData">Read string data containing lists of numbers, separated by a space.</param>
		public Board(string name, List<string> boardData)
		{
			this.Name = name;
			InitializeBoard(boardData);
		}

		#region Initialize board
		private void InitializeBoard(List<string> boardData)
		{
			board = new List<List<NumberCell>>();
			allNumbers = new Dictionary<int, NumberCell>();
			Regex numberRegex = new Regex(@"\d+", RegexOptions.Compiled);

			foreach (string line in boardData)
			{
				MatchCollection matches = numberRegex.Matches(line);

				if (this.ColumnCount < 1)
					this.ColumnCount = matches.Count;

				// Verify that column count within board is the same
				if (matches.Count != this.ColumnCount)
				{
					string msg = String.Format("Board line contains different number count! Should contain {0} numbers. Numbers found: {1}", this.ColumnCount, matches.Count);
					throw new ArgumentException(msg);
				}

				// Add each number using a dictionary, to ensure duplicates aren't possible, and making it easier to lookup values
				// This could be made simpler, by removing numbers as they are found, but makes it harder to print the full data for winner board.
				List<NumberCell> row = new List<NumberCell>();
				board.Add(row);
				int columnIndex = 0;
				foreach (Match numberMatch in matches)
				{
					int number = Convert.ToInt32(numberMatch.Value);
					NumberCell cell = new NumberCell(number, row, columnIndex++);
					row.Add(cell);
					allNumbers.Add(number, cell);
				}
			}
		}
		#endregion

		#region Properties
		/// <summary>
		/// Name of the board
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// The numbers of rows that this board instance contains.
		/// </summary>
		public int RowCount { get => board.Count; }

		/// <summary>
		/// The number of numbers/columns that each row in this board instance contains.
		/// </summary>
		public int ColumnCount { get; private set; }
		#endregion

		/// <summary>
		/// Check if the drawn number is present on this board, and marks it if found.
		/// If all numbers in the row or column are marked, then this board is a winner.
		/// </summary>
		/// <param name="drawnNumber">The number drawn.</param>
		/// <returns>The score of the board. If this board is a winner, a positive score is returned. Otherwise zero is returned.</returns>
		public int CheckNumber(int drawnNumber)
		{
			if (allNumbers.ContainsKey(drawnNumber))
			{
				NumberCell number = allNumbers[drawnNumber];
				number.ValueFound = true;

				if (IsRowMarked(number.Row))
					return CalculateScore(drawnNumber);

				if (IsColumnMarked(number.ColumnIndex))
					return CalculateScore(drawnNumber);
			}

			return 0;
		}

		#region Check marking
		private bool IsRowMarked(List<NumberCell> row)
		{
			foreach (NumberCell cell in row)
			{
				if (!cell.ValueFound)
					return false;
			}

			return true;
		}

		private bool IsColumnMarked(int columnIndex)
		{
			for (int rowIndex = 0; rowIndex < board.Count; rowIndex++)
			{
				if (!board[rowIndex][columnIndex].ValueFound)
					return false;
			}

			return true;
		}
		#endregion

		/// <summary>
		/// Calculate the score of this board.
		/// The is done by summing all un-drawn numbers, and multiplying it by the last drawn number.
		/// </summary>
		/// <param name="winningNumber">The last drawn number, that made this board the winner.</param>
		/// <returns>The score of this board.</returns>
		private int CalculateScore(int winningNumber)
		{
			// Find the sum of all un-drawn numbers
			int sum = 0;

			// Why doesn't this work?
			//row.Select(cell => !cell.ValueFound ? sum += cell.Value : 0);

			foreach (List<NumberCell> row in board)
			{
				foreach (NumberCell cell in row)
				{
					if (!cell.ValueFound)
						sum += cell.Value;
				}
			}

			return sum * winningNumber;
		}

		public override string ToString()
		{
			StringBuilder builder = new StringBuilder();
			builder.AppendLine("Board " + this.Name);
			foreach (List<NumberCell> row in board)
			{
				// Print the line itself
				builder.AppendLine(String.Join(" ", row.Select(r => r.Value.ToString("D2"))));

				// Print line marking which numbers have been drawn
				builder.AppendLine(String.Join(" ", row.Select(r => r.ValueFound ? "XX" : "  ")));

				// And add as imple spacer line
				builder.AppendLine();
			}

			return builder.ToString();
		}
	}
}
