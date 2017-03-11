﻿namespace miniPaint
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.pColors = new System.Windows.Forms.Panel();
            this.btnBezier = new System.Windows.Forms.Button();
            this.btnEllipse = new System.Windows.Forms.Button();
            this.btnCircle = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.btnRectangle = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.lCurColor = new System.Windows.Forms.Label();
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCancelCurrentFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteLastFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRedraw = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.pColors.SuspendLayout();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureBox
            // 
            this.PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBox.BackColor = System.Drawing.Color.White;
            this.PictureBox.Location = new System.Drawing.Point(12, 42);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1372, 749);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            // 
            // pColors
            // 
            this.pColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pColors.Controls.Add(this.btnEdit);
            this.pColors.Controls.Add(this.btnBezier);
            this.pColors.Controls.Add(this.btnEllipse);
            this.pColors.Controls.Add(this.btnCircle);
            this.pColors.Controls.Add(this.btnTriangle);
            this.pColors.Controls.Add(this.btnRectangle);
            this.pColors.Controls.Add(this.btnLine);
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
            this.pColors.Location = new System.Drawing.Point(1400, 42);
            this.pColors.Name = "pColors";
            this.pColors.Size = new System.Drawing.Size(70, 749);
            this.pColors.TabIndex = 1;
            // 
            // btnBezier
            // 
            this.btnBezier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBezier.BackColor = System.Drawing.Color.White;
            this.btnBezier.Image = ((System.Drawing.Image)(resources.GetObject("btnBezier.Image")));
            this.btnBezier.Location = new System.Drawing.Point(10, 679);
            this.btnBezier.Name = "btnBezier";
            this.btnBezier.Size = new System.Drawing.Size(55, 55);
            this.btnBezier.TabIndex = 16;
            this.btnBezier.UseVisualStyleBackColor = false;
            this.btnBezier.Click += new System.EventHandler(this.btnBezier_Click);
            // 
            // btnEllipse
            // 
            this.btnEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEllipse.BackColor = System.Drawing.Color.White;
            this.btnEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnEllipse.Image")));
            this.btnEllipse.Location = new System.Drawing.Point(10, 623);
            this.btnEllipse.Name = "btnEllipse";
            this.btnEllipse.Size = new System.Drawing.Size(55, 55);
            this.btnEllipse.TabIndex = 15;
            this.btnEllipse.UseVisualStyleBackColor = false;
            this.btnEllipse.Click += new System.EventHandler(this.btnEllipse_Click);
            // 
            // btnCircle
            // 
            this.btnCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCircle.BackColor = System.Drawing.Color.White;
            this.btnCircle.Image = ((System.Drawing.Image)(resources.GetObject("btnCircle.Image")));
            this.btnCircle.Location = new System.Drawing.Point(10, 567);
            this.btnCircle.Name = "btnCircle";
            this.btnCircle.Size = new System.Drawing.Size(55, 55);
            this.btnCircle.TabIndex = 14;
            this.btnCircle.UseVisualStyleBackColor = false;
            this.btnCircle.Click += new System.EventHandler(this.btnCircle_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTriangle.BackColor = System.Drawing.Color.White;
            this.btnTriangle.Image = ((System.Drawing.Image)(resources.GetObject("btnTriangle.Image")));
            this.btnTriangle.Location = new System.Drawing.Point(10, 511);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(55, 55);
            this.btnTriangle.TabIndex = 13;
            this.btnTriangle.UseVisualStyleBackColor = false;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // btnRectangle
            // 
            this.btnRectangle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRectangle.BackColor = System.Drawing.Color.White;
            this.btnRectangle.Image = ((System.Drawing.Image)(resources.GetObject("btnRectangle.Image")));
            this.btnRectangle.Location = new System.Drawing.Point(10, 455);
            this.btnRectangle.Name = "btnRectangle";
            this.btnRectangle.Size = new System.Drawing.Size(55, 55);
            this.btnRectangle.TabIndex = 12;
            this.btnRectangle.UseVisualStyleBackColor = false;
            this.btnRectangle.Click += new System.EventHandler(this.btnRectangle_Click);
            // 
            // btnLine
            // 
            this.btnLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLine.BackColor = System.Drawing.Color.Bisque;
            this.btnLine.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.Location = new System.Drawing.Point(10, 399);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(55, 55);
            this.btnLine.TabIndex = 11;
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lCurColor
            // 
            this.lCurColor.BackColor = System.Drawing.Color.Black;
            this.lCurColor.Location = new System.Drawing.Point(12, 180);
            this.lCurColor.Name = "lCurColor";
            this.lCurColor.Size = new System.Drawing.Size(50, 50);
            this.lCurColor.TabIndex = 10;
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
            this.btnBrown.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnPink.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnBlue.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnAqua.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnLime.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnYellow.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnOrange.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnRed.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnWhite.Click += new System.EventHandler(this.btnColor_Click);
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
            this.btnBlack.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // msMenu
            // 
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(1482, 28);
            this.msMenu.TabIndex = 2;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.toolStripSeparator1,
            this.tsmiOpen,
            this.toolStripSeparator2,
            this.tsmiSave,
            this.tsmiSaveAs,
            this.toolStripSeparator3,
            this.tsmiExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(57, 24);
            this.tsmiFile.Text = "Файл";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNew.Size = new System.Drawing.Size(245, 26);
            this.tsmiNew.Text = "Новый";
            this.tsmiNew.Click += new System.EventHandler(this.tsmiNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmiOpen.Size = new System.Drawing.Size(245, 26);
            this.tsmiOpen.Text = "Открыть";
            this.tsmiOpen.Click += new System.EventHandler(this.tsmiOpen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiSave
            // 
            this.tsmiSave.Name = "tsmiSave";
            this.tsmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmiSave.Size = new System.Drawing.Size(245, 26);
            this.tsmiSave.Text = "Сохранить";
            this.tsmiSave.Click += new System.EventHandler(this.tsmiSave_Click);
            // 
            // tsmiSaveAs
            // 
            this.tsmiSaveAs.Name = "tsmiSaveAs";
            this.tsmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmiSaveAs.Size = new System.Drawing.Size(245, 26);
            this.tsmiSaveAs.Text = "Сохранить как...";
            this.tsmiSaveAs.Click += new System.EventHandler(this.tsmiSaveAs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(242, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.tsmiExit.Size = new System.Drawing.Size(245, 26);
            this.tsmiExit.Text = "Выход";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiEdit
            // 
            this.tsmiEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCancelCurrentFigure,
            this.tsmiDeleteLastFigure,
            this.tsmiDeleteAll});
            this.tsmiEdit.Name = "tsmiEdit";
            this.tsmiEdit.Size = new System.Drawing.Size(72, 24);
            this.tsmiEdit.Text = "Правка";
            // 
            // tsmiCancelCurrentFigure
            // 
            this.tsmiCancelCurrentFigure.Name = "tsmiCancelCurrentFigure";
            this.tsmiCancelCurrentFigure.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.tsmiCancelCurrentFigure.Size = new System.Drawing.Size(329, 26);
            this.tsmiCancelCurrentFigure.Text = "Отменить текущую фигуру";
            this.tsmiCancelCurrentFigure.Click += new System.EventHandler(this.tsmiCancelCurrentFigure_Click);
            // 
            // tsmiDeleteLastFigure
            // 
            this.tsmiDeleteLastFigure.Name = "tsmiDeleteLastFigure";
            this.tsmiDeleteLastFigure.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmiDeleteLastFigure.Size = new System.Drawing.Size(329, 26);
            this.tsmiDeleteLastFigure.Text = "Удалить последнюю фигуру";
            this.tsmiDeleteLastFigure.Click += new System.EventHandler(this.tsmiDeleteLastFigure_Click);
            // 
            // tsmiDeleteAll
            // 
            this.tsmiDeleteAll.Name = "tsmiDeleteAll";
            this.tsmiDeleteAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.tsmiDeleteAll.Size = new System.Drawing.Size(329, 26);
            this.tsmiDeleteAll.Text = "Удалить всё";
            this.tsmiDeleteAll.Click += new System.EventHandler(this.tsmiDeleteAll_Click);
            // 
            // timerRedraw
            // 
            this.timerRedraw.Tick += new System.EventHandler(this.timerRedraw_Tick);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "Picture1";
            this.saveFileDialog.Filter = "Рисунок miniPaint(*.mp)|*.mp";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Рисунок miniPaint(*.mp)|*.mp";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(10, 338);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 55);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1482, 803);
            this.Controls.Add(this.pColors);
            this.Controls.Add(this.PictureBox);
            this.Controls.Add(this.msMenu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "miniPaint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.pColors.ResumeLayout(false);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnEllipse;
        private System.Windows.Forms.Button btnCircle;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Button btnRectangle;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelCurrentFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteLastFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAll;
        private System.Windows.Forms.Button btnBezier;
        private System.Windows.Forms.Timer timerRedraw;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnEdit;
    }
}

