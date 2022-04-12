using ChessBoardModel;

namespace ChessBoardGUI
{
    public partial class Form1 : Form
    {
        static Board board = CreateBoard();

        // 2d array of buttons whos values are determined by the board var
        public Button[,] grid = new Button[board.size, board.size];

        public Form1()
        {
            InitializeComponent();
            PopulateGrid();
        }

        private static Board CreateBoard()
        {
            int size;

            if (File.Exists("config.txt"))
            {
                bool worked = int.TryParse(File.ReadAllText("config.txt"), out size);
                if (!worked || size > 16) { size = 8; MessageBox.Show("config.txt did not contain a valid size (must be int ≤ 16)"); } // default
            }
            else
            {
                size = 8;
            }

            return new Board(size);
        }

        private void PopulateGrid()
        {
            // all buttons must fit in the panel, so the size of each button is width / amountOfButtons
            int buttonSize = panel1.Width / board.size;

            // make the panel a perfect square
            panel1.Height = panel1.Width;

            // iterate over rows and colums of grid, create buttons, and set their attributes
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // create the button
                    grid[i, j] = new Button();

                    // color the board
                    grid[i, j].BackColor = SetBackgroundColor(i + j);

                    // set button dimensions
                    grid[i, j].Height = buttonSize;
                    grid[i, j].Width = buttonSize;

                    // create click-eventListener for each button
                    grid[i, j].Click += Grid_Button_Click;

                    // place button
                    panel1.Controls.Add(grid[i, j]);

                    // button location ; in c# a point is simply an x and y coordinate
                    grid[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    /*
                     * tag does not show up on the screen but appears in the buttons memory
                     * its like how you can do "data.newAttr = value" in python
                     * where you can set an attr off of any datatype
                     * we are appending location information to each button
                    */

                    // set location attr
                    grid[i, j].Tag = new Point(i, j);

                    // remove border
                    grid[i, j].FlatStyle = FlatStyle.Flat;
                    grid[i, j].FlatAppearance.BorderSize = 1;

                }
            }
        }

        private Color SetBackgroundColor(int v)
        {
            if (v % 2 == 0)
            {
                return Color.Beige;
            }
            return Color.Brown;
        }

        private void Grid_Button_Click(object sender, EventArgs e)
        {
            FindMovesSequence(sender);    
        }

        private void DropdownPiece_Select(object sender, EventArgs e)
        {
            // check to see if there is a piece currently selected
            bool isCellSelected = false;
            Cell selectedCell = null;

            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    if (board.grid[i, j].isCurrentlyOccupied)
                    {
                        isCellSelected = true;
                        selectedCell = board.grid[i, j];
                        break;
                    }
                }
                if (isCellSelected) { break; }
            }

            /* 
                 * the user has selected a cell in the past and tested for a piece's legal moves
                 * but now, the user has changes the piece they want to test
                 * the board will update with the new legal moves, given the already selected location, using the new piece
            */
            if (isCellSelected)
            {
                FindMovesSequence(null, selectedCell);
            }
        }

        private void FindMovesSequence(object sender = null, Cell cell = null)
        {
            // get user piece
            string piece = dropdown_piece.Text;

            if (sender != null)
            {
                // get the row and collumn of the clicked button
                Button clickedButton = (Button)sender; // sender is the object that was clicked
                Point loc = (Point)clickedButton.Tag;

                int x = loc.X;
                int y = loc.Y;

                cell = board.grid[x, y]; // data cell equiv of grid's button
            }

            // determine the next legal moves
            board.MarkNextLegalMoves(cell, piece);

            // update the button text
            for (int i = 0; i < board.size; i++)
            {
                for (int j = 0; j < board.size; j++)
                {
                    // clear the text and color of all cells
                    grid[i, j].Text = "";
                    grid[i, j].BackColor = SetBackgroundColor(i + j);

                    if (board.grid[i, j].isLegalNextMove) // if the location in the data for this cell is marked as a legal move, change the guiGrid data
                    {
                        // display that in the text
                        // grid[i, j].BackColor = Color.Black
                        grid[i, j].Font = new Font(grid[i, j].Font.FontFamily, 20);
                        grid[i, j].Text = "•";
                        continue;
                    }

                    if (board.grid[i, j].isCurrentlyOccupied)
                    {
                        grid[i, j].Font = new Font(grid[i, j].Font.FontFamily, 9, FontStyle.Bold);
                        grid[i, j].BackColor = Color.Green;
                        grid[i, j].Text = (piece != "") ? piece : "Choose Piece"; // ternary operator same as js
                    }
                }
            }
        }
    }
}