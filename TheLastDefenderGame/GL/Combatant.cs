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
        protected List<Bullet> bullets;
        protected GameDirection direction;
        public Combatant(GameObjectType type,Image image, GameCell cell,GameDirection direction) : base(cell,type, image)
        {
            this.direction = direction;
            bullets = new List<Bullet>();
        }
        public void MoveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Move())
                {
                    bullets.RemoveAt(i);
                    i = i - 1;
                }
            }
        }
        public abstract void Fire();
    }
}
