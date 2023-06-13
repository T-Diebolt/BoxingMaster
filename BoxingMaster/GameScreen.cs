﻿using BoxingMaster.Properties;
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

namespace BoxingMaster
{
    public partial class GameScreen : UserControl
    {
        bool upDown, upHit, wDown, wHit;
        
        Character[] players = new Character[2];
        Bitmap[] playerImages = { Resources.P1rest, Resources.P1punch, Resources.P1perfect, Resources.P1counter, 
            Resources.P2rest, Resources.P2punch, Resources.P2perfect, Resources.P2counter };
        int[] pI = { 0, 0 };
        public static string[] n = new string[2];
        public static int[] cp = new int[8];
        Bitmap[] coinImages = { Resources.coin01, Resources.coin02, Resources.coin03, Resources.coin04, Resources.coin05, Resources.coin06, Resources.side1, Resources.side2 };
        int coinV, coinVt, coinY, coinT, coin;
        Random randGen = new Random();
        
        Brush redBrush = new SolidBrush(Color.FromArgb(227, 141, 136));
        Brush whiteBrush = new SolidBrush(Color.White);
        Brush yellowBrush = new SolidBrush(Color.FromArgb(238, 214, 107));

        int attacker,defender, gameTime, attack, defence, outcome, outcomeT, counterT;
        bool action;

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
        }

        private void coinEngine_Tick(object sender, EventArgs e)
        {
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

            if(coinY > this.Height && coin > coinImages.Length - 3) 
            { 
                coinEngine.Enabled = false; 
                gameEngine.Enabled = true; 
            }

            if(coinY > this.Height)
            {
                coinV = 17;
                coinY = this.Height - 1;
                coinT = -1;
                coinVt = 0;
                coin = randGen.Next(coinImages.Length - 2, coinImages.Length);
                defender = coin - (coinImages.Length - 2);

                if (defender == 1) { attacker = 0; }
                else { attacker = 1; }
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
                gameTime--;
                if (gameTime == 0) 
                { 
                    action = false; 
                    if(attack == -1) { attack = -50; }
                    if(defence == -1) { defence = -50; }
                }

                players[attacker].Move(true);
                players[defender].Move(false);

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

                if(defence != -1 && attack != -1)
                {
                    Outcome();
                }
            }
            else
            {
                if(counterT != 0)
                {
                    counterT--;
                    counterLabel.Visible = true;
                    pI[defender] = 3;
                    if (defender == 0 && wHit)
                    {
                        players[1].health -= 2;
                    }
                    else if (defender == 1 && upHit)
                    {
                        players[0].health -= 2;
                    }
                    if(defender == 0) { counterLabel.BackColor = Color.White; }
                    else { counterLabel.BackColor = Color.FromArgb(227, 141, 136); }
                    if(counterT == 0) { counterLabel.Visible = false; }
                }
                else
                {
                    if(outcomeT == 250)
                    {
                        //TO DO play sound

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



            //stop holding
            upHit = wHit = false;

            Refresh();
        }

        public void Outcome()
        {
            outcome = players[attacker].Attack(attack, defence, players[defender].reactionSpeed);
            action = false;
            outcomeT = 200;
            if (outcome == 2) 
            { 
                pI[attacker] = 2;
                players[defender].health -= 80;
            }
            else if(outcome == 1) 
            { 
                pI[attacker] = 1;
                players[defender].health -= 50;
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
                    e.Graphics.FillRectangle(whiteBrush, 300 + defence - w1 / 2, 440, w1, 60);
                    e.Graphics.FillRectangle(redBrush, 300 + attack - w2 / 2, 440, w2, 60);
                }
                else
                {
                    e.Graphics.FillRectangle(redBrush, 300 + defence, 440, 20, 60);
                    e.Graphics.FillRectangle(whiteBrush, 300 + attack, 440, 20, 60);
                }
                e.Graphics.DrawImage(Resources.Battle_Box, 290, 430, 380, 80);
            }

            //draw players
            e.Graphics.DrawImage(playerImages[pI[0]], 70, 140, 350, 350);
            e.Graphics.DrawImage(playerImages[pI[1] + 4], 540, 140, 350, 350);

        }
    }
}
