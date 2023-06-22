using BoxingMaster.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BoxingMaster
{
    public partial class GameScreen : UserControl
    {
        //button bools
        bool upDown, upHit, wDown, wHit;

        #region player creation variables
        Character[] players = new Character[2];
        Bitmap[] playerImages = { Resources.P1rest, Resources.P1punch, Resources.P1perfect, Resources.P1counter, 
            Resources.P2rest, Resources.P2punch, Resources.P2perfect, Resources.P2counter };
        int[] pI = { 0, 0 };
        public static string[] n = new string[2];
        public static int[] cp = new int[8];
        #endregion

        #region coin variables
        Bitmap[] coinImages = { Resources.coin01, Resources.coin02, Resources.coin03, Resources.coin04, Resources.coin05, Resources.coin06, Resources.side1, Resources.side2 };
        int coinV, coinVt, coinY, coinT, coin;
        Random randGen = new Random();
        #endregion

        #region brushes
        Brush redBrush = new SolidBrush(Color.FromArgb(227, 141, 136));
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush yellowBrush = new SolidBrush(Color.FromArgb(238, 214, 107));
        #endregion

        #region gameplay variables
        int attacker,defender, gameTime, attack, defence, outcome, outcomeT, counterT;
        bool action;
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            InitializeScreen();
        }

        public void InitializeScreen()
        {
            for(int i = 0; i < players.Length; i++)
            {
                int ii = i * 4;
                players[i] = new Character(n[i], cp[ii], cp[ii + 1], cp[ii + 2], cp[ii + 3]);
            }

            p1Name.Text = " " + players[0].name;
            p2Name.Text = players[1].name + " ";

            coinEngine.Enabled = true;
            gameEngine.Enabled = false;
            coinV = 17;
            coinY = this.Height - 1;
            coinT = coin = coinVt = 0;
            action = true;
            gameTime = 250;
            defence = attack = -1;
            pI[0] = pI[1] = 0;
            outcomeT = 500;
            counterT = 0;
            defender = attacker = 2;
        }

        private void coinEngine_Tick(object sender, EventArgs e)
        {
            //coin movement
            coinVt++;
            if(coinVt == 3)
            {
                coinVt = 0;
                coinV--;
            }
            coinY -= coinV;

            if(coinT != -1)
            {
                coinT++;
                if (coinT == 5)
                {
                    coinT = 0;
                    if (coin == coinImages.Length - 3) { coin = 0; }
                    else { coin++; }
                }
            }
            

            Refresh();

            //check if coin animation finished
            if(coinY > this.Height && coin > coinImages.Length - 3) 
            { 
                coinEngine.Enabled = false; 
                gameEngine.Enabled = true; 
            }

            //check if change from flipping to solid coin
            if(coinY > this.Height && gameEngine.Enabled == false)
            {
                coinV = 17;
                coinY = this.Height - 1;
                coinT = -1;
                coinVt = 0;
                coin = randGen.Next(coinImages.Length - 2, coinImages.Length);
                attacker = coin - (coinImages.Length - 2);

                if (attacker == 1) { defender = 0; }
                else if (attacker == 0) { defender = 1; }
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if(upDown == false) { upHit = true; }
                    upDown = true;
                    break;
                case Keys.W:
                    if (wDown == false) { wHit = true; }
                    wDown = true;
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.W:
                    wDown = false;
                    break;
            }
        }

        private void gameEngine_Tick(object sender, EventArgs e)
        {
            if (action)
            {
                //round timer
                gameTime--;
                if (gameTime == 0) 
                { 
                    action = false; 
                    if(attack == -1) { attack = -50; }
                    if(defence == -1) { defence = -50; }
                }

                //player movement
                players[attacker].Move(true);
                players[defender].Move(false);

                //player input results
                if (upHit) 
                {
                    if (attacker == 1) { attack = players[1].x + 5; }
                    else { defence = players[1].x +20; }
                }
                if (wHit) 
                { 
                    if(attacker == 0) { attack = players[0].x + 5; }
                    else { defence = players[0].x + 20; }
                }

                //show result ahead of end of round timer if both players have played
                if(defence != -1 && attack != -1)
                {
                    Outcome();
                }
            }
            else
            {
                if(counterT != 0)//countering function
                {
                    counterT--;
                    counterLabel.Visible = true;
                    pI[defender] = 3;
                    if (defender == 0 && wHit)
                    {
                        players[1].health -= 2;
                        var punchSound = new System.Windows.Media.MediaPlayer();
                        punchSound.Open(new Uri(Application.StartupPath + "/Resources/Punch.wav"));
                        punchSound.Play();
                    }
                    else if (defender == 1 && upHit)
                    {
                        players[0].health -= 2;
                        var punchSound = new System.Windows.Media.MediaPlayer();
                        punchSound.Open(new Uri(Application.StartupPath + "/Resources/Punch.wav"));
                        punchSound.Play();
                    }
                    if(defender == 0) { counterLabel.BackColor = Color.White; }
                    else { counterLabel.BackColor = Color.FromArgb(227, 141, 136); }
                    if(counterT == 0) { counterLabel.Visible = false; }
                }
                else//display outcome of round
                {
                    if(outcomeT == 200)
                    {
                        outcomeLabel.Visible = true;
                        if(outcome == 2) { outcomeLabel.Text = "PERFECT"; }
                        else if(outcome == 1) { outcomeLabel.Text = "GOOD"; }
                        else { outcomeLabel.Text = "BLOCKED"; }
                        
                    }
                    
                    outcomeT--;

                    if (outcomeT == 0)
                    {
                        outcomeLabel.Visible = false;
                        pI[0] = pI[1] = 0;
                        action = true;
                        gameTime = 500;
                        defence = attack = -1;
                        players[0].x = players[1].x = 180;
                        if (defender == 0) { defender = 1; attacker = 0; }
                        else { defender = 0; attacker = 1; }

                    }
                }
            }

            //check for end of game
            if (players[0].health < 1)
            {
                gameEngine.Enabled = false;
                GameOverScreen.winner = 2;
                if (players[0].name != players[1].name) { GameOverScreen.winnerName = players[1].name; }
                else { GameOverScreen.winnerName = "P2"; }
                Form1.ChangeScreen(this, new GameOverScreen());
            }
            else if (players[1].health < 1)
            {
                gameEngine.Enabled = false;
                GameOverScreen.winner = 1;
                if (players[0].name != players[1].name) { GameOverScreen.winnerName = players[0].name; }
                else { GameOverScreen.winnerName = "P1"; }
                Form1.ChangeScreen(this, new GameOverScreen());
            }

            //prevent button holding
            upHit = wHit = false;

            Refresh();
        }

        public void Outcome()
        {
            //finds outcome of hit type from attack function
            outcome = players[attacker].Attack(attack, defence, players[defender].reactionSpeed);
            action = false;
            outcomeT = 200;
            //chooses what happens based off of outcome
            if (outcome == 2) 
            { 
                pI[attacker] = 2;
                players[defender].health -= 80;
                var kickSound = new System.Windows.Media.MediaPlayer();
                kickSound.Open(new Uri(Application.StartupPath + "/Resources/Kick.wav"));
                kickSound.Play();
            }
            else if(outcome == 1) 
            { 
                pI[attacker] = 1;
                players[defender].health -= 50;
                var punchSound = new System.Windows.Media.MediaPlayer();
                punchSound.Open(new Uri(Application.StartupPath + "/Resources/Punch.wav"));
                punchSound.Play();
            }
            else
            {
                pI[attacker] = 1;
                counterT = 100 + 25 * players[defender].attackSpeed;
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (coinY < this.Height)
            {
                e.Graphics.DrawImage(coinImages[coin], 420, coinY, 120, 120);
            }

            //draw health bars
            double p1Health = (players[0].health * 10) / (players[0].maxH / 10) * 4.3;
            double p2Health = (players[1].health * 10) / (players[1].maxH / 10) * 4.3;
            e.Graphics.FillRectangle(whiteBrush, 30, 30, Convert.ToInt32(Math.Round(p1Health, 0)), 50);
            e.Graphics.DrawImage(Resources.P1health, 20, 20, 450, 70);
            e.Graphics.FillRectangle(redBrush, 930 - Convert.ToInt32(Math.Round(p2Health, 0)), 30, Convert.ToInt32(Math.Round(p2Health, 0)), 50);
            e.Graphics.DrawImage(Resources.P2health, 490, 20, 450, 70);

            //find width of bars dependant on attacker and defender roles
            int w1 = 0, w2 = 0;
            if (defender == 0) { w1 = 40; w2 = 10; }
            else { w1 = 10; w2 = 40; }
            //draw attack bars
            if (gameEngine.Enabled && action)
            {
                double hX = gameTime / 5 * 1.8;
                e.Graphics.FillRectangle(yellowBrush, 480 - Convert.ToInt32(Math.Round(hX, 0)), 440, Convert.ToInt32(Math.Round(hX, 0)) * 2, 60);
                if(defender == 0) 
                { 
                    e.Graphics.FillRectangle(whiteBrush, 300 + players[0].x - w1 / 2, 440, w1, 60);
                    e.Graphics.FillRectangle(redBrush, 300 + players[1].x - w2 / 2, 440, w2, 60);
                }
                else
                {
                    e.Graphics.FillRectangle(redBrush, 300 + players[1].x - w2 / 2, 440, w2, 60);
                    e.Graphics.FillRectangle(whiteBrush, 300 + players[0].x - w1 / 2, 440, w1, 60);
                }
                e.Graphics.DrawImage(Resources.Battle_Box, 290, 430, 380, 80);

            }

            //draw results
            if (counterT == 0 && action == false)
            {
                e.Graphics.FillRectangle(yellowBrush, 300, 440, 360, 60);
                if (defender == 0)
                {
                    e.Graphics.FillRectangle(whiteBrush, 300 + defence - w2 / 2, 440, w1, 60);
                    e.Graphics.FillRectangle(redBrush, 300 + attack - w1 / 2, 440, w1, 60);
                }
                else
                {
                    e.Graphics.FillRectangle(whiteBrush, 300 + attack - w1 / 2, 440, w1, 60);
                    e.Graphics.FillRectangle(redBrush, 300 + defence - w2 / 2, 440, w2, 60);
                }
                e.Graphics.DrawImage(Resources.Battle_Box, 290, 430, 380, 80);
            }

            //draw players
            e.Graphics.DrawImage(playerImages[pI[0]], 70, 140, 350, 350);
            e.Graphics.DrawImage(playerImages[pI[1] + 4], 540, 140, 350, 350);

        }
    }
}
