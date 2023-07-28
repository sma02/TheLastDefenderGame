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
            playerImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            game.AddPlayer(2, 2, playerImage);
            game.AddEnemy(typeof(Tank), Resources.EnemyTank, 4, 4,GameDirection.Left);
            game.AddEnemy(typeof(Cannon), Resources.cannon, 14, 8,GameDirection.Down);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            game.PlayerControls();
            game.Player.MoveFireables();
            game.RenderEnemeies();
            game.RenderEnemiesBullets();
        }
    }
}
