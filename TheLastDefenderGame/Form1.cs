using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheLastDefenderGame.GL;

namespace TheLastDefenderGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GameGrid grid = new GameGrid("maze.txt", 10, 10);
            PrintMaze(grid);
        }
        private void PrintMaze(GameGrid grid)
        {
            for(int y=0;y<grid.Rows;y++)
            {
                for(int x=0;x<grid.Cols;x++)
                {
                    Controls.Add(grid.GetCell(x, y).PictureBox);
                }
            }
        }
    }
}
