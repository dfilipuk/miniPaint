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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.pColors = new System.Windows.Forms.Panel();
            this.lColor10 = new System.Windows.Forms.Label();
            this.lColor9 = new System.Windows.Forms.Label();
            this.lColor8 = new System.Windows.Forms.Label();
            this.lColor7 = new System.Windows.Forms.Label();
            this.lColor6 = new System.Windows.Forms.Label();
            this.lColor5 = new System.Windows.Forms.Label();
            this.lColor4 = new System.Windows.Forms.Label();
            this.lColor3 = new System.Windows.Forms.Label();
            this.lColor2 = new System.Windows.Forms.Label();
            this.lColor1 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lCurColor = new System.Windows.Forms.Label();
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
            this.tsmiDeleteSelectedFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteLastFigure = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDeleteLastFigureInGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.timerRedraw = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.tsmiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.SetStandartAppParams = new System.Windows.Forms.ToolStripMenuItem();
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
            this.PictureBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.PictureBox.Location = new System.Drawing.Point(12, 42);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(1372, 749);
            this.PictureBox.TabIndex = 0;
            this.PictureBox.TabStop = false;
            this.PictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseDown);
            this.PictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_MouseMove);
            // 
            // pColors
            // 
            this.pColors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pColors.Controls.Add(this.lColor10);
            this.pColors.Controls.Add(this.lColor9);
            this.pColors.Controls.Add(this.lColor8);
            this.pColors.Controls.Add(this.lColor7);
            this.pColors.Controls.Add(this.lColor6);
            this.pColors.Controls.Add(this.lColor5);
            this.pColors.Controls.Add(this.lColor4);
            this.pColors.Controls.Add(this.lColor3);
            this.pColors.Controls.Add(this.lColor2);
            this.pColors.Controls.Add(this.lColor1);
            this.pColors.Controls.Add(this.btnEdit);
            this.pColors.Controls.Add(this.lCurColor);
            this.pColors.Location = new System.Drawing.Point(1400, 42);
            this.pColors.Name = "pColors";
            this.pColors.Size = new System.Drawing.Size(70, 749);
            this.pColors.TabIndex = 1;
            // 
            // lColor10
            // 
            this.lColor10.BackColor = System.Drawing.Color.Maroon;
            this.lColor10.Location = new System.Drawing.Point(40, 134);
            this.lColor10.Name = "lColor10";
            this.lColor10.Size = new System.Drawing.Size(25, 25);
            this.lColor10.TabIndex = 27;
            this.lColor10.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor10.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor9
            // 
            this.lColor9.BackColor = System.Drawing.Color.Fuchsia;
            this.lColor9.Location = new System.Drawing.Point(10, 134);
            this.lColor9.Name = "lColor9";
            this.lColor9.Size = new System.Drawing.Size(25, 25);
            this.lColor9.TabIndex = 26;
            this.lColor9.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor9.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor8
            // 
            this.lColor8.BackColor = System.Drawing.Color.Blue;
            this.lColor8.Location = new System.Drawing.Point(40, 103);
            this.lColor8.Name = "lColor8";
            this.lColor8.Size = new System.Drawing.Size(25, 25);
            this.lColor8.TabIndex = 25;
            this.lColor8.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor8.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor7
            // 
            this.lColor7.BackColor = System.Drawing.Color.Aqua;
            this.lColor7.Location = new System.Drawing.Point(9, 103);
            this.lColor7.Name = "lColor7";
            this.lColor7.Size = new System.Drawing.Size(25, 25);
            this.lColor7.TabIndex = 24;
            this.lColor7.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor7.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor6
            // 
            this.lColor6.BackColor = System.Drawing.Color.Lime;
            this.lColor6.Location = new System.Drawing.Point(40, 72);
            this.lColor6.Name = "lColor6";
            this.lColor6.Size = new System.Drawing.Size(25, 25);
            this.lColor6.TabIndex = 23;
            this.lColor6.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor6.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor5
            // 
            this.lColor5.BackColor = System.Drawing.Color.Yellow;
            this.lColor5.Location = new System.Drawing.Point(10, 72);
            this.lColor5.Name = "lColor5";
            this.lColor5.Size = new System.Drawing.Size(25, 25);
            this.lColor5.TabIndex = 22;
            this.lColor5.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor5.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor4
            // 
            this.lColor4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lColor4.Location = new System.Drawing.Point(40, 41);
            this.lColor4.Name = "lColor4";
            this.lColor4.Size = new System.Drawing.Size(25, 25);
            this.lColor4.TabIndex = 21;
            this.lColor4.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor4.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor3
            // 
            this.lColor3.BackColor = System.Drawing.Color.Red;
            this.lColor3.Location = new System.Drawing.Point(10, 41);
            this.lColor3.Name = "lColor3";
            this.lColor3.Size = new System.Drawing.Size(25, 25);
            this.lColor3.TabIndex = 20;
            this.lColor3.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor3.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor2
            // 
            this.lColor2.BackColor = System.Drawing.Color.White;
            this.lColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lColor2.Location = new System.Drawing.Point(40, 10);
            this.lColor2.Name = "lColor2";
            this.lColor2.Size = new System.Drawing.Size(25, 25);
            this.lColor2.TabIndex = 19;
            this.lColor2.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor2.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // lColor1
            // 
            this.lColor1.BackColor = System.Drawing.Color.Black;
            this.lColor1.Location = new System.Drawing.Point(10, 10);
            this.lColor1.Name = "lColor1";
            this.lColor1.Size = new System.Drawing.Size(25, 25);
            this.lColor1.TabIndex = 18;
            this.lColor1.Click += new System.EventHandler(this.btnColor_Click);
            this.lColor1.DoubleClick += new System.EventHandler(this.btnColor_DoubleClick);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.White;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(10, 258);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 55);
            this.btnEdit.TabIndex = 17;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lCurColor
            // 
            this.lCurColor.BackColor = System.Drawing.Color.Black;
            this.lCurColor.Location = new System.Drawing.Point(12, 180);
            this.lCurColor.Name = "lCurColor";
            this.lCurColor.Size = new System.Drawing.Size(50, 50);
            this.lCurColor.TabIndex = 10;
            this.lCurColor.Click += new System.EventHandler(this.lCurColor_Click);
            // 
            // msMenu
            // 
            this.msMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiEdit,
            this.tsmiGroups,
            this.tsmiSettings});
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
            this.tsmiDeleteSelectedFigure,
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
            // tsmiDeleteSelectedFigure
            // 
            this.tsmiDeleteSelectedFigure.Name = "tsmiDeleteSelectedFigure";
            this.tsmiDeleteSelectedFigure.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmiDeleteSelectedFigure.Size = new System.Drawing.Size(329, 26);
            this.tsmiDeleteSelectedFigure.Text = "Удалить выбранную фигуру";
            this.tsmiDeleteSelectedFigure.Click += new System.EventHandler(this.tsmiDeleteSelectedFigure_Click);
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
            // tsmiGroups
            // 
            this.tsmiGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewGroup,
            this.tsmiDeleteLastFigureInGroup,
            this.tsmiSaveGroup});
            this.tsmiGroups.Name = "tsmiGroups";
            this.tsmiGroups.Size = new System.Drawing.Size(73, 24);
            this.tsmiGroups.Text = "Группы";
            // 
            // tsmiNewGroup
            // 
            this.tsmiNewGroup.Name = "tsmiNewGroup";
            this.tsmiNewGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.tsmiNewGroup.Size = new System.Drawing.Size(393, 26);
            this.tsmiNewGroup.Text = "Новая группа";
            this.tsmiNewGroup.Click += new System.EventHandler(this.tsmiNewGroup_Click);
            // 
            // tsmiDeleteLastFigureInGroup
            // 
            this.tsmiDeleteLastFigureInGroup.Name = "tsmiDeleteLastFigureInGroup";
            this.tsmiDeleteLastFigureInGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.tsmiDeleteLastFigureInGroup.Size = new System.Drawing.Size(393, 26);
            this.tsmiDeleteLastFigureInGroup.Text = "Удалить последнюю фигуру в группе";
            this.tsmiDeleteLastFigureInGroup.Click += new System.EventHandler(this.tsmiDeleteLastFigureInGroup_Click);
            // 
            // tsmiSaveGroup
            // 
            this.tsmiSaveGroup.Name = "tsmiSaveGroup";
            this.tsmiSaveGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiSaveGroup.Size = new System.Drawing.Size(393, 26);
            this.tsmiSaveGroup.Text = "Сохранить группу";
            this.tsmiSaveGroup.Click += new System.EventHandler(this.tsmiSaveGroup_Click);
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
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // tsmiSettings
            // 
            this.tsmiSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetStandartAppParams});
            this.tsmiSettings.Name = "tsmiSettings";
            this.tsmiSettings.Size = new System.Drawing.Size(96, 24);
            this.tsmiSettings.Text = "Настройки";
            // 
            // SetStandartAppParams
            // 
            this.SetStandartAppParams.Name = "SetStandartAppParams";
            this.SetStandartAppParams.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.SetStandartAppParams.Size = new System.Drawing.Size(462, 26);
            this.SetStandartAppParams.Text = "Восстановить параметры по умолчанию";
            this.SetStandartAppParams.Click += new System.EventHandler(this.SetStandartAppParams_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMenu;
            this.MinimumSize = new System.Drawing.Size(1500, 850);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "miniPaint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
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
        private System.Windows.Forms.Label lCurColor;
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiEdit;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiCancelCurrentFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteLastFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteAll;
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
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteSelectedFigure;
        private System.Windows.Forms.ToolStripMenuItem tsmiGroups;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiDeleteLastFigureInGroup;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveGroup;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Label lColor1;
        private System.Windows.Forms.Label lColor2;
        private System.Windows.Forms.Label lColor3;
        private System.Windows.Forms.Label lColor4;
        private System.Windows.Forms.Label lColor5;
        private System.Windows.Forms.Label lColor6;
        private System.Windows.Forms.Label lColor7;
        private System.Windows.Forms.Label lColor8;
        private System.Windows.Forms.Label lColor9;
        private System.Windows.Forms.Label lColor10;
        private System.Windows.Forms.ToolStripMenuItem tsmiSettings;
        private System.Windows.Forms.ToolStripMenuItem SetStandartAppParams;
    }
}

