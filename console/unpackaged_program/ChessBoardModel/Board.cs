using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        // the size of the board
        public int size { get; set; }

        // 2d array of cell-type
        // comma indicates it will be 2d
        public Cell[,] grid { get; set; }
       
        // constructor
        public Board (int s)
        {
            this.size = s;

            // initialize new 2d array of cell-type, have s rows, each with s values in it
            this.grid = new Cell[s, s];

            // fill the 2d array with new cells, each with unique x and y cords
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    this.grid[i, j] = new Cell(i, j);
                }
            }
        }

        // determine next legal moves
        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            // step 1 - clear all previous legal moves
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    // remove the "isLegalMove" status
                    this.grid[i, j].isLegalNextMove = false;
                    // remove the "isCurrentlyOccupied" status
                    this.grid[i, j].isCurrentlyOccupied = false;
                }
            }

            /* 
             * to mark a square as a possible legal move, you have to get that cell and change the isLegalMove var to true
             * the legal moves are on squares away from the current square, hence the row+x and col+y
            */

            // step 2 - find all legal moves and mark the 

            switch (chessPiece)
            {
                case "Knight":
                    try
                    {
                        this.grid[currentCell.rowNumber + 2, currentCell.columnNumber + 1].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber + 2, currentCell.columnNumber - 1].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber - 2, currentCell.columnNumber + 1].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber - 2, currentCell.columnNumber - 1].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber + 1, currentCell.columnNumber + 2].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber + 1, currentCell.columnNumber - 2].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber - 1, currentCell.columnNumber + 2].isLegalNextMove = true;
                    } catch (Exception) { };
                    try
                    {
                        this.grid[currentCell.rowNumber - 1, currentCell.columnNumber - 2].isLegalNextMove = true;
                    } catch (Exception) { };
                    break;

                case "King":
                    // up down left right
                    this.grid[currentCell.rowNumber + 1, currentCell.columnNumber].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber - 1, currentCell.columnNumber].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber, currentCell.columnNumber + 1].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber, currentCell.columnNumber - 1].isLegalNextMove = true;

                    // diagonals
                    this.grid[currentCell.rowNumber + 1, currentCell.columnNumber + 1].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber + 1, currentCell.columnNumber - 1].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber - 1, currentCell.columnNumber + 1].isLegalNextMove = true;
                    this.grid[currentCell.rowNumber - 1, currentCell.columnNumber - 1].isLegalNextMove = true;
                    break;

                case "Rook":
                    // down
                    for (int i = 1; i <= this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // up
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }
                    break;

                case "Bishop":
                    // top-right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // top-left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // bottom-right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // bottom-left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    break;

                case "Queen":
                    /* HORIZONTAL / VERTICAL */

                    // down
                    for (int i = 1; i <= this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // up
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    /* DIAGONAL */

                    // top-right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // top-left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber - i, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // bottom-right
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber + i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }

                    // bottom-left
                    for (int i = 1; i < this.size; i++)
                    {
                        try
                        {
                            this.grid[currentCell.rowNumber + i, currentCell.columnNumber - i].isLegalNextMove = true;
                        }
                        catch (Exception) { };
                    }
                    break;

                default:
                    // user gave invalid option
                    break;
            }
            grid[currentCell.rowNumber, currentCell.columnNumber].isCurrentlyOccupied = true;
        }
    }
}
