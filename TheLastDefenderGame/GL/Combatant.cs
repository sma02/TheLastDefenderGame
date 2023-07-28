using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public abstract class Combatant : RotateableGameObject
    {
        protected List<Fireable> fireable;
        protected GameDirection direction;
        public Combatant(GameObjectType type, Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate) : base(cell, type, image, initialRotate)
        {
            this.direction = direction;
            fireable = new List<Fireable>();
        }
        public void MoveFireables()
        {
            for (int i = 0; i < fireable.Count; i++)
            {
                if (!fireable[i].Move())
                {
                    fireable.RemoveAt(i);
                    i = i - 1;
                }
            }
        }
        public abstract void Fire();
    }
}
