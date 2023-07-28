﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class Player : Combatant
    {
        public Player(Image image, GameCell cell, GameDirection direction) : base(GameObjectType.PLAYER, image, cell, direction, RotateFlipType.RotateNoneFlipNone)
        {

        }
        public void Move(GameDirection direction)
        {
            GameCell currentCell = CurrentCell;
            currentCell.CurrentGameObject = new GameObject(GameObjectType.NONE, ' ');
            CurrentCell = NextCell(direction);
            SetImageOrientation(direction);
        }
        private GameCell NextCell(GameDirection direction)
        {
            GameCell nextCell = CurrentCell.NextCell(direction);
            if (nextCell.CurrentGameObject.GameObjectType == GameObjectType.WALL)
            {
                nextCell = CurrentCell;
            }
            this.direction = direction;
            return nextCell;
        }
        public override void Fire()
        {
            Bullet bullet = new Bullet(CurrentCell.NextCell(direction), direction);
            fireable.Add(bullet);
        }
    }
}
