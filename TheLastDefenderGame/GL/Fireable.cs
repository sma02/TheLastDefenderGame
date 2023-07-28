using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Fireable : RotateableGameObject
    {
        GameDirection direction;
        public Fireable(GameCell cell, GameDirection direction, Image image, RotateFlipType initialRotate) : base(cell, GameObjectType.FIREABLE, image, initialRotate)
        {
            this.direction = direction;
            CurrentCell = cell;
            SetImageOrientation(direction);
        }
        public bool Move()
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell == CurrentCell)
            {
                CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                return false;
            }
            else
            {
                GameCell currentCell = CurrentCell;
                currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                CurrentCell = nextCell;
                SetImageOrientation(direction);
                return true;
            }
        }
    }
}
