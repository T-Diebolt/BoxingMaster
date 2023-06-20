using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BoxingMaster
{
    public partial class SaveScreen : UserControl
    {
        List<Character> saves = new List<Character>();
        public static bool select;
        public static string n;
        public static int rS, s, h, aS;

        public SaveScreen()
        {
            InitializeComponent();
            LoadDB();
            InitializeScreen();
        }

        public void LoadDB()
        {
            int reactionSpeed, health, strength, attackSpeed;
            string name;
            saves.Clear();

            XmlReader reader = XmlReader.Create("Resources/SavedCharacters.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    name = reader.ReadString();

                    reader.ReadToNextSibling("rs");
                    reactionSpeed = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("s");
                    strength = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("h");
                    health = Convert.ToInt16(reader.ReadString());

                    reader.ReadToNextSibling("as");
                    attackSpeed = Convert.ToInt16(reader.ReadString());

                    Character newCharacter = new Character(name, reactionSpeed, strength, health, attackSpeed);
                    saves.Add(newCharacter);

                }
            }

            reader.Close();
        }

        public void InitializeScreen()
        {
            save1Button.Text = $"      {saves[0].name}";
            if (saves[0].reactionSpeed == 0)
            {
                rs11.BackColor = Color.Gray;
                rs11.ForeColor = Color.DimGray;
                rs12.BackColor = Color.Gray;
                rs12.ForeColor = Color.DimGray;
            }
            else
            {
                rs11.BackColor = Color.Orange;
                rs11.ForeColor = Color.Peru;
                rs12.BackColor = Color.Gray;
                rs12.ForeColor = Color.DimGray;
                if (saves[0].reactionSpeed == 2)
                {
                    rs12.BackColor = Color.Orange;
                    rs12.ForeColor = Color.Peru;
                }
            }
            if (saves[0].strength == 0)
            {
                s11.BackColor = Color.Gray;
                s11.ForeColor = Color.DimGray;
                s12.BackColor = Color.Gray;
                s12.ForeColor = Color.DimGray;
            }
            else
            {
                s11.BackColor = Color.Orange;
                s11.ForeColor = Color.Peru;
                s12.BackColor = Color.Gray;
                s12.ForeColor = Color.DimGray;
                if (saves[0].strength == 2)
                {
                    s12.BackColor = Color.Orange;
                    s12.ForeColor = Color.Peru;
                }
            }
            if (saves[0].health == 500)
            {
                h11.BackColor = Color.Gray;
                h11.ForeColor = Color.DimGray;
                h12.BackColor = Color.Gray;
                h12.ForeColor = Color.DimGray;
            }
            else
            {
                h11.BackColor = Color.Orange;
                h11.ForeColor = Color.Peru;
                h12.BackColor = Color.Gray;
                h12.ForeColor = Color.DimGray;
                if (saves[0].health == 600)
                {
                    h12.BackColor = Color.Orange;
                    h12.ForeColor = Color.Peru;
                }
            }
            if (saves[0].attackSpeed == 0)
            {
                as11.BackColor = Color.Gray;
                as11.ForeColor = Color.DimGray;
                as12.BackColor = Color.Gray;
                as12.ForeColor = Color.DimGray;
            }
            else
            {
                as11.BackColor = Color.Orange;
                as11.ForeColor = Color.Peru;
                as12.BackColor = Color.Gray;
                as12.ForeColor = Color.DimGray;
                if (saves[0].attackSpeed == 2)
                {
                    as12.BackColor = Color.Orange;
                    as12.ForeColor = Color.Peru;
                }
            }
            save2Button.Text = $"      {saves[1].name}";
            if (saves[1].reactionSpeed == 0)
            {
                rs21.BackColor = Color.Gray;
                rs21.ForeColor = Color.DimGray;
                rs22.BackColor = Color.Gray;
                rs22.ForeColor = Color.DimGray;
            }
            else
            {
                rs21.BackColor = Color.Orange;
                rs21.ForeColor = Color.Peru;
                rs22.BackColor = Color.Gray;
                rs22.ForeColor = Color.DimGray;
                if (saves[1].reactionSpeed == 2)
                {
                    rs22.BackColor = Color.Orange;
                    rs22.ForeColor = Color.Peru;
                }
            }
            if (saves[1].strength == 0)
            {
                s21.BackColor = Color.Gray;
                s21.ForeColor = Color.DimGray;
                s22.BackColor = Color.Gray;
                s22.ForeColor = Color.DimGray;
            }
            else
            {
                s21.BackColor = Color.Orange;
                s21.ForeColor = Color.Peru;
                s22.BackColor = Color.Gray;
                s22.ForeColor = Color.DimGray;
                if (saves[1].strength == 2)
                {
                    s22.BackColor = Color.Orange;
                    s22.ForeColor = Color.Peru;
                }
            }
            if (saves[1].health == 500)
            {
                h21.BackColor = Color.Gray;
                h21.ForeColor = Color.DimGray;
                h22.BackColor = Color.Gray;
                h22.ForeColor = Color.DimGray;
            }
            else
            {
                h21.BackColor = Color.Orange;
                h21.ForeColor = Color.Peru;
                h22.BackColor = Color.Gray;
                h22.ForeColor = Color.DimGray;
                if (saves[1].health == 600)
                {
                    h22.BackColor = Color.Orange;
                    h22.ForeColor = Color.Peru;
                }
            }
            if (saves[1].attackSpeed == 0)
            {
                as21.BackColor = Color.Gray;
                as21.ForeColor = Color.DimGray;
                as22.BackColor = Color.Gray;
                as22.ForeColor = Color.DimGray;
            }
            else
            {
                as21.BackColor = Color.Orange;
                as21.ForeColor = Color.Peru;
                as22.BackColor = Color.Gray;
                as22.ForeColor = Color.DimGray;
                if (saves[1].attackSpeed == 2)
                {
                    as22.BackColor = Color.Orange;
                    as22.ForeColor = Color.Peru;
                }
            }
            save3Button.Text = $"       {saves[2].name}";
            if (saves[2].reactionSpeed == 0)
            {
                rs31.BackColor = Color.Gray;
                rs31.ForeColor = Color.DimGray;
                rs32.BackColor = Color.Gray;
                rs32.ForeColor = Color.DimGray;
            }
            else
            {
                rs31.BackColor = Color.Orange;
                rs31.ForeColor = Color.Peru;
                rs32.BackColor = Color.Gray;
                rs32.ForeColor = Color.DimGray;
                if (saves[2].reactionSpeed == 2)
                {
                    rs32.BackColor = Color.Orange;
                    rs32.ForeColor = Color.Peru;
                }
            }
            if (saves[2].strength == 0)
            {
                s31.BackColor = Color.Gray;
                s31.ForeColor = Color.DimGray;
                s32.BackColor = Color.Gray;
                s32.ForeColor = Color.DimGray;
            }
            else
            {
                s31.BackColor = Color.Orange;
                s31.ForeColor = Color.Peru;
                s32.BackColor = Color.Gray;
                s32.ForeColor = Color.DimGray;
                if (saves[2].strength == 2)
                {
                    s32.BackColor = Color.Orange;
                    s32.ForeColor = Color.Peru;
                }
            }
            if (saves[2].health == 500)
            {
                h31.BackColor = Color.Gray;
                h31.ForeColor = Color.DimGray;
                h32.BackColor = Color.Gray;
                h32.ForeColor = Color.DimGray;
            }
            else
            {
                h31.BackColor = Color.Orange;
                h31.ForeColor = Color.Peru;
                h32.BackColor = Color.Gray;
                h32.ForeColor = Color.DimGray;
                if (saves[2].health == 600)
                {
                    h32.BackColor = Color.Orange;
                    h32.ForeColor = Color.Peru;
                }
            }
            if (saves[2].attackSpeed == 0)
            {
                as31.BackColor = Color.Gray;
                as31.ForeColor = Color.DimGray;
                as32.BackColor = Color.Gray;
                as32.ForeColor = Color.DimGray;
            }
            else
            {
                as31.BackColor = Color.Orange;
                as31.ForeColor = Color.Peru;
                as32.BackColor = Color.Gray;
                as32.ForeColor = Color.DimGray;
                if (saves[2].attackSpeed == 2)
                {
                    as32.BackColor = Color.Orange;
                    as32.ForeColor = Color.Peru;
                }
            }
        }

        private void save1Button_Click(object sender, EventArgs e)
        {
            if (select) { SelectSave(0); }
            else { Save(0); 
                SelectSave(0);
            }
        }

        private void save2Button_Click(object sender, EventArgs e)
        {
            if (select) { SelectSave(1); }
            else { Save(1); SelectSave(1); }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new CharacterChoice());
        }

        private void save3Button_Click(object sender, EventArgs e)
        {
            if (select) { SelectSave(2); }
            else { Save(2); SelectSave(2); }
        }

        public void SelectSave(int s)
        {
            int i = (Form1.pFocus - 1) * 4;
            GameScreen.n[i / 4] = saves[s].name;
            GameScreen.cp[i] = saves[s].reactionSpeed;
            GameScreen.cp[i + 1] = saves[s].strength;
            GameScreen.cp[i + 2] = saves[s].health;
            GameScreen.cp[i + 3] = saves[s].attackSpeed;
            
            if(Form1.pFocus == 2) 
            {
                Form1.ChangeScreen(this, new GameScreen());
            }
            else
            {
                Form1.pFocus = 2;
                Form1.ChangeScreen(this, new CharacterChoice());
            }
        }

        public void Save(int i)
        {
            saves[i] = new Character(n, rS, s, h, aS);

            XmlWriter writer = XmlWriter.Create("Resources/SavedCharacters.xml", null);

            writer.WriteStartElement("characters");
            foreach (Character c in saves)
            {
                writer.WriteStartElement("character");

                writer.WriteElementString("name", c.name);
                writer.WriteElementString("rs", Convert.ToString(c.reactionSpeed));
                writer.WriteElementString("s", Convert.ToString(c.strength));
                writer.WriteElementString("h", Convert.ToString(c.health));
                writer.WriteElementString("as", Convert.ToString(c.attackSpeed));

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();

            saves.Clear();
            LoadDB();
        }
    }
}
