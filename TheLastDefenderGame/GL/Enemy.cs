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
        private int health;
        public int Health { get => health; set => health = value; }
        public Enemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate) : base(GameObjectType.ENEMY, image, cell, direction, initialRotate)
        {
            health = 100;
            isFiringState = false;
        }
        public abstract void Render();
        public override void Fire()
        {
            if (isFiringState)
            {
                Fireable fireable = new Bullet(CurrentCell.NextCell(direction), this, direction);
                base.fireables.Add(fireable);
            }
        }
    }
}
