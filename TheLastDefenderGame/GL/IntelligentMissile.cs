using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class IntelligentMissile : Fireable
    {
        Player player;
        public IntelligentMissile(GameCell cell, Combatant owningCombatant, Player player, GameDirection direction, Image image, RotateFlipType initialRotate, int damagePower = 1) : base(cell, owningCombatant, direction, image, initialRotate, damagePower)
        {
            this.player = player;
        }
        public override GameCell NextCell()
        {
            GameCell nextCell;

            int playerX = player.CurrentCell.X;
            int playerY = player.CurrentCell.Y;
            if (playerY > CurrentCell.Y)
            {
                direction = GameDirection.Down;
            }
            else if (playerY < CurrentCell.Y)
            {
                direction = GameDirection.Up;
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

            }
            if (playerX == CurrentCell.X && playerY == CurrentCell.Y)
            {
                return CurrentCell;
            }
            nextCell = CurrentCell.NextFirableCell(direction);
            return nextCell;

        }
        public void DirectionTowardsPlayer()
        {
            foreach (object value in Enum.GetValues(typeof(GameDirection)))
            {
                if (CurrentCell.NextFirableCell((GameDirection)value).CurrentGameObject.GameObjectType == GameObjectType.PLAYER)
                {
                    direction = (GameDirection)value;
                    return;
                }
            }
        }
    }
}
