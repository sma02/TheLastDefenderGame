using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class Tank : MovableEnemy
    {
        private int cooldownCount;
        private const int cooldown = 10;
        private Player player;
        public Tank(Image image, GameCell cell, Player player, GameDirection direction) : base(image, cell, direction,RotateFlipType.Rotate90FlipNone)
        {
            this.player = player;
        }

        public override void Move()
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell();
            SetImageOrientation(direction);

        }
        private void HandleFiringCooldown()
        {
            if (cooldownCount >= cooldown)
            {
                isFiringState = true;
                cooldownCount = 0;
            }
        }
        public override GameCell NextCell()
        {
            GameCell nextCell;
            cooldownCount++;
            int playerX = player.CurrentCell.X;
            int playerY = player.CurrentCell.Y;
            isFiringState = false;
            if (playerY > CurrentCell.Y)
            {
                direction = GameDirection.Down;
                nextCell = CurrentCell.NextCell(GameDirection.Down);
            }
            else if (playerY < CurrentCell.Y)
            {
                direction = GameDirection.Up;
                nextCell = CurrentCell.NextCell(GameDirection.Up);
            }
            else
            {
                if (playerX > CurrentCell.X)
                {
                    direction = GameDirection.Right;
                }
                else
                {
                    direction = GameDirection.Left;
                }
                double distanceX = Math.Sqrt(Math.Abs(playerX - CurrentCell.X));
                if (distanceX > 3.5f)
                {
                    nextCell = CurrentCell.NextCell(direction);
                }
                else if (distanceX < 1.2f)
                {
                    if (direction == GameDirection.Left)
                    {
                        direction = GameDirection.Right;
                    }
                    else
                    {
                        direction = GameDirection.Left;
                    }
                    nextCell = CurrentCell.NextCell(direction);
                }
                else
                {
                    nextCell = CurrentCell;
                    HandleFiringCooldown();
                }

            }
            return nextCell;
        }
    }
}