namespace BoxingMaster
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.p1Name = new System.Windows.Forms.Label();
            this.p2Name = new System.Windows.Forms.Label();
            this.gameEngine = new System.Windows.Forms.Timer(this.components);
            this.coinEngine = new System.Windows.Forms.Timer(this.components);
            this.counterLabel = new System.Windows.Forms.Label();
            this.outcomeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // p1Name
            // 
            this.p1Name.BackColor = System.Drawing.Color.Transparent;
            this.p1Name.Font = new System.Drawing.Font("ROG Fonts", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(141)))), ((int)(((byte)(136)))));
            this.p1Name.Location = new System.Drawing.Point(20, 20);
            this.p1Name.Name = "p1Name";
            this.p1Name.Size = new System.Drawing.Size(450, 70);
            this.p1Name.TabIndex = 0;
            this.p1Name.Text = " NAME01";
            // 
            // p2Name
            // 
            this.p2Name.BackColor = System.Drawing.Color.Transparent;
            this.p2Name.Font = new System.Drawing.Font("ROG Fonts", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2Name.ForeColor = System.Drawing.Color.White;
            this.p2Name.Location = new System.Drawing.Point(490, 20);
            this.p2Name.Name = "p2Name";
            this.p2Name.Size = new System.Drawing.Size(450, 70);
            this.p2Name.TabIndex = 1;
            this.p2Name.Text = "NAME01 ";
            this.p2Name.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gameEngine
            // 
            this.gameEngine.Interval = 20;
            this.gameEngine.Tick += new System.EventHandler(this.gameEngine_Tick);
            // 
            // coinEngine
            // 
            this.coinEngine.Interval = 20;
            this.coinEngine.Tick += new System.EventHandler(this.coinEngine_Tick);
            // 
            // counterLabel
            // 
            this.counterLabel.BackColor = System.Drawing.Color.White;
            this.counterLabel.Font = new System.Drawing.Font("ROG Fonts", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.Location = new System.Drawing.Point(105, 375);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(750, 135);
            this.counterLabel.TabIndex = 2;
            this.counterLabel.Text = "!COUNTER!";
            this.counterLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.counterLabel.Visible = false;
            // 
            // outcomeLabel
            // 
            this.outcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.outcomeLabel.Font = new System.Drawing.Font("ROG Fonts", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outcomeLabel.ForeColor = System.Drawing.Color.Black;
            this.outcomeLabel.Location = new System.Drawing.Point(105, 434);
            this.outcomeLabel.Name = "outcomeLabel";
            this.outcomeLabel.Size = new System.Drawing.Size(750, 79);
            this.outcomeLabel.TabIndex = 3;
            this.outcomeLabel.Text = "MISS";
            this.outcomeLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.outcomeLabel.Visible = false;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoxingMaster.Properties.Resources.Ring;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.outcomeLabel);
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.p2Name);
            this.Controls.Add(this.p1Name);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(960, 540);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label p1Name;
        private System.Windows.Forms.Label p2Name;
        private System.Windows.Forms.Timer gameEngine;
        private System.Windows.Forms.Timer coinEngine;
        private System.Windows.Forms.Label counterLabel;
        private System.Windows.Forms.Label outcomeLabel;
    }
}
