using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheLastDefenderGame
{
    public partial class Game_Over : UserControl
    {
        public int Score { set => labelScore.Text = "Score: " + value.ToString(); }
        public Game_Over()
        {
            InitializeComponent();
        }
    }
}
