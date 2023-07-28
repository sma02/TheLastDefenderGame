using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    class StaticEnemy : Enemy
    {
        public StaticEnemy(Image image, GameCell cell) : base(image, cell)
        {
        }
    }
}
