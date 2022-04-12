using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Cell
    {
        public int rowNumber { get; set; }
        public int columnNumber { get; set; }
        public bool isCurrentlyOccupied { get; set; }
        public bool isLegalNextMove { get; set; }

        // constructor
        public Cell(int row, int col)
        {
            rowNumber = row;
            columnNumber = col;
        }
    }
}
