using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BoxingMaster
{
    public partial class GameOverScreen : UserControl
    {
        public static int winner = 0;
        public static string winnerName;
        System.Windows.Media.MediaPlayer bellSound = new System.Windows.Media.MediaPlayer();

        public GameOverScreen()
        {
            InitializeComponent();
            InitializeScreen();
            

            Form1.pFocus = 1;
        }

        public void InitializeScreen()
        {
            //displays winner and plays sounds
            bellSound.Open(new Uri(Application.StartupPath + "/Resources/Bell.wav"));
            bellSound.Stop();
            bellSound.Play();
            if (winner == 1)
            {
                headerLabel.Text = $"{winnerName} WINS";
                menuButton1.Visible = rematchButton1.Visible = true;
                menuButton2.Visible = rematchButton2.Visible = false;

            }
            else
            {
                headerLabel.Text = $"{winnerName} WINS";
                menuButton1.Visible = rematchButton1.Visible = false;
                menuButton2.Visible = rematchButton2.Visible = true;
            }
        }

        private void GameOverScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw correct player image
            if(winner == 1)
            {
                e.Graphics.DrawImage(Properties.Resources.P1rest, 100, 137, 400, 400);
            }
            else
            {
                e.Graphics.DrawImage(Properties.Resources.P2rest, 460, 137, 400, 400);
            }
        }

        #region menu + rematch buttons
        private void menuButton2_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void menuButton1_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void rematchButton2_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void rematchButton1_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
