using System;
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
        private Form form;
        private Player player;
        private GameGrid grid;
        private List<Enemy> enemies;
        private List<Fireable> freeFireables;
        private int score;
        public int Score { get => score; set => score += value; }
        public Player Player { get => player; }
        public List<Enemy> Enemies { get => enemies; }
        public Game(Form form)
        {
            this.form = form;
            grid = new GameGrid("maze.txt", 24, 40);
            player = null;
            enemies = new List<Enemy>();
            freeFireables = new List<Fireable>();
            score = 0;
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
        public void RenderEnemiesBullets()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.MoveFireables();
            }
        }
        public void AddPlayer(int x, int y, Image image)
        {
            GameCell cell = grid.GetCell(x, y);
            player = new Player(image, cell,GameDirection.Left);
        }
        public void RemovePlayer()
        {
            player.CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE,' ');
            player = null;
        }
        public void AddEnemy(Type type, Image image, int x, int y, GameDirection direction)
        {
            Enemy enemy;
            GameCell cell = grid.GetCell(x, y);
            if (type == typeof(Tank))
            {
                enemy = new Tank(image, cell, player,direction);
            }
            else if (type == typeof(Cannon))
            {
                enemy = new Cannon(image, cell, direction);
            }
            else
            {
                enemy = null;
            }
            enemies.Add(enemy);
        }
        public void RemoveEnemy(Enemy enemy)
        {
            foreach(Fireable fireable in enemy.Fireables)
            {
                freeFireables.Add(fireable);
            }
            enemy.Fireables.Clear();
            enemy.CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            enemies.Remove(enemy);
        }
        public void RenderEnemeies()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Render();
                enemy.Fire();
            }
            MoveFreeFireables();
        }
        private void MoveFreeFireables()
        {
            for (int i = 0; i < freeFireables.Count; i++)
            {
                if (!freeFireables[i].Move())
                {
                    freeFireables.RemoveAt(i);
                    i = i - 1;
                }
            }
        }
        public void PlayerControls()
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
            if (KeyBoard.IsKeyPressed(Key.Space))
            {
                player.Fire();
            }
        }
    }
}
