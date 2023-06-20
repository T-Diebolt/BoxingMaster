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
    public partial class CharacterChoice : UserControl
    {
        public CharacterChoice()
        {
            InitializeComponent();
            InitializeScreen();
        }

        public void InitializeScreen()
        {
            //display which character's turn it is to select a character
            headerLabel.Text = $"P{Form1.pFocus} SELECT";
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //sends to save screen to load a character
            SaveScreen.select = true;
            Form1.ChangeScreen(this, new SaveScreen());
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            //sends to creator screen to create a new character
            Form1.ChangeScreen(this, new CreatorScreen());
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //goes back to menu screen
            Form1.pFocus = 1;
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
