using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastDefenderGame.GL
{
    public class GameGrid
    {
        private GameCell[,] _cells;
        private int _rows;
        private int _cols;
        public GameGrid(string filename,int rows,int cols)
        {
            _rows = rows;
            _cols = cols;
            _cells = new GameCell[rows, cols];
            readData(filename);
        }

        public int Rows { get => _rows; set => _rows = value; }
        public int Cols { get => _cols; set => _cols = value; }

        private void readData(string filename)
        {
            StreamReader file = new StreamReader(filename);
            string record;
            int row = 0;
            GameCell gameCell;
            GameObjectType type;
            while ((record = file.ReadLine()) != null)
            {
                for (int x = 0; x < _cols; x++)
                {
                    gameCell = new GameCell(x, row, this);
                    type = GameObject.GetGameObjectType(record[x]);
                    gameCell.CurrentGameObject = new GameObject(type, record[x]);
                    _cells[row, x] = gameCell;
                }
                row++;
            }
            file.Close();
        }
        public GameCell GetCell(int x,int y)
        {
            return _cells[y, x];
        }
    }
}
