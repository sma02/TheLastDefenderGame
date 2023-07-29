using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class Plane : MovableEnemy
    {
        Player player;
        const int cooldown = 20;
        int cooldownCount = 0;
        public Plane(Image image, GameCell cell, Player player, GameDirection direction) : base(image, cell, direction, RotateFlipType.Rotate90FlipNone, 400)
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
                double distanceY = Math.Sqrt(Math.Abs(playerY - CurrentCell.Y));
                if (distanceY > 2.4f && distanceX > 2.4f)
                {
                    nextCell = CurrentCell.NextCombatantCell(direction);
                }
                else if (distanceY < 1.8f && distanceX < 1.8f)
                {
                    if (distanceX < 1.8f)
                    {
                        if (direction == GameDirection.Left)
                        {
                            direction = GameDirection.Right;
                        }
                        else
                        {
                            direction = GameDirection.Left;
                        }
                    }
                    else if (distanceY < 1.8f)
                    {
                        if (direction == GameDirection.Up)
                        {
                            direction = GameDirection.Down;
                        }
                        else
                        {
                            direction = GameDirection.Up;
                        }
                    }
                    nextCell = CurrentCell.NextCombatantCell(direction);
                }
                else
                {
                    nextCell = CurrentCell;
                    HandleFiringCooldown();
                }

            }
            return nextCell;
        }

        protected override Fireable AddFire()
        {
            return new IntelligentMissile(CurrentCell.NextFirableCell(direction), this, player, direction, Resources.Missile_5, RotateFlipType.Rotate90FlipNone, 200);
        }
    }
}
