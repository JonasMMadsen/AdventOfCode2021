using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Day4
{
	class NumberCell
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="value">The value of the cell/board entry.</param>
		public NumberCell(int value, List<NumberCell> row, int columnIndex)
		{
			this.Value = value;
			this.Row = row;
			this.ColumnIndex = columnIndex;
			this.ValueFound = false;
		}

		/// <summary>
		/// The number value of the this cell/board entry.
		/// </summary>
		public int Value { get; private set; }

		/// <summary>
		/// Reference to the row this number/cell is a part of.
		/// </summary>
		public List<NumberCell> Row { get; private set; }

		/// <summary>
		/// The zero-based index for the column this number is placed in.
		/// </summary>
		public int ColumnIndex { get; private set; }

		/// <summary>
		/// Has this number been drawn and marked as found on this board?
		/// </summary>
		public bool ValueFound { get; set; }
	}
}
