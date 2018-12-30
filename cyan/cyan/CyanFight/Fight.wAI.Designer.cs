namespace CyanFight
{
    partial class Fight
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fight));
            this.flpMoves = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pbPlayersPokemon = new System.Windows.Forms.PictureBox();
            this.gbFightScreen = new System.Windows.Forms.GroupBox();
            this.gbEnemyPokemon = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblEnemyCurrentE = new System.Windows.Forms.Label();
            this.pbEnemyPokemonHealth = new System.Windows.Forms.ProgressBar();
            this.EnemyMaxE = new System.Windows.Forms.Label();
            this.lblEnemyPokemonLevel = new System.Windows.Forms.Label();
            this.gbPlayerPokemon = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentE = new System.Windows.Forms.Label();
            this.lblPlayerMaxE = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbPlayerHealth = new System.Windows.Forms.ProgressBar();
            this.lblPlayerLevel = new System.Windows.Forms.Label();
            this.pbEnemyPokemon = new System.Windows.Forms.PictureBox();
            this.tmrWriter = new System.Windows.Forms.Timer(this.components);
            this.tmrWaiter = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayersPokemon)).BeginInit();
            this.gbFightScreen.SuspendLayout();
            this.gbEnemyPokemon.SuspendLayout();
            this.gbPlayerPokemon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyPokemon)).BeginInit();
            this.SuspendLayout();
            // 
            // flpMoves
            // 
            this.flpMoves.Location = new System.Drawing.Point(590, 365);
            this.flpMoves.Name = "flpMoves";
            this.flpMoves.Size = new System.Drawing.Size(308, 138);
            this.flpMoves.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblText);
            this.groupBox1.Location = new System.Drawing.Point(12, 365);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(572, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblText
            // 
            this.lblText.Font = new System.Drawing.Font("Myanmar Text", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblText.Location = new System.Drawing.Point(35, 48);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(510, 47);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "example";
            // 
            // pbPlayersPokemon
            // 
            this.pbPlayersPokemon.BackColor = System.Drawing.Color.Transparent;
            this.pbPlayersPokemon.Location = new System.Drawing.Point(38, 159);
            this.pbPlayersPokemon.Name = "pbPlayersPokemon";
            this.pbPlayersPokemon.Size = new System.Drawing.Size(343, 260);
            this.pbPlayersPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlayersPokemon.TabIndex = 2;
            this.pbPlayersPokemon.TabStop = false;
            // 
            // gbFightScreen
            // 
            this.gbFightScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gbFightScreen.BackgroundImage")));
            this.gbFightScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gbFightScreen.Controls.Add(this.gbEnemyPokemon);
            this.gbFightScreen.Controls.Add(this.gbPlayerPokemon);
            this.gbFightScreen.Controls.Add(this.pbEnemyPokemon);
            this.gbFightScreen.Controls.Add(this.pbPlayersPokemon);
            this.gbFightScreen.Location = new System.Drawing.Point(12, 12);
            this.gbFightScreen.Name = "gbFightScreen";
            this.gbFightScreen.Size = new System.Drawing.Size(886, 347);
            this.gbFightScreen.TabIndex = 3;
            this.gbFightScreen.TabStop = false;
            this.gbFightScreen.Enter += new System.EventHandler(this.gbFightScreen_Enter);
            // 
            // gbEnemyPokemon
            // 
            this.gbEnemyPokemon.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gbEnemyPokemon.Controls.Add(this.label8);
            this.gbEnemyPokemon.Controls.Add(this.label7);
            this.gbEnemyPokemon.Controls.Add(this.label2);
            this.gbEnemyPokemon.Controls.Add(this.lblEnemyCurrentE);
            this.gbEnemyPokemon.Controls.Add(this.pbEnemyPokemonHealth);
            this.gbEnemyPokemon.Controls.Add(this.EnemyMaxE);
            this.gbEnemyPokemon.Controls.Add(this.lblEnemyPokemonLevel);
            this.gbEnemyPokemon.Font = new System.Drawing.Font("Myanmar Text", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbEnemyPokemon.Location = new System.Drawing.Point(38, 19);
            this.gbEnemyPokemon.Name = "gbEnemyPokemon";
            this.gbEnemyPokemon.Size = new System.Drawing.Size(339, 82);
            this.gbEnemyPokemon.TabIndex = 4;
            this.gbEnemyPokemon.TabStop = false;
            this.gbEnemyPokemon.Text = "Enemy Pokemon Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Energy :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "HP:";
            // 
            // lblEnemyCurrentE
            // 
            this.lblEnemyCurrentE.AutoSize = true;
            this.lblEnemyCurrentE.Location = new System.Drawing.Point(214, 50);
            this.lblEnemyCurrentE.Name = "lblEnemyCurrentE";
            this.lblEnemyCurrentE.Size = new System.Drawing.Size(87, 21);
            this.lblEnemyCurrentE.TabIndex = 4;
            this.lblEnemyCurrentE.Text = "Current E";
            // 
            // pbEnemyPokemonHealth
            // 
            this.pbEnemyPokemonHealth.Location = new System.Drawing.Point(68, 24);
            this.pbEnemyPokemonHealth.Name = "pbEnemyPokemonHealth";
            this.pbEnemyPokemonHealth.Size = new System.Drawing.Size(265, 23);
            this.pbEnemyPokemonHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbEnemyPokemonHealth.TabIndex = 1;
            // 
            // EnemyMaxE
            // 
            this.EnemyMaxE.AutoSize = true;
            this.EnemyMaxE.Location = new System.Drawing.Point(271, 50);
            this.EnemyMaxE.Name = "EnemyMaxE";
            this.EnemyMaxE.Size = new System.Drawing.Size(60, 21);
            this.EnemyMaxE.TabIndex = 3;
            this.EnemyMaxE.Text = "Max E";
            // 
            // lblEnemyPokemonLevel
            // 
            this.lblEnemyPokemonLevel.AutoSize = true;
            this.lblEnemyPokemonLevel.Location = new System.Drawing.Point(253, 0);
            this.lblEnemyPokemonLevel.Name = "lblEnemyPokemonLevel";
            this.lblEnemyPokemonLevel.Size = new System.Drawing.Size(53, 21);
            this.lblEnemyPokemonLevel.TabIndex = 0;
            this.lblEnemyPokemonLevel.Text = "Level";
            // 
            // gbPlayerPokemon
            // 
            this.gbPlayerPokemon.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gbPlayerPokemon.Controls.Add(this.label4);
            this.gbPlayerPokemon.Controls.Add(this.label3);
            this.gbPlayerPokemon.Controls.Add(this.lblCurrentE);
            this.gbPlayerPokemon.Controls.Add(this.lblPlayerMaxE);
            this.gbPlayerPokemon.Controls.Add(this.label1);
            this.gbPlayerPokemon.Controls.Add(this.pbPlayerHealth);
            this.gbPlayerPokemon.Controls.Add(this.lblPlayerLevel);
            this.gbPlayerPokemon.Font = new System.Drawing.Font("Myanmar Text", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbPlayerPokemon.Location = new System.Drawing.Point(541, 255);
            this.gbPlayerPokemon.Name = "gbPlayerPokemon";
            this.gbPlayerPokemon.Size = new System.Drawing.Size(339, 82);
            this.gbPlayerPokemon.TabIndex = 4;
            this.gbPlayerPokemon.TabStop = false;
            this.gbPlayerPokemon.Text = "Players Pokemon Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Energy :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "/";
            // 
            // lblCurrentE
            // 
            this.lblCurrentE.AutoSize = true;
            this.lblCurrentE.Location = new System.Drawing.Point(196, 50);
            this.lblCurrentE.Name = "lblCurrentE";
            this.lblCurrentE.Size = new System.Drawing.Size(87, 21);
            this.lblCurrentE.TabIndex = 4;
            this.lblCurrentE.Text = "Current E";
            // 
            // lblPlayerMaxE
            // 
            this.lblPlayerMaxE.AutoSize = true;
            this.lblPlayerMaxE.Location = new System.Drawing.Point(253, 50);
            this.lblPlayerMaxE.Name = "lblPlayerMaxE";
            this.lblPlayerMaxE.Size = new System.Drawing.Size(60, 21);
            this.lblPlayerMaxE.TabIndex = 3;
            this.lblPlayerMaxE.Text = "Max E";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "HP:";
            // 
            // pbPlayerHealth
            // 
            this.pbPlayerHealth.Location = new System.Drawing.Point(68, 24);
            this.pbPlayerHealth.Name = "pbPlayerHealth";
            this.pbPlayerHealth.Size = new System.Drawing.Size(265, 23);
            this.pbPlayerHealth.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbPlayerHealth.TabIndex = 1;
            // 
            // lblPlayerLevel
            // 
            this.lblPlayerLevel.AutoSize = true;
            this.lblPlayerLevel.Location = new System.Drawing.Point(253, 0);
            this.lblPlayerLevel.Name = "lblPlayerLevel";
            this.lblPlayerLevel.Size = new System.Drawing.Size(53, 21);
            this.lblPlayerLevel.TabIndex = 0;
            this.lblPlayerLevel.Text = "Level";
            // 
            // pbEnemyPokemon
            // 
            this.pbEnemyPokemon.BackColor = System.Drawing.Color.Transparent;
            this.pbEnemyPokemon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbEnemyPokemon.Location = new System.Drawing.Point(490, 43);
            this.pbEnemyPokemon.Name = "pbEnemyPokemon";
            this.pbEnemyPokemon.Size = new System.Drawing.Size(343, 249);
            this.pbEnemyPokemon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbEnemyPokemon.TabIndex = 3;
            this.pbEnemyPokemon.TabStop = false;
            // 
            // tmrWriter
            // 
            this.tmrWriter.Interval = 25;
            this.tmrWriter.Tick += new System.EventHandler(this.tmrWriter_Tick);
            // 
            // tmrWaiter
            // 
            this.tmrWaiter.Tick += new System.EventHandler(this.tmrWaiter_Tick);
            // 
            // Fight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(910, 515);
            this.Controls.Add(this.gbFightScreen);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flpMoves);
            this.DoubleBuffered = true;
            this.Name = "Fight";
            this.Text = "Fight!";
            this.Load += new System.EventHandler(this.Fight_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayersPokemon)).EndInit();
            this.gbFightScreen.ResumeLayout(false);
            this.gbEnemyPokemon.ResumeLayout(false);
            this.gbEnemyPokemon.PerformLayout();
            this.gbPlayerPokemon.ResumeLayout(false);
            this.gbPlayerPokemon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEnemyPokemon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMoves;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.PictureBox pbPlayersPokemon;
        private System.Windows.Forms.GroupBox gbFightScreen;
        private System.Windows.Forms.GroupBox gbEnemyPokemon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pbEnemyPokemonHealth;
        private System.Windows.Forms.Label lblEnemyPokemonLevel;
        private System.Windows.Forms.GroupBox gbPlayerPokemon;
        private System.Windows.Forms.Label lblPlayerMaxE;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar pbPlayerHealth;
        private System.Windows.Forms.Label lblPlayerLevel;
        private System.Windows.Forms.PictureBox pbEnemyPokemon;
        private System.Windows.Forms.Label lblCurrentE;
        private System.Windows.Forms.Timer tmrWriter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblEnemyCurrentE;
        private System.Windows.Forms.Label EnemyMaxE;
        private System.Windows.Forms.Timer tmrWaiter;
    }
}

