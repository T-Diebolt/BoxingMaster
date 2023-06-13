using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoxingMaster
{
    
    public partial class CreatorScreen : UserControl
    {
        int rS, s, h, aS, p;

        public CreatorScreen()
        {
            InitializeComponent();
            InitializeScreen();
        }

        public void InitializeScreen()
        {
            p = 4;
            rS = s = h = aS = 0;
            RefreshPoints();
        }

        private void rs1_Click(object sender, EventArgs e)
        {
            if(p != 0 && rS == 0)
            {
                rS++;
                p--;
                rs1.BackColor = Color.DarkOrange;
            }
            else if(rS != 0)
            {
                p += rS;
                rS = 0;
                rs1.BackColor = Color.Gray;
                rs2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void rs2_Click(object sender, EventArgs e)
        {
            if(p + rS > 1 && rS != 2)
            {
                p -= (2 - rS);
                rS = 2;
                rs1.BackColor = Color.DarkOrange;
                rs2.BackColor = Color.DarkOrange;
            }
            else if(rS == 2)
            {
                p++;
                rS--;
                rs2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void s1_Click(object sender, EventArgs e)
        {
            if (p != 0 && s == 0)
            {
                s++;
                p--;
                s1.BackColor = Color.DarkOrange;
            }
            else if (s != 0)
            {
                p += s;
                s = 0;
                s1.BackColor = Color.Gray;
                s2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void s2_Click(object sender, EventArgs e)
        {
            if (p + s > 1 && s != 2)
            {
                p -= (2 - s);
                s = 2;
                s1.BackColor = Color.DarkOrange;
                s2.BackColor = Color.DarkOrange;
            }
            else if (s == 2)
            {
                p++;
                s--;
                s2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void h1_Click(object sender, EventArgs e)
        {
            if (p != 0 && h == 0)
            {
                h++;
                p--;
                h1.BackColor = Color.DarkOrange;
            }
            else if (h != 0)
            {
                p += h;
                h = 0;
                h1.BackColor = Color.Gray;
                h2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void h2_Click(object sender, EventArgs e)
        {
            if (p + h > 1 && h != 2)
            {
                p -= (2 - h);
                h = 2;
                h1.BackColor = Color.DarkOrange;
                h2.BackColor = Color.DarkOrange;
            }
            else if (h == 2)
            {
                p++;
                h--;
                h2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void as1_Click(object sender, EventArgs e)
        {
            if (p != 0 && aS == 0)
            {
                aS++;
                p--;
                as1.BackColor = Color.DarkOrange;
            }
            else if (aS != 0)
            {
                p += aS;
                aS = 0;
                as1.BackColor = Color.Gray;
                as2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void as2_Click(object sender, EventArgs e)
        {
            if (p + aS > 1 && aS != 2)
            {
                p -= (2 - aS);
                aS = 2;
                as1.BackColor = Color.DarkOrange;
                as2.BackColor = Color.DarkOrange;
            }
            else if (aS == 2)
            {
                p++;
                aS--;
                as2.BackColor = Color.Gray;
            }
            RefreshPoints();
        }

        private void RefreshPoints()
        {
            pLabel.Text = $"POINTS     \n{p}            ";
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if(p == 0 && nameInput.Text != "")
            {
                rs1.Visible = rs2.Visible = s1.Visible = s2.Visible = h1.Visible = h2.Visible = as1.Visible = as2.Visible = rsLabel.Visible = sLabel.Visible = hLabel.Visible = asLabel.Visible
                    = pLabel.Visible = nameLabel.Visible = nameInput.Visible = createButton.Visible = avatarImage.Visible = false;
                headerLabel.Visible = yesButton.Visible = noButton.Visible = true;

                
                

            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            SaveScreen.select = false;
            SaveScreen.n = nameInput.Text;
            SaveScreen.rS = rS;
            SaveScreen.s = s;
            SaveScreen.h = 500 + 50 * h;
            SaveScreen.aS = aS;
            
            Form1.ChangeScreen(this, new SaveScreen());
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            int i = (Form1.pFocus - 1) * 4;
            GameScreen.n[i / 4] = nameInput.Text;
            GameScreen.cp[i] = rS;
            GameScreen.cp[i + 1] = s;
            GameScreen.cp[i + 2] = 500 + 50 * h;
            GameScreen.cp[i + 3] = aS;
            if (Form1.pFocus == 2) { Form1.ChangeScreen(this, new GameScreen()); }
            else
            {
                Form1.pFocus = 2;
                Form1.ChangeScreen(this, new CharacterChoice());
            }
        }

    }
}
