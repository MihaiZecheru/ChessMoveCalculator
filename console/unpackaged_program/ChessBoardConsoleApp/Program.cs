using System;
using ChessBoardModel;
using ChrisTools;

namespace ChessBoardConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            string response = "continue";
            while (response != "")
            {
                Console.WriteLine("\n------------------------------------------------\n");

                // create the board
                Board board = new Board(8);

                // show the empty chess board
                PrintBoard(board);

                // ask the user for an x and y coordinate where they want the piece to be placed
                Cell currentCell = SetCurrentCell(board);
                currentCell.isCurrentlyOccupied = true;

                // calculate all legal moves for that piece
                board.MarkNextLegalMoves(currentCell, Funcs.CapitalizeFirstLetter(GetPiece()));
                Console.WriteLine("\n------------------------------------------------\n");

                // print the chess board to the console. Use an x for the occupied square, a + for a legal move, and a . for empty cell
                PrintBoard(board);

                Console.Write("Press enter to quit or type something to go again: ");
                response = Console.ReadLine();
            }
        }

        private static string GetPiece()
        {
            string[] valid = { "knight", "bishop", "rook", "queen", "king" };
            string piece;
            do
            {
                Console.Write("Piece to place (Knight, Bishop, Rook, Queen, King): ");
                piece = Funcs.trim(Console.ReadLine().ToLower());
            } while (!valid.Contains(piece));
            return piece;
            
        }

        private static Cell SetCurrentCell(Board board)
        {
            // get x and y coords from user and return those coords' cell location
            Console.WriteLine("Place your piece!");

            bool worked = false;
            int row;
            int col;

            do
            {
                Console.Write("Row of your piece: ");
                worked = int.TryParse(Console.ReadLine(), out row);
                if (!(row > 0 && row <= board.size) && worked) // only mention "the row does not exist" if the user entered an invalid number
                {
                    Console.WriteLine($"The board is only {board.size}x{board.size}. Row does not exist");
                    worked = false;
                }
            } while (!worked);
            row--;

            worked = false;

            do
            {
                Console.Write("Column of your piece: ");
                worked = int.TryParse(Console.ReadLine(), out col);
                if (!(col > 0 && col <= board.size) && worked) // only mention "the row does not exist" if the user entered an invalid number
                {
                    Console.WriteLine($"The board is only {board.size}x{board.size}. Row does not exist");
                    worked = false;
                }
            } while (!worked);
            col--;

            return board.grid[row, col];
        }

        private static void PrintBoard(Board board)
        {
            // draw top of board
            Console.Write("+");
            for (int i = 0; i < board.size; i++)
            {
                Console.Write("-");
            }
            Console.Write("+\n");

            // print the chess board to the console
            for (int i = 0; i < board.size; i++)
            {
                // draw left of board
                Console.Write("|");

                // draw board content
                for (int j = 0; j < board.size; j++)
                {
                    // pretty frame
                    if (j == 0) { Console.Write(""); }

                    // iterate through all cells
                    Cell cell = board.grid[i, j];

                    if (cell.isCurrentlyOccupied)
                    {
                        Console.Write("X"); // symbol for current square
                    } else if (cell.isLegalNextMove)
                    {
                        Console.Write("+"); // symbol for legal move
                    } else
                    {
                        Console.Write("."); // symbol for empty square
                    }
                }
                // draw right of board
                Console.WriteLine("|");
            }

            // draw bottom of board
            Console.Write("+");
            for (int i = 0; i < board.size; i++)
            {
                Console.Write("-");
            }
            Console.Write("+\n");

            // sep
            Console.WriteLine("\n------------------------------------------------\n");
        }
    }
}