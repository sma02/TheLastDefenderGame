﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLastDefenderGame.GL
{
    class Game
    {
        Form form;
        Player player;
        GameGrid grid;
        public Game(Form form)
        {
            this.form = form;
            grid = new GameGrid("maze.txt", 24,40);
            player = null;
            PrintMaze(grid);
        }
        public void PrintMaze(GameGrid grid)
        {
            for (int y = 0; y < grid.Rows; y++)
            {
                for (int x = 0; x < grid.Cols; x++)
                {
                    form.Controls.Add(grid.GetCell(x, y).PictureBox);
                }
            }
        }
        public void AddPlayer(int x, int y, Image image)
        {
            GameCell cell = grid.GetCell(x, y);
            player = new Player(image, cell);
        }
        public void PlayerMovements()
        {
            if (KeyBoard.IsKeyPressed(Key.UpArrow))
            {
                player.Move(GameDirection.Up);
            }
            else if (KeyBoard.IsKeyPressed(Key.DownArrow))
            {
                player.Move(GameDirection.Down);
            }
            if (KeyBoard.IsKeyPressed(Key.LeftArrow))
            {
                player.Move(GameDirection.Left);
            }
            else if (KeyBoard.IsKeyPressed(Key.RightArrow))
            {
                player.Move(GameDirection.Right);
            }
        }
    }
}
