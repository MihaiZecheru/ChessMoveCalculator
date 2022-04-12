// this file was written automatically by the windows forms designer tab, except for line 61 where I added my own event listener

namespace ChessBoardGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_instructions = new System.Windows.Forms.Label();
            this.dropdown_piece = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl_instructions
            // 
            this.lbl_instructions.AutoSize = true;
            this.lbl_instructions.Location = new System.Drawing.Point(12, 11);
            this.lbl_instructions.Name = "lbl_instructions";
            this.lbl_instructions.Size = new System.Drawing.Size(398, 15);
            this.lbl_instructions.TabIndex = 0;
            this.lbl_instructions.Text = "Select a piece and click on a square to get all possible moves for that piece";
            // 
            // dropdown_piece
            // 
            this.dropdown_piece.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dropdown_piece.FormattingEnabled = true;
            this.dropdown_piece.Items.AddRange(new object[] {
            "Knight",
            "Bishop",
            "Rook",
            "Queen",
            "King"});
            this.dropdown_piece.Location = new System.Drawing.Point(416, 8);
            this.dropdown_piece.Name = "dropdown_piece";
            this.dropdown_piece.Size = new System.Drawing.Size(96, 23);
            this.dropdown_piece.TabIndex = 1;
            this.dropdown_piece.SelectedIndexChanged += DropdownPiece_Select;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 548);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dropdown_piece);
            this.Controls.Add(this.lbl_instructions);
            this.Name = "Form1";
            this.Text = "Chess Board Move Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_instructions;
        private ComboBox dropdown_piece;
        private Panel panel1;
    }
}