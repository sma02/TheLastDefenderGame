using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Bullet : RotateableGameObject
    {
        GameDirection direction;
        public Bullet(GameCell cell,GameDirection direction):base(GameObjectType.BULLET,'.')
        {
            this.direction = direction;
            CurrentCell = cell;
            CurrentCell.PictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            SetImageOrientation(direction);
        }
        public bool Move()
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell==CurrentCell)
            {
                CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                return false;
            }
            else
            {
                GameCell currentCell = CurrentCell;
                currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                CurrentCell = nextCell;
                return true;
            }
        }
    }
}
