using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    abstract class StaticEnemy : Enemy
    {
        public StaticEnemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate) : base(image, cell, direction, initialRotate)
        {
        }
    }
}
