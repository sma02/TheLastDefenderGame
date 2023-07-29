using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    abstract class MovableEnemy : Enemy
    {
        public MovableEnemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate, double strength = 1) : base(image, cell, direction, initialRotate,strength)
        {
        }
        public override void Render()
        {
            Move();
        }
        public abstract void Move();
        public abstract GameCell NextCell();

    }
}
