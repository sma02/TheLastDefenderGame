using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Player : GameObject
    {
        private GameDirection playerFace;
        private Image image;
        public Player(Image image, GameCell cell) : base(GameObjectType.PLAYER, image)
        {
            CurrentCell = cell;
            this.image = image;
            playerFace = GameDirection.Up;
        }
        public void Move(GameDirection direction)
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell(direction);
            SetImageOrientation(direction);
        }
        private void SetImageOrientation(GameDirection direction)
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
        private GameCell NextCell(GameDirection direction)
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                nextCell = CurrentCell;
            }
            return nextCell;
        }
    }
}
