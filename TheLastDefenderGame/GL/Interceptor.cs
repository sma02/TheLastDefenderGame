using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    class Interceptor : MovableEnemy
    {
        Player player;
        Point destination;
        int horizontalPetrolling;
        public Interceptor(Image image, GameCell cell, Player player, GameDirection direction) : base(image, cell, direction, RotateFlipType.Rotate90FlipNone, 40)
        {
            this.player = player;
            destination = new Point(cell.X, cell.Y);
            horizontalPetrolling = 1;
            cooldown = 20;
        }

        public override void Move()
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell();
            SetImageOrientation(direction);

        }
        public override GameCell NextCell()
        {
            GameCell nextCell;
            cooldownCount++;
            if (horizontalPetrolling == 1)
            {
                if (destination.X > CurrentCell.X)
                {
                    direction = GameDirection.Right;
                }
                else if (destination.X < CurrentCell.X)
                {
                    direction = GameDirection.Left;
                }
            }
            else
            {
                if (destination.Y > CurrentCell.Y)
                {
                    direction = GameDirection.Down;
                }
                else if (destination.X < CurrentCell.X)
                {
                    direction = GameDirection.Up;
                }
            }
            nextCell = CurrentCell.NextCombatantCell(direction);
            if (distanceDifference(destination.X,CurrentCell.X)<2 && (distanceDifference(destination.Y, CurrentCell.Y) < 2) || nextCell == CurrentCell)
            {
                SetNewDestination();
            }
            return nextCell;
        }
        private int distanceDifference(int a,int b)
        {
            return a > b ? a - b : b - a;
        }
        private void SetNewDestination()
        {
            horizontalPetrolling = (new Random()).Next(1, 3);
            do
            {
                if (horizontalPetrolling == 1)
                {
                    destination.X = (new Random()).Next(CurrentCell.gameGrid.Cols);
                    destination.Y = CurrentCell.Y;
                }
                else
                {
                    destination.X = CurrentCell.X;
                    destination.Y = (new Random()).Next(CurrentCell.gameGrid.Rows);
                }
            }
            while (CurrentCell.gameGrid.GetCell(destination.X, destination.Y).CurrentGameObject.GameObjectType != GameObjectType.NONE);
        }
        protected override Fireable AddFire()
        {
            return new IntelligentMissile(CurrentCell.NextFirableCell(direction), this, player, direction, Resources.Missile_5, RotateFlipType.Rotate90FlipNone, 20);
        }
    }
}
