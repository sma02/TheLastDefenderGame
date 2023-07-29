using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    public class Player : Combatant
    {

        public Player(Image image, GameCell cell, GameDirection direction) : base(GameObjectType.PLAYER, image, cell, direction, RotateFlipType.RotateNoneFlipNone, 5000)
        {
        }
        public void Move(GameDirection direction)
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell(direction);
            SetImageOrientation(direction);
        }
        private GameCell NextCell(GameDirection direction)
        {
            GameCell nextCell = CurrentCell.NextCombatantCell(direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                nextCell = CurrentCell;
            }
            this.direction = direction;
            return nextCell;
        }
        public override void Fire()
        {
            if (CurrentCell.NextCell(direction).CurrentGameObject.GameObjectType == GameObjectType.NONE)
            {
                Fireable fireable = new Fireable(CurrentCell.NextFirableCell(direction), this, direction, Resources.Exhaust_Fire, RotateFlipType.Rotate90FlipNone, 80);
                fireables.Add(fireable);
            }
        }
    }
}
