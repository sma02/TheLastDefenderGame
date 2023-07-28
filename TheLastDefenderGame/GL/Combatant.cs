using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public abstract class Combatant : GameObject
    {
        protected List<Bullet> bullets;
        protected Image image;
        protected GameDirection direction;
        public Combatant(GameObjectType type,Image image, GameCell cell) : base(type, image)
        {
            CurrentCell = cell;
            this.image = image;
            bullets = new List<Bullet>();
        }
        protected void SetImageOrientation(GameDirection direction)
        {
            CurrentCell.PictureBox.Image = (Image)image.Clone();
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
        public void MoveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Move())
                {
                    bullets.RemoveAt(i);
                    i = i - 1;
                }
            }
        }
        public abstract void Fire();
    }
}
