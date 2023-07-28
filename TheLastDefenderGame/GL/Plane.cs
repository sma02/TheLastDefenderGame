using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class Plane : MovableEnemy
    {
        public Plane(Image image, GameCell cell) : base(image, cell)
        {
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override GameCell NextCell()
        {
            throw new NotImplementedException();
        }
    }
}
