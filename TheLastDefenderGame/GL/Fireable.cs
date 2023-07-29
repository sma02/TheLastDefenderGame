using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Fireable : RotateableGameObject
    {
        protected GameDirection direction;
        private Combatant owningCombatant;
        private int damagePower;
        public Combatant OwningCombatant { get => owningCombatant; set => owningCombatant = value; }
        public GameDirection FiringDirection { get => direction; }
        public int DamagePower { get => damagePower; set => damagePower = value; }

        public Fireable(GameCell cell, Combatant owningCombatant, GameDirection direction, Image image, RotateFlipType initialRotate, int damagePower = 1) : base(cell, GameObjectType.FIREABLE, image, initialRotate)
        {
            this.direction = direction;
            this.owningCombatant = owningCombatant;
            CurrentCell = cell;
            this.damagePower = damagePower;
            SetImageOrientation(direction);
        }


        public bool Move()
        {
            GameCell nextCell = NextCell();
            if (nextCell == CurrentCell)
            {
                CurrentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                return false;
            }
            else
            {
                GameObjectType type = nextCell.CurrentGameObject.GameObjectType;
                if (!(type == GameObjectType.PLAYER || type == GameObjectType.ENEMY))
                {
                    GameCell currentCell = CurrentCell;
                    currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
                    CurrentCell = nextCell;
                    SetImageOrientation(direction);
                }
                return true;
            }
        }
        public virtual GameCell NextCell()
        {
            return CurrentCell.NextFirableCell(direction);
        }
    }
}
