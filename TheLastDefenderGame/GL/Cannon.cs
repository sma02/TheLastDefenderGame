using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class Cannon : StaticEnemy
    {
        const int cooldown = 10;
        int cooldownCount = 0;
        public Cannon(Image image, GameCell cell,GameDirection direction) : base(image, cell,direction)
        {
            SetImageOrientation(direction);
        }
        public override void Render()
        {
            isFiringState = false;
            cooldownCount++;
            if(cooldownCount>=cooldown)
            {
                isFiringState = true;
                cooldownCount = 0;
            }
        }
    }
}
