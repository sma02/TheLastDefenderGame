using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLastDefenderGame.GL
{
    public class GameCell
    {
        private int _x;
        private int _y;
        private GameObject _currentGameObject;
        private GameGrid _gameGrid;
        private PictureBox _pictureBox;

        public int X { get => _x; set => _x = value; }
        public int Y { get => _y; set => _y = value; }
        public GameObject CurrentGameObject
        {
            get => _currentGameObject;
            set
            {
                _currentGameObject = value;
                _pictureBox.Image = value.DisplayImage;
            }
        }
        public GameGrid gameGrid { get => _gameGrid; set => _gameGrid = value; }
        public PictureBox PictureBox { get => _pictureBox; set => _pictureBox = value; }

        public GameCell(int x, int y, GameGrid gameGrid)
        {
            _x = x;
            _y = y;
            _gameGrid = gameGrid;
            const int width = 5 * 3;
            const int height = 5 * 3;
            _pictureBox = new PictureBox();
            _pictureBox.Left = x * width;
            _pictureBox.Top = y * height;
            _pictureBox.Size = new Size(width, height);
            _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            _pictureBox.BackColor = Color.Transparent;
        }
        public GameCell(GameCell cell) :this(cell.X,cell.Y,cell.gameGrid)
        {
            CurrentGameObject = cell.CurrentGameObject;
        }
        public GameCell NextCell(GameDirection gameDirection)
        {
            GameCell cell = null;
            switch (gameDirection)
            {
                case GameDirection.Up:
                    if (_y > 0)
                    {
                        cell = gameGrid.GetCell(_x, _y - 1);
                    }
                    break;
                case GameDirection.Down:
                    if (_y < gameGrid.Rows - 1)
                    {
                        cell = gameGrid.GetCell(_x, _y + 1);
                    }
                    break;
                case GameDirection.Left:
                    if (_x > 0)
                    {
                        cell = gameGrid.GetCell(_x - 1, _y);
                    }
                    break;
                case GameDirection.Right:
                    if (_x < gameGrid.Cols - 1)
                    {
                        cell = gameGrid.GetCell(_x + 1, _y);
                    }
                    break;
            }
            GameObjectType objectType = cell.CurrentGameObject.GameObjectType;
            if (cell == null || objectType == GameObjectType.WALL|| objectType == GameObjectType.ENEMY|| objectType == GameObjectType.PLAYER)
            {
                return this;
            }
            return cell;
        }
    }
}
