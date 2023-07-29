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
        private Game game;
        private GameCollider collider;
        public int Score { set => labelScore.Text = value.ToString(); }
        public double Health { set => labelHealth.Text = value.ToString(); }
        public Form1()
        {
            InitializeComponent();
            game = new Game(this);
            collider = new GameCollider(game);
            Image playerImage = Resources.Tank;
            playerImage.RotateFlip(RotateFlipType.Rotate180FlipNone);
            game.AddPlayer(2, 2, playerImage);
            game.AddEnemy(typeof(Tank), Resources.EnemyTank, 30, 20, GameDirection.Left);
            game.AddEnemy(typeof(Plane), Resources.T_20, 20,10, GameDirection.Left);
            game.AddEnemy(typeof(Cannon), Resources.cannon, 14, 8, GameDirection.Down);
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            return true;
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            game.RenderEnemeies();
            game.RenderEnemiesBullets();
            Score = game.Score;
            if (game.Player?.Health > 0)
            {
            Health = game.Player.Health;
            List<Fireable> fireables = collider.CollidingFirables();
            game.HandleCollisions(fireables);
                game.PlayerControls();
                game.Player.MoveFireables();
            }
            else if (game.Player != null)
            {
                game.RemovePlayer();
            }
        }
    }
}
