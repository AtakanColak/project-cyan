namespace CyanMapEditor
{
    partial class MapEditor
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
            this.lblNewMap = new System.Windows.Forms.Label();
            this.lblLoadMap = new System.Windows.Forms.Label();
            this.flpMap = new System.Windows.Forms.FlowLayoutPanel();
            this.lblSaveMap = new System.Windows.Forms.Label();
            this.lblSaveAs = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMiddle = new System.Windows.Forms.RadioButton();
            this.rbBack = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbTresspassMode = new System.Windows.Forms.RadioButton();
            this.rbEventMode = new System.Windows.Forms.RadioButton();
            this.rbImageMode = new System.Windows.Forms.RadioButton();
            this.txtMapName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMapId = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvResimler = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSetEvent = new System.Windows.Forms.Button();
            this.cmbEventType = new System.Windows.Forms.ComboBox();
            this.txtEventString = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblImager = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNewMap
            // 
            this.lblNewMap.AutoSize = true;
            this.lblNewMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNewMap.ForeColor = System.Drawing.Color.Black;
            this.lblNewMap.Location = new System.Drawing.Point(160, 9);
            this.lblNewMap.Name = "lblNewMap";
            this.lblNewMap.Size = new System.Drawing.Size(38, 13);
            this.lblNewMap.TabIndex = 1;
            this.lblNewMap.Text = "New...";
            this.lblNewMap.Click += new System.EventHandler(this.lblNewMap_Click);
            // 
            // lblLoadMap
            // 
            this.lblLoadMap.AutoSize = true;
            this.lblLoadMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLoadMap.ForeColor = System.Drawing.Color.Black;
            this.lblLoadMap.Location = new System.Drawing.Point(207, 9);
            this.lblLoadMap.Name = "lblLoadMap";
            this.lblLoadMap.Size = new System.Drawing.Size(40, 13);
            this.lblLoadMap.TabIndex = 1;
            this.lblLoadMap.Text = "Load...";
            this.lblLoadMap.Click += new System.EventHandler(this.lblLoadMap_Click);
            // 
            // flpMap
            // 
            this.flpMap.BackColor = System.Drawing.Color.Aqua;
            this.flpMap.Location = new System.Drawing.Point(15, 107);
            this.flpMap.Name = "flpMap";
            this.flpMap.Size = new System.Drawing.Size(626, 500);
            this.flpMap.TabIndex = 2;
            // 
            // lblSaveMap
            // 
            this.lblSaveMap.AutoSize = true;
            this.lblSaveMap.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSaveMap.ForeColor = System.Drawing.Color.Black;
            this.lblSaveMap.Location = new System.Drawing.Point(253, 9);
            this.lblSaveMap.Name = "lblSaveMap";
            this.lblSaveMap.Size = new System.Drawing.Size(41, 13);
            this.lblSaveMap.TabIndex = 1;
            this.lblSaveMap.Text = "Save...";
            this.lblSaveMap.Click += new System.EventHandler(this.lblSaveMap_Click);
            // 
            // lblSaveAs
            // 
            this.lblSaveAs.AutoSize = true;
            this.lblSaveAs.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSaveAs.ForeColor = System.Drawing.Color.Black;
            this.lblSaveAs.Location = new System.Drawing.Point(300, 9);
            this.lblSaveAs.Name = "lblSaveAs";
            this.lblSaveAs.Size = new System.Drawing.Size(56, 13);
            this.lblSaveAs.TabIndex = 1;
            this.lblSaveAs.Text = "Save As...";
            this.lblSaveAs.Click += new System.EventHandler(this.lblSaveAs_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMiddle);
            this.groupBox1.Controls.Add(this.rbBack);
            this.groupBox1.Location = new System.Drawing.Point(653, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 92);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Layer";
            // 
            // rbMiddle
            // 
            this.rbMiddle.AutoSize = true;
            this.rbMiddle.Location = new System.Drawing.Point(6, 36);
            this.rbMiddle.Name = "rbMiddle";
            this.rbMiddle.Size = new System.Drawing.Size(56, 17);
            this.rbMiddle.TabIndex = 0;
            this.rbMiddle.TabStop = true;
            this.rbMiddle.Text = "Middle";
            this.rbMiddle.UseVisualStyleBackColor = true;
            // 
            // rbBack
            // 
            this.rbBack.AutoSize = true;
            this.rbBack.Location = new System.Drawing.Point(6, 13);
            this.rbBack.Name = "rbBack";
            this.rbBack.Size = new System.Drawing.Size(83, 17);
            this.rbBack.TabIndex = 0;
            this.rbBack.TabStop = true;
            this.rbBack.Text = "Background";
            this.rbBack.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbTresspassMode);
            this.groupBox2.Controls.Add(this.rbEventMode);
            this.groupBox2.Controls.Add(this.rbImageMode);
            this.groupBox2.Location = new System.Drawing.Point(157, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 73);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mode";
            // 
            // rbTresspassMode
            // 
            this.rbTresspassMode.AutoSize = true;
            this.rbTresspassMode.Location = new System.Drawing.Point(6, 36);
            this.rbTresspassMode.Name = "rbTresspassMode";
            this.rbTresspassMode.Size = new System.Drawing.Size(117, 17);
            this.rbTresspassMode.TabIndex = 1;
            this.rbTresspassMode.TabStop = true;
            this.rbTresspassMode.Text = "Tresspassing Mode";
            this.rbTresspassMode.UseVisualStyleBackColor = true;
            this.rbTresspassMode.Click += new System.EventHandler(this.rbTresspassMode_Click);
            // 
            // rbEventMode
            // 
            this.rbEventMode.AutoSize = true;
            this.rbEventMode.Location = new System.Drawing.Point(126, 13);
            this.rbEventMode.Name = "rbEventMode";
            this.rbEventMode.Size = new System.Drawing.Size(83, 17);
            this.rbEventMode.TabIndex = 0;
            this.rbEventMode.TabStop = true;
            this.rbEventMode.Text = "Event Mode";
            this.rbEventMode.UseVisualStyleBackColor = true;
            this.rbEventMode.Click += new System.EventHandler(this.rbEventMode_Click);
            // 
            // rbImageMode
            // 
            this.rbImageMode.AutoSize = true;
            this.rbImageMode.Location = new System.Drawing.Point(6, 13);
            this.rbImageMode.Name = "rbImageMode";
            this.rbImageMode.Size = new System.Drawing.Size(84, 17);
            this.rbImageMode.TabIndex = 0;
            this.rbImageMode.TabStop = true;
            this.rbImageMode.Text = "Image Mode";
            this.rbImageMode.UseVisualStyleBackColor = true;
            this.rbImageMode.Click += new System.EventHandler(this.rbImageMode_Click);
            // 
            // txtMapName
            // 
            this.txtMapName.Location = new System.Drawing.Point(54, 35);
            this.txtMapName.Name = "txtMapName";
            this.txtMapName.Size = new System.Drawing.Size(79, 20);
            this.txtMapName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Id:";
            // 
            // txtMapId
            // 
            this.txtMapId.Location = new System.Drawing.Point(54, 66);
            this.txtMapId.Name = "txtMapId";
            this.txtMapId.Size = new System.Drawing.Size(79, 20);
            this.txtMapId.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtMapId);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtMapName);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 9);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(139, 92);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Map Properties";
            // 
            // tvResimler
            // 
            this.tvResimler.BackColor = System.Drawing.Color.Lime;
            this.tvResimler.Location = new System.Drawing.Point(653, 107);
            this.tvResimler.Name = "tvResimler";
            this.tvResimler.Size = new System.Drawing.Size(119, 492);
            this.tvResimler.TabIndex = 9;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSetEvent);
            this.groupBox4.Controls.Add(this.cmbEventType);
            this.groupBox4.Controls.Add(this.txtEventString);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(479, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(168, 92);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Event Properties";
            // 
            // btnSetEvent
            // 
            this.btnSetEvent.Location = new System.Drawing.Point(87, 66);
            this.btnSetEvent.Name = "btnSetEvent";
            this.btnSetEvent.Size = new System.Drawing.Size(75, 23);
            this.btnSetEvent.TabIndex = 8;
            this.btnSetEvent.Text = "Set Event";
            this.btnSetEvent.UseVisualStyleBackColor = true;
            this.btnSetEvent.Click += new System.EventHandler(this.btnSetEvent_Click);
            // 
            // cmbEventType
            // 
            this.cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEventType.FormattingEnabled = true;
            this.cmbEventType.Location = new System.Drawing.Point(88, 19);
            this.cmbEventType.Name = "cmbEventType";
            this.cmbEventType.Size = new System.Drawing.Size(74, 21);
            this.cmbEventType.TabIndex = 1;
            // 
            // txtEventString
            // 
            this.txtEventString.Location = new System.Drawing.Point(88, 43);
            this.txtEventString.Name = "txtEventString";
            this.txtEventString.Size = new System.Drawing.Size(74, 20);
            this.txtEventString.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Event String:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Event Type:";
            // 
            // lblImager
            // 
            this.lblImager.AutoSize = true;
            this.lblImager.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblImager.Location = new System.Drawing.Point(363, 9);
            this.lblImager.Name = "lblImager";
            this.lblImager.Size = new System.Drawing.Size(58, 13);
            this.lblImager.TabIndex = 11;
            this.lblImager.Text = "Add Image";
            this.lblImager.Click += new System.EventHandler(this.lblImager_Click);
            // 
            // MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 611);
            this.Controls.Add(this.lblImager);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tvResimler);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flpMap);
            this.Controls.Add(this.lblSaveAs);
            this.Controls.Add(this.lblSaveMap);
            this.Controls.Add(this.lblLoadMap);
            this.Controls.Add(this.lblNewMap);
            this.MaximumSize = new System.Drawing.Size(800, 650);
            this.MinimumSize = new System.Drawing.Size(700, 650);
            this.Name = "MapEditor";
            this.Text = "Cyan Map Editor";
            this.Load += new System.EventHandler(this.MapEditor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewMap;
        private System.Windows.Forms.Label lblLoadMap;
        private System.Windows.Forms.FlowLayoutPanel flpMap;
        private System.Windows.Forms.Label lblSaveMap;
        private System.Windows.Forms.Label lblSaveAs;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMiddle;
        private System.Windows.Forms.RadioButton rbBack;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbTresspassMode;
        private System.Windows.Forms.RadioButton rbImageMode;
        private System.Windows.Forms.TextBox txtMapName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMapId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvResimler;
        private System.Windows.Forms.RadioButton rbEventMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbEventType;
        private System.Windows.Forms.TextBox txtEventString;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSetEvent;
        private System.Windows.Forms.Label lblImager;
    }
}

