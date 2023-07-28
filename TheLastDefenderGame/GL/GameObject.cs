using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame.GL
{
    public class GameObject
    {
        protected Image _displayImage;
        private char displayCharacter;
        protected GameCell _currentCell;
        protected GameObjectType _gameObjectType;
        public GameObject(GameObject gameObject):this(gameObject.GameObjectType,gameObject.DisplayImage)
        {
        }
        public GameObject(GameObjectType type, Image image)
        {
            GameObjectType = type;
            DisplayImage = image;
        }
        public GameObject(GameObjectType type, char displayCharacter)
        {
            GameObjectType = type;
            DisplayCharacter = displayCharacter;
            switch (displayCharacter)
            {
                case '#':
                    DisplayImage = Resources.Brickwall;
                    break;
                case '.':
                    DisplayImage = Resources.Exhaust_Fire;
                    break;
            }
        }

        public Image DisplayImage { get => _displayImage; set => _displayImage = value; }
        public GameCell CurrentCell
        {
            get => _currentCell;
            set
            {
                _currentCell = value;
                _currentCell.CurrentGameObject = this;
            }
        }
        public GameObjectType GameObjectType { get => _gameObjectType; set => _gameObjectType = value; }
        public char DisplayCharacter { get => displayCharacter; set => displayCharacter = value; }

        public static GameObjectType GetGameObjectType(char displayCharacter)
        {
            switch (displayCharacter)
            {
                case 'P': return GameObjectType.PLAYER;
                case '#': return GameObjectType.WALL;
                case '.': return GameObjectType.BULLET;
                default: return GameObjectType.NONE;
            }
        }
    }
}
