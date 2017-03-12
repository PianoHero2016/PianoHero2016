namespace Game
{
    partial class Window
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
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.gameClock = new System.Windows.Forms.Timer(this.components);
            this.moveObjects = new System.Windows.Forms.Timer(this.components);
            this.renderer = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pad1 = new System.Windows.Forms.PictureBox();
            this.pad2 = new System.Windows.Forms.PictureBox();
            this.pad3 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.BackColor = System.Drawing.Color.Gray;
            this.ScoreLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLabel.Location = new System.Drawing.Point(1090, 45);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(138, 72);
            this.ScoreLabel.TabIndex = 7;
            this.ScoreLabel.Text = "High Score: 0\r\nScore: 0\r\nSpeed: 10\r\nHealth: 10";
            // 
            // gameClock
            // 
            this.gameClock.Interval = 400;
            this.gameClock.Tick += new System.EventHandler(this.gameClock_Tick);
            // 
            // moveObjects
            // 
            this.moveObjects.Interval = 10;
            this.moveObjects.Tick += new System.EventHandler(this.moveObjects_Tick);
            // 
            // renderer
            // 
            this.renderer.Enabled = true;
            this.renderer.Interval = 60;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.BackColor = System.Drawing.Color.Gray;
            this.statusLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(1090, 171);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(158, 18);
            this.statusLabel.TabIndex = 8;
            this.statusLabel.Text = "Game clock: 400";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox2.BackgroundImage = global::Game.Properties.Resources.border_bottom;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(0, 602);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1267, 25);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.BackgroundImage = global::Game.Properties.Resources.border_top;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1267, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pad1
            // 
            this.pad1.BackgroundImage = global::Game.Properties.Resources.tile_1_a;
            this.pad1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pad1.Location = new System.Drawing.Point(481, 583);
            this.pad1.Name = "pad1";
            this.pad1.Size = new System.Drawing.Size(89, 44);
            this.pad1.TabIndex = 6;
            this.pad1.TabStop = false;
            // 
            // pad2
            // 
            this.pad2.BackgroundImage = global::Game.Properties.Resources.tile_2_a;
            this.pad2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pad2.Location = new System.Drawing.Point(576, 583);
            this.pad2.Name = "pad2";
            this.pad2.Size = new System.Drawing.Size(80, 44);
            this.pad2.TabIndex = 5;
            this.pad2.TabStop = false;
            // 
            // pad3
            // 
            this.pad3.BackgroundImage = global::Game.Properties.Resources.tile_3_a;
            this.pad3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pad3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pad3.Location = new System.Drawing.Point(662, 583);
            this.pad3.Name = "pad3";
            this.pad3.Size = new System.Drawing.Size(89, 44);
            this.pad3.TabIndex = 4;
            this.pad3.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Game.Properties.Resources.bounds;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(0, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1267, 580);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1260, 625);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.ScoreLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pad1);
            this.Controls.Add(this.pad2);
            this.Controls.Add(this.pad3);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Window";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Piano Hero 2016";
            this.Load += new System.EventHandler(this.Window_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Window_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Window_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pad3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pad3;
        private System.Windows.Forms.PictureBox pad2;
        private System.Windows.Forms.PictureBox pad1;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Timer gameClock;
        private System.Windows.Forms.Timer moveObjects;
        private System.Windows.Forms.Timer renderer;
        private System.Windows.Forms.Label statusLabel;
    }
}

