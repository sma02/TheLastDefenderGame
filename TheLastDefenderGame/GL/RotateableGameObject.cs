using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class RotateableGameObject : GameObject
    {
        protected Image image;
        public RotateableGameObject(GameCell cell, GameObjectType type, Image image, RotateFlipType initialRotate) : base(type, image)
        {
            CurrentCell = cell;
            this.image = image;
            this.image.RotateFlip(initialRotate);
        }
        public RotateableGameObject(GameCell cell, GameObjectType type, char displayCharacter) : base(type, displayCharacter)
        {
            CurrentCell = cell;
            image = CurrentCell.PictureBox.Image;
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
    }
}
