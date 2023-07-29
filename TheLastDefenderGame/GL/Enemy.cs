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
        public Enemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate, double strength) : base(GameObjectType.ENEMY, image, cell, direction, initialRotate, strength)
        {
            isFiringState = false;
        }
        public abstract void Render();
        public override void Fire()
        {
            if (isFiringState)
            {
                if (CurrentCell.NextCell(direction).CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    Fireable fireable = AddFire();
                    base.fireables.Add(fireable);
                }
            }
        }
        protected abstract Fireable AddFire();
    }
}
