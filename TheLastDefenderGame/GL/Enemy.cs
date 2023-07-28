using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class Enemy : Combatant
    {
        protected bool isFiringState;
        public Enemy(Image image, GameCell cell) : base(GameObjectType.ENEMY, image, cell)
        {
            isFiringState = false;
        }
        public override void Fire()
        {
            if (isFiringState)
            {
                Bullet bullet = new Bullet(CurrentCell.NextCell(direction), direction);
                bullets.Add(bullet);
            }
        }
    }
}
