using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    abstract class Enemy : Combatant
    {
        protected bool isFiringState;
        public Enemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate) : base(GameObjectType.ENEMY, image, cell, direction, initialRotate)
        {
            isFiringState = false;
        }
        public abstract void Render();
        public override void Fire()
        {
            if (isFiringState)
            {
                Fireable fireable = new Bullet(CurrentCell.NextCell(direction), direction);
                base.fireable.Add(fireable);
            }
        }
    }
}
