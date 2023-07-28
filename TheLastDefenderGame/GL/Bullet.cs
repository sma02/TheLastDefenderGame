using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Bullet : GameObject
    {
        GameDirection direction;
        List<Bullet> bullets;
        public Bullet(GameCell cell,GameDirection direction,List<Bullet> bullets):base(GameObjectType.BULLET,'.')
        {
            this.direction = direction;
            CurrentCell = cell;
            this.bullets = bullets;
            CurrentCell.PictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            SetImageOrientation();
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
        private void SetImageOrientation()
        {
            Image image = (Image)this.CurrentCell.PictureBox.Image.Clone();
            RotateFlipType rotateFlipType;
            if (direction == GameDirection.Up)
            {
                rotateFlipType = RotateFlipType.Rotate270FlipNone;
            }
            else if (direction == GameDirection.Down)
            {
                rotateFlipType = RotateFlipType.Rotate90FlipNone;
            }
            else if (direction == GameDirection.Left)
            {
                rotateFlipType = RotateFlipType.Rotate180FlipNone;
            }
            else
            {
                rotateFlipType = RotateFlipType.RotateNoneFlipNone;
            }
            CurrentCell.PictureBox.Image.RotateFlip(rotateFlipType);
        }
    }
}
