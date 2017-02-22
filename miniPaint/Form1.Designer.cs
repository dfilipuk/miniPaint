namespace miniPaint
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.pColors = new System.Windows.Forms.Panel();
            this.btnBrown = new System.Windows.Forms.Button();
            this.btnPink = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnAqua = new System.Windows.Forms.Button();
            this.btnLime = new System.Windows.Forms.Button();
            this.btnYellow = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnRed = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.btnBlack = new System.Windows.Forms.Button();
            this.lCurColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.pColors.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BackColor = System.Drawing.Color.White;
            this.PictureBox.Location = new System.Drawing.Point(12, 12);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1072, 629);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseClick);
            // 
            // pColors
            // 
            this.pColors.Controls.Add(this.lCurColor);
            this.pColors.Controls.Add(this.btnBrown);
            this.pColors.Controls.Add(this.btnPink);
            this.pColors.Controls.Add(this.btnBlue);
            this.pColors.Controls.Add(this.btnAqua);
            this.pColors.Controls.Add(this.btnLime);
            this.pColors.Controls.Add(this.btnYellow);
            this.pColors.Controls.Add(this.btnOrange);
            this.pColors.Controls.Add(this.btnRed);
            this.pColors.Controls.Add(this.btnWhite);
            this.pColors.Controls.Add(this.btnBlack);
            this.pColors.Location = new System.Drawing.Point(1100, 12);
            this.pColors.Name = "pColors";
            this.pColors.Size = new System.Drawing.Size(70, 629);
            this.pColors.TabIndex = 1;
            // 
            // btnBrown
            // 
            this.btnBrown.BackColor = System.Drawing.Color.Maroon;
            this.btnBrown.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.btnBrown.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnBrown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.btnBrown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrown.Location = new System.Drawing.Point(40, 134);
            this.btnBrown.Name = "btnBrown";
            this.btnBrown.Size = new System.Drawing.Size(25, 25);
            this.btnBrown.TabIndex = 9;
            this.btnBrown.UseVisualStyleBackColor = false;
            this.btnBrown.Click += new System.EventHandler(this.btnBrown_Click);
            // 
            // btnPink
            // 
            this.btnPink.BackColor = System.Drawing.Color.Fuchsia;
            this.btnPink.FlatAppearance.BorderColor = System.Drawing.Color.Fuchsia;
            this.btnPink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Fuchsia;
            this.btnPink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Fuchsia;
            this.btnPink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPink.Location = new System.Drawing.Point(10, 134);
            this.btnPink.Name = "btnPink";
            this.btnPink.Size = new System.Drawing.Size(25, 25);
            this.btnPink.TabIndex = 8;
            this.btnPink.UseVisualStyleBackColor = false;
            this.btnPink.Click += new System.EventHandler(this.btnPink_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.BackColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
            this.btnBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlue.Location = new System.Drawing.Point(40, 103);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(25, 25);
            this.btnBlue.TabIndex = 7;
            this.btnBlue.UseVisualStyleBackColor = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnAqua
            // 
            this.btnAqua.BackColor = System.Drawing.Color.Aqua;
            this.btnAqua.FlatAppearance.BorderColor = System.Drawing.Color.Aqua;
            this.btnAqua.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Aqua;
            this.btnAqua.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua;
            this.btnAqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAqua.Location = new System.Drawing.Point(10, 103);
            this.btnAqua.Name = "btnAqua";
            this.btnAqua.Size = new System.Drawing.Size(25, 25);
            this.btnAqua.TabIndex = 6;
            this.btnAqua.UseVisualStyleBackColor = false;
            this.btnAqua.Click += new System.EventHandler(this.btnAqua_Click);
            // 
            // btnLime
            // 
            this.btnLime.BackColor = System.Drawing.Color.Lime;
            this.btnLime.FlatAppearance.BorderColor = System.Drawing.Color.Lime;
            this.btnLime.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.btnLime.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Lime;
            this.btnLime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLime.Location = new System.Drawing.Point(40, 72);
            this.btnLime.Name = "btnLime";
            this.btnLime.Size = new System.Drawing.Size(25, 25);
            this.btnLime.TabIndex = 5;
            this.btnLime.UseVisualStyleBackColor = false;
            this.btnLime.Click += new System.EventHandler(this.btnLime_Click);
            // 
            // btnYellow
            // 
            this.btnYellow.BackColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Yellow;
            this.btnYellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYellow.Location = new System.Drawing.Point(10, 72);
            this.btnYellow.Name = "btnYellow";
            this.btnYellow.Size = new System.Drawing.Size(25, 25);
            this.btnYellow.TabIndex = 4;
            this.btnYellow.UseVisualStyleBackColor = false;
            this.btnYellow.Click += new System.EventHandler(this.btnYellow_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnOrange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrange.Location = new System.Drawing.Point(40, 41);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(25, 25);
            this.btnOrange.TabIndex = 3;
            this.btnOrange.UseVisualStyleBackColor = false;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnRed
            // 
            this.btnRed.BackColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnRed.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnRed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRed.Location = new System.Drawing.Point(10, 41);
            this.btnRed.Name = "btnRed";
            this.btnRed.Size = new System.Drawing.Size(25, 25);
            this.btnRed.TabIndex = 2;
            this.btnRed.UseVisualStyleBackColor = false;
            this.btnRed.Click += new System.EventHandler(this.btnRed_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnWhite.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnWhite.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.btnWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhite.Location = new System.Drawing.Point(40, 10);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(25, 25);
            this.btnWhite.TabIndex = 1;
            this.btnWhite.UseVisualStyleBackColor = false;
            this.btnWhite.Click += new System.EventHandler(this.btnWhite_Click);
            // 
            // btnBlack
            // 
            this.btnBlack.BackColor = System.Drawing.Color.Black;
            this.btnBlack.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBlack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnBlack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.btnBlack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBlack.Location = new System.Drawing.Point(10, 10);
            this.btnBlack.Name = "btnBlack";
            this.btnBlack.Size = new System.Drawing.Size(25, 25);
            this.btnBlack.TabIndex = 0;
            this.btnBlack.UseVisualStyleBackColor = false;
            this.btnBlack.Click += new System.EventHandler(this.btnBlack_Click);
            // 
            // lCurColor
            // 
            this.lCurColor.BackColor = System.Drawing.Color.Black;
            this.lCurColor.Location = new System.Drawing.Point(10, 180);
            this.lCurColor.Name = "lCurColor";
            this.lCurColor.Size = new System.Drawing.Size(50, 50);
            this.lCurColor.TabIndex = 10;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.pColors);
            this.Controls.Add(this.PictureBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "miniPaint";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.pColors.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Panel pColors;
        private System.Windows.Forms.Button btnBlack;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Button btnBrown;
        private System.Windows.Forms.Button btnPink;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnAqua;
        private System.Windows.Forms.Button btnLime;
        private System.Windows.Forms.Button btnYellow;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnRed;
        private System.Windows.Forms.Label lCurColor;
    }
}

