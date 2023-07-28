using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    public class Bullet : Fireable
    {
        public Bullet(GameCell cell, GameDirection direction) : base(cell, direction,Resources.Exhaust_Fire,RotateFlipType.Rotate90FlipNone)
        {
        }
    }
}
