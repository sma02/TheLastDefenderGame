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
        protected int cooldownCount;
        protected int cooldown;
        public Enemy(Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate, double strength) : base(GameObjectType.ENEMY, image, cell, direction, initialRotate, strength)
        {
            isFiringState = false;
            cooldown = 10;
            cooldownCount = 0;
        }
        public abstract void Render();
        public override void Fire()
        {
            HandleFiringCooldown();
            if (isFiringState)
            {
                isFiringState = false;
                if (CurrentCell.NextCell(direction).CurrentGameObject.GameObjectType == GameObjectType.NONE)
                {
                    Fireable fireable = AddFire();
                    base.fireables.Add(fireable);
                }
            }
        }
        private void HandleFiringCooldown()
        {
            if (cooldownCount >= cooldown)
            {
                isFiringState = true;
                cooldownCount = 0;
            }
        }
        protected abstract Fireable AddFire();
    }
}
