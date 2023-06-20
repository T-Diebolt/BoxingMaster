namespace BoxingMaster
{
    partial class CharacterChoice
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
            this.createButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.headerLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.Color.Transparent;
            this.createButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.createButton.FlatAppearance.BorderSize = 0;
            this.createButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.createButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createButton.Font = new System.Drawing.Font("ROG Fonts", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.createButton.Image = global::BoxingMaster.Properties.Resources.Button;
            this.createButton.Location = new System.Drawing.Point(355, 180);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(250, 100);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "CREATE";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.Transparent;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.loadButton.FlatAppearance.BorderSize = 0;
            this.loadButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.loadButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("ROG Fonts", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.loadButton.Image = global::BoxingMaster.Properties.Resources.Button;
            this.loadButton.Location = new System.Drawing.Point(355, 305);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(250, 100);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "LOAD";
            this.loadButton.UseVisualStyleBackColor = false;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.Transparent;
            this.headerLabel.Font = new System.Drawing.Font("ROG Fonts", 51.74999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerLabel.Image = global::BoxingMaster.Properties.Resources.Header;
            this.headerLabel.Location = new System.Drawing.Point(30, 30);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(900, 100);
            this.headerLabel.TabIndex = 3;
            this.headerLabel.Text = "P0 SELECT";
            this.headerLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.Transparent;
            this.exitButton.BackgroundImage = global::BoxingMaster.Properties.Resources.exitButton;
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.Color.Transparent;
            this.exitButton.Location = new System.Drawing.Point(882, 462);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 75);
            this.exitButton.TabIndex = 11;
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // CharacterChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BoxingMaster.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.headerLabel);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.createButton);
            this.DoubleBuffered = true;
            this.Name = "CharacterChoice";
            this.Size = new System.Drawing.Size(960, 540);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button exitButton;
    }
}
