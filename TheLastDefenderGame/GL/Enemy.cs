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
        protected Player player;
        protected bool isFiringState;
        public Enemy(Image image,GameCell cell,Player player):base(GameObjectType.ENEMY,image,cell)
        {
            this.image = image;
            CurrentCell = cell;
            this.player = player;
            isFiringState = false;
            bullets = new List<Bullet>();
        }
        public abstract void Move();
        public abstract GameCell NextCell();
        
        public override void Fire()
        {
            if (isFiringState)
            {
                Bullet bullet = new Bullet(CurrentCell.NextCell(direction), direction, bullets);
                bullets.Add(bullet);
            }
        }
    }
}
