using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheLastDefenderGame.GL;
using TheLastDefenderGame.Properties;

namespace TheLastDefenderGame
{
    public partial class Form1 : Form
    {
        Game game;
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            Image playerImage = Resources.Tank;
            playerImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            game.AddPlayer(2, 2, playerImage);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            game.PlayerMovements();
        }
    }
}
