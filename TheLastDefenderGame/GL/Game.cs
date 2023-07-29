using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheLastDefenderGame.Properties;

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
        public int Score { get => score; set => score = value; }
        public Player Player { get => player; }
        public List<Enemy> Enemies { get => enemies; }
        public List<Fireable> FreeFireables { get => freeFireables; }

        public Game(Form form)
        {
            this.form = form;
            grid = new GameGrid("maze.txt", 24, 46);
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
            player = new Player(image, cell, GameDirection.Left);
        }
        public void RemovePlayer()
        {
            DisposeFirables(player);
            player.CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            player = null;
        }
        public void AddEnemy(Type type, Image image, int x, int y, GameDirection direction)
        {
            Enemy enemy;
            GameCell cell = grid.GetCell(x, y);
            if (type == typeof(Tank))
            {
                enemy = new Tank(image, cell, player, direction);
            }
            else if (type == typeof(Cannon))
            {
                enemy = new Cannon(image, cell, direction);
            }
            else if(type==typeof(Interceptor))
            {
                enemy = new Interceptor(image, cell, player, direction);
            }
            else
            {
                enemy = null;
            }
            enemies.Add(enemy);
        }
        private void DisposeFirables(Combatant combatant)
        {
            foreach (Fireable fireable in combatant.Fireables)
            {
                freeFireables.Add(fireable);
            }
            combatant.Fireables.Clear();
        }
        public void RemoveEnemy(Enemy enemy)
        {
            DisposeFirables(enemy);
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
        public void GenerateRandomEnemy()
        {
            int randomEnemyNumber = (new Random()).Next(0, 3);
            int randomX;
            int randomY;
            int direction;
            do
            {
                randomX = (new Random()).Next(grid.Cols);
                randomY = (new Random()).Next(grid.Rows);
            }
            while (grid.GetCell(randomX, randomY).CurrentGameObject.GameObjectType != GameObjectType.NONE);
                direction = (new Random()).Next(Enum.GetValues(typeof(GameDirection)).Length);
            switch (randomEnemyNumber)
            {
                case 0:
                    AddEnemy(typeof(Tank), Resources.EnemyTank, randomX, randomY, (GameDirection)direction);
                    break;
                case 1:
                    AddEnemy(typeof(Cannon), Resources.cannon, randomX, randomY, (GameDirection)direction);
                    break;
                case 2:
                    AddEnemy(typeof(Interceptor), Resources.RL, randomX, randomY, (GameDirection)direction);
                    break;
            }
        }
        private Enemy GetEnemy(GameCell cell)
        {
            return enemies.Find(x => x.CurrentCell.X == cell.X && x.CurrentCell.Y == cell.Y);
        }
        public void HandleCollisions(List<Fireable> fireables)
        {
            for (int i = 0; i < fireables.Count; i++)
            {
                GameCell cell = fireables[i].CurrentCell.NextFirableCell(fireables[i].FiringDirection);
                GameObject collidingObject = cell.CurrentGameObject;
                if (collidingObject.GameObjectType == GameObjectType.PLAYER)
                {
                    /*if (fireables[i].GetType() == typeof(Bullet))
                    {
                        Player.Health -= 5;
                    }
                    else if (fireables[i].GetType() == typeof(CannonBall))
                    {
                        Player.Health -= 10;
                    }*/
                    player.Health -= fireables[i].DamagePower * 100 / player.Strength;
                }
                else
                {
                    if(fireables[i].OwningCombatant.GameObjectType==GameObjectType.PLAYER)
                    {
                        Score += 1;
                    }
                    Enemy enemy = GetEnemy(cell);
                    if (enemy != null)
                    {
                        enemy.Health -= fireables[i].DamagePower * 100 / enemy.Strength;
                        if (enemy.Health <= 0)
                        {
                            RemoveEnemy(enemy);
                        }
                    }
                }
                fireables[i].OwningCombatant.RemoveFireable(fireables[i]);
            }
        }
        private void MoveFreeFireables()
        {
            for (int i = 0; i < freeFireables.Count; i++)
            {
                if (!freeFireables[i].Move())
                {
                    freeFireables.RemoveAt(i);
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
