using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class Plane : MovableEnemy
    {
        Player player;
        const int cooldown = 10;
        int cooldownCount = 0;
        public Plane(Image image, GameCell cell, Player player, GameDirection direction) : base(image, cell, direction, RotateFlipType.RotateNoneFlipNone,400)
        {
            this.player = player;
        }

        public override void Move()
        {
            cooldownCount++;
            isFiringState = false;
            if(cooldownCount==20)
            {
                isFiringState = true;
                cooldownCount = 0;
            }
        }

        public override GameCell NextCell()
        {
            return CurrentCell;
        }

        protected override Fireable AddFire()
        {
            return new IntelligentMissile(CurrentCell.NextFirableCell(direction), this, player, direction, Resources.Missile_5, RotateFlipType.Rotate90FlipNone, 200);
        }
    }
}
