using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class Tank : MovableEnemy
    {
        private Player player;
        public Tank(Image image, GameCell cell, Player player, GameDirection direction) : base(image, cell, direction, RotateFlipType.Rotate90FlipNone, 300)
        {
            this.player = player;
            cooldown = 10;
        }

        public override void Move()
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell();
            SetImageOrientation(direction);

        }
        public override GameCell NextCell()
        {
            GameCell nextCell;
            cooldownCount++;
            int playerX = player.CurrentCell.X;
            int playerY = player.CurrentCell.Y;
            if (playerY > CurrentCell.Y)
            {
                direction = GameDirection.Down;
                nextCell = CurrentCell.NextCombatantCell(GameDirection.Down);
            }
            else if (playerY < CurrentCell.Y)
            {
                direction = GameDirection.Up;
                nextCell = CurrentCell.NextCombatantCell(GameDirection.Up);
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
                    nextCell = CurrentCell.NextCombatantCell(direction);
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
                    nextCell = CurrentCell.NextCombatantCell(direction);
                }
                else
                {
                    nextCell = CurrentCell;
                }
            }
            return nextCell;
        }

        protected override Fireable AddFire()
        {
            return new Fireable(CurrentCell.NextFirableCell(direction), this, direction, Resources.Exhaust_Fire, RotateFlipType.Rotate90FlipNone, 15);
        }
    }
}