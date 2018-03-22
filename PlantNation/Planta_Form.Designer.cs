namespace PlantNation
{
    partial class Planta_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Planta_Form));
            this.gradientPanel_background = new PlantNation.GradientPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gradientPanel_ = new PlantNation.GradientPanel();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_currentTab = new System.Windows.Forms.Label();
            this.pictureBox_Planta = new System.Windows.Forms.PictureBox();
            this.Panel_content = new System.Windows.Forms.Panel();
            this.Panel_menu = new System.Windows.Forms.Panel();
            this.lbl_journal = new System.Windows.Forms.Label();
            this.lbl_about = new System.Windows.Forms.Label();
            this.lbl_ranks = new System.Windows.Forms.Label();
            this.lbl_delete = new System.Windows.Forms.Label();
            this.lbl_change = new System.Windows.Forms.Label();
            this.lbl_add = new System.Windows.Forms.Label();
            this.lbl_Dashboard = new System.Windows.Forms.Label();
            this.gradientPanel_background.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gradientPanel_.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Planta)).BeginInit();
            this.Panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel_background
            // 
            this.gradientPanel_background.BackColor = System.Drawing.Color.Transparent;
            this.gradientPanel_background.ColorLeft = System.Drawing.Color.Transparent;
            this.gradientPanel_background.ColorRight = System.Drawing.Color.White;
            this.gradientPanel_background.Controls.Add(this.groupBox1);
            this.gradientPanel_background.Location = new System.Drawing.Point(0, -3);
            this.gradientPanel_background.Name = "gradientPanel_background";
            this.gradientPanel_background.Size = new System.Drawing.Size(1061, 588);
            this.gradientPanel_background.TabIndex = 4;
            this.gradientPanel_background.Paint += new System.Windows.Forms.PaintEventHandler(this.gradientPanel_background_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gradientPanel_);
            this.groupBox1.Controls.Add(this.pictureBox_Planta);
            this.groupBox1.Controls.Add(this.Panel_content);
            this.groupBox1.Controls.Add(this.Panel_menu);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1058, 579);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // gradientPanel_
            // 
            this.gradientPanel_.ColorLeft = System.Drawing.Color.Empty;
            this.gradientPanel_.ColorRight = System.Drawing.Color.White;
            this.gradientPanel_.Controls.Add(this.lbl_username);
            this.gradientPanel_.Controls.Add(this.lbl_currentTab);
            this.gradientPanel_.Location = new System.Drawing.Point(191, 0);
            this.gradientPanel_.Name = "gradientPanel_";
            this.gradientPanel_.Size = new System.Drawing.Size(867, 98);
            this.gradientPanel_.TabIndex = 4;
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Segoe UI Emoji", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.ForeColor = System.Drawing.Color.White;
            this.lbl_username.Location = new System.Drawing.Point(712, 12);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(141, 26);
            this.lbl_username.TabIndex = 5;
            this.lbl_username.Text = "Not logged in";
            // 
            // lbl_currentTab
            // 
            this.lbl_currentTab.AutoSize = true;
            this.lbl_currentTab.Font = new System.Drawing.Font("Segoe UI Emoji", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_currentTab.Location = new System.Drawing.Point(38, 27);
            this.lbl_currentTab.Name = "lbl_currentTab";
            this.lbl_currentTab.Size = new System.Drawing.Size(110, 44);
            this.lbl_currentTab.TabIndex = 1;
            this.lbl_currentTab.Text = "Log in";
            // 
            // pictureBox_Planta
            // 
            this.pictureBox_Planta.BackColor = System.Drawing.Color.White;
            this.pictureBox_Planta.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Planta.Image")));
            this.pictureBox_Planta.Location = new System.Drawing.Point(-31, 0);
            this.pictureBox_Planta.Name = "pictureBox_Planta";
            this.pictureBox_Planta.Size = new System.Drawing.Size(300, 98);
            this.pictureBox_Planta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Planta.TabIndex = 3;
            this.pictureBox_Planta.TabStop = false;
            // 
            // Panel_content
            // 
            this.Panel_content.BackColor = System.Drawing.Color.Transparent;
            this.Panel_content.Location = new System.Drawing.Point(203, 111);
            this.Panel_content.Name = "Panel_content";
            this.Panel_content.Size = new System.Drawing.Size(841, 447);
            this.Panel_content.TabIndex = 2;
            // 
            // Panel_menu
            // 
            this.Panel_menu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Panel_menu.BackColor = System.Drawing.Color.Transparent;
            this.Panel_menu.Controls.Add(this.lbl_journal);
            this.Panel_menu.Controls.Add(this.lbl_about);
            this.Panel_menu.Controls.Add(this.lbl_ranks);
            this.Panel_menu.Controls.Add(this.lbl_delete);
            this.Panel_menu.Controls.Add(this.lbl_change);
            this.Panel_menu.Controls.Add(this.lbl_add);
            this.Panel_menu.Controls.Add(this.lbl_Dashboard);
            this.Panel_menu.Location = new System.Drawing.Point(-1, 111);
            this.Panel_menu.Name = "Panel_menu";
            this.Panel_menu.Size = new System.Drawing.Size(198, 447);
            this.Panel_menu.TabIndex = 0;
            // 
            // lbl_journal
            // 
            this.lbl_journal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_journal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_journal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_journal.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_journal.Location = new System.Drawing.Point(12, 314);
            this.lbl_journal.Name = "lbl_journal";
            this.lbl_journal.Size = new System.Drawing.Size(173, 43);
            this.lbl_journal.TabIndex = 7;
            this.lbl_journal.Text = "Ranks";
            this.lbl_journal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_about
            // 
            this.lbl_about.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_about.BackColor = System.Drawing.Color.Transparent;
            this.lbl_about.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_about.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_about.Location = new System.Drawing.Point(12, 365);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(173, 43);
            this.lbl_about.TabIndex = 9;
            this.lbl_about.Text = "About";
            this.lbl_about.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_about.Click += new System.EventHandler(this.lbl_about_Click);
            // 
            // lbl_ranks
            // 
            this.lbl_ranks.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_ranks.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ranks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_ranks.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ranks.Location = new System.Drawing.Point(12, 263);
            this.lbl_ranks.Name = "lbl_ranks";
            this.lbl_ranks.Size = new System.Drawing.Size(173, 43);
            this.lbl_ranks.TabIndex = 8;
            this.lbl_ranks.Text = "Journal";
            this.lbl_ranks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_ranks.Click += new System.EventHandler(this.lbl_ranks_Click);
            // 
            // lbl_journal
            // 
            this.lbl_journal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_journal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_journal.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_journal.Location = new System.Drawing.Point(14, 329);
            this.lbl_journal.Name = "lbl_journal";
            this.lbl_journal.Size = new System.Drawing.Size(195, 54);
            this.lbl_journal.TabIndex = 7;
            this.lbl_journal.Text = "Ranks";
            this.lbl_journal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_journal.Click += new System.EventHandler(this.lbl_journal_Click);
            // 
            // lbl_delete
            // 
            this.lbl_delete.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_delete.BackColor = System.Drawing.Color.Transparent;
            this.lbl_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_delete.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_delete.Location = new System.Drawing.Point(12, 212);
            this.lbl_delete.Name = "lbl_delete";
            this.lbl_delete.Size = new System.Drawing.Size(173, 43);
            this.lbl_delete.TabIndex = 6;
            this.lbl_delete.Text = "Delete plant";
            this.lbl_delete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_delete.Click += new System.EventHandler(this.lbl_delete_Click);
            // 
            // lbl_change
            // 
            this.lbl_change.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_change.BackColor = System.Drawing.Color.Transparent;
            this.lbl_change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_change.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_change.Location = new System.Drawing.Point(12, 161);
            this.lbl_change.Name = "lbl_change";
            this.lbl_change.Size = new System.Drawing.Size(173, 43);
            this.lbl_change.TabIndex = 5;
            this.lbl_change.Text = "Change plant";
            this.lbl_change.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_add
            // 
            this.lbl_add.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_add.BackColor = System.Drawing.Color.Transparent;
            this.lbl_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_add.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_add.Location = new System.Drawing.Point(12, 110);
            this.lbl_add.Name = "lbl_add";
            this.lbl_add.Size = new System.Drawing.Size(173, 43);
            this.lbl_add.TabIndex = 4;
            this.lbl_add.Text = "Add plant";
            this.lbl_add.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_add.Click += new System.EventHandler(this.lbl_add_Click);
            // 
            // lbl_Dashboard
            // 
            this.lbl_Dashboard.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Dashboard.BackColor = System.Drawing.Color.Transparent;
            this.lbl_Dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_Dashboard.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Dashboard.Location = new System.Drawing.Point(12, 59);
            this.lbl_Dashboard.Name = "lbl_Dashboard";
            this.lbl_Dashboard.Size = new System.Drawing.Size(173, 43);
            this.lbl_Dashboard.TabIndex = 3;
            this.lbl_Dashboard.Text = "Dashboard";
            this.lbl_Dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Dashboard.Click += new System.EventHandler(this.lbl_Dashboard_Click);
            // 
            // Planta_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1060, 578);
            this.Controls.Add(this.gradientPanel_background);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1078, 625);
            this.Name = "Planta_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planta";
            this.gradientPanel_background.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gradientPanel_.ResumeLayout(false);
            this.gradientPanel_.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Planta)).EndInit();
            this.Panel_menu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_menu;
        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.Label lbl_ranks;
        private System.Windows.Forms.Label lbl_journal;
        private System.Windows.Forms.Label lbl_delete;
        private System.Windows.Forms.Label lbl_change;
        private System.Windows.Forms.Label lbl_add;
        private System.Windows.Forms.Label lbl_Dashboard;
        private System.Windows.Forms.Panel Panel_content;
        private System.Windows.Forms.Label lbl_currentTab;
        private System.Windows.Forms.PictureBox pictureBox_Planta;
        private GradientPanel gradientPanel_background;
        private System.Windows.Forms.GroupBox groupBox1;
        private GradientPanel gradientPanel_;
        private System.Windows.Forms.Label lbl_username;
    }
}

