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
        protected List<Fireable> fireables;
        protected GameDirection direction;

        public List<Fireable> Fireables { get => fireables; }
        private int health;
        public int Health { get => health; set => health = value; }
        public Combatant(GameObjectType type, Image image, GameCell cell, GameDirection direction, RotateFlipType initialRotate) : base(cell, type, image, initialRotate)
        {
            this.direction = direction;
            health = 100;
            fireables = new List<Fireable>();
        }
        public void MoveFireables()
        {
            for (int i = 0; i < fireables.Count; i++)
            {
                if (!fireables[i].Move())
                {
                    fireables.RemoveAt(i);
                    i = i - 1;
                }
            }
        }
        public void RemoveFireable(Fireable fireable)
        {
            fireable.CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            fireables.Remove(fireable);
        }
        public abstract void Fire();
    }
}
