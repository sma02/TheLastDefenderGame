using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class Cannon : StaticEnemy
    {
        public Cannon(Image image, GameCell cell, GameDirection direction) : base(image, cell, direction, RotateFlipType.RotateNoneFlipNone, 30)
        {
            SetImageOrientation(direction);
            cooldown = 10;
        }
        public override void Render()
        {
            cooldownCount++;
        }

        protected override Fireable AddFire()
        {
            return new Fireable(CurrentCell.NextFirableCell(direction), this, direction, Resources.cannon_ball, RotateFlipType.RotateNoneFlipNone, 8);
        }
    }
}
