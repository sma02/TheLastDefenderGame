using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class CannonBall : Fireable
    {
        public CannonBall(GameCell cell, Combatant owningCombatant, GameDirection direction) : base(cell, owningCombatant, direction, Resources.cannon_ball, RotateFlipType.RotateNoneFlipNone)
        {
        }
    }
}
