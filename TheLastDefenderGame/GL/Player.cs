using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Player : GameObject
    {
        public Player(Image image,GameCell cell):base(GameObjectType.PLAYER,image)
        {
            CurrentCell = cell;
        }
        public void Move(GameDirection direction)
        {
            CurrentCell = NextCell(direction);
        }
        private GameCell NextCell(GameDirection direction)
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if(nextCell.CurrentGameObject.GameObjectType==GameObjectType.WALL)
            {
                nextCell = CurrentCell;
            }
            return nextCell;
        }
    }
}
