using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inheritance;

namespace miniPaint
{
    public enum EResponse { rYes, rNo, rCancel };
    public partial class frmMain : Form
    {
        readonly Color standartBtnColor;
        readonly Color pressedBtnColor;
        readonly Color STANDART_CANVAS_COLOR = Color.White;
        
        const int BTN_FIGURE_SIZE_PX = 41;
        const int BTN_FIGURE_DELIMITER_SIZE_PX = 1;

        const string ERROR_CAPTION = "Ошибка!";
        const string FAIL_TO_SAVE_MESSG = "Не удалось сохранить рисунок!";
        const string FAIL_TO_LOAD_MESSG = "Не удалось загрузить рисунок!";

        const string CAPTION_NOT_SAVED_NEW = "*miniPaint";
        const string CAPTION_SAVED_NEW = "miniPaint";
        const string CAPTION_NOT_SAVED = "*{0} - miniPaint";
        const string CAPTION_SAVED = "{0} - miniPaint";

        CPicture picture;
        CViewer userInterface;
        CProjectInfo projectManager;
        CFiguresLoader figuresLoader;
        CFiguresGroupManager figuresGroupManager;
        List<Button> figuresBtns;
        PictureMode prevMode;
        CAppParams standartParams, currentParams;
        int curBtnX, curBtnY;

        public frmMain()
        {
            InitializeComponent();

            curBtnX = 8;
            curBtnY = 260;

            figuresBtns = new List<Button>();
            userInterface = new CViewer(this);
            projectManager = new CProjectInfo(userInterface);
            figuresLoader = new CFiguresLoader(userInterface);

            standartParams = GetApplicationParametrs();
            currentParams = GetApplicationParametrs();

            figuresLoader.LoadFigures();
            CTwoDFigureFactory.LoadedFactories = figuresLoader.LoadedMethods;
            CTwoDFigure.KnownTypes = figuresLoader.LoadedTypes;
            figuresGroupManager = new CFiguresGroupManager(userInterface, figuresLoader);

            CTwoDFigureFactory factory = CTwoDFigureFactory.GetFactory(0);
            if (factory != null)
            {
                picture = new CPicture(currentParams.PictureBackgroundColor, PictureBox, factory, PictureMode.pmEdit, figuresGroupManager);
            }

            standartBtnColor = Color.White;
            pressedBtnColor = Color.Bisque;
            prevMode = PictureMode.pmEdit;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            setStandartSettings();
            updateWindowCaption();
        }

        public void showErrorMessageBox(string message)
        {
            MessageBox.Show(message, ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public EResponse showQuestionMessageBox(string question, string caption)
        {
            DialogResult response = MessageBox.Show(question, caption, MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            EResponse res = EResponse.rCancel;
            switch (response)
            {
                case DialogResult.Yes:
                    res = EResponse.rYes;
                    break;
                case DialogResult.No:
                    res = EResponse.rNo;
                    break;
                case DialogResult.Cancel:
                    res = EResponse.rCancel;
                    break;
            }
            return res;
        }

        public bool getPathFromSaveDialog(out string path)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                path = String.Empty;
                return false;
            }
            else
            {
                path = saveFileDialog.FileName;
                return true;
            }
        }

        public bool getPathFromOpenDialog(out string path)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                path = String.Empty;
                return false;
            }
            else
            {
                path = openFileDialog.FileName;
                return true;
            }
        }

        public bool saveToFile(string path)
        {
            try
            {
                if (picture != null)
                {
                    picture.savePictureToFile(path);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                showErrorMessageBox(FAIL_TO_SAVE_MESSG);
                return false;
            }
        }

        public bool loadFromFile(string path)
        {
            try
            {
                CTwoDFigureFactory factory = CTwoDFigureFactory.GetFactory(0);
                if (factory != null)
                {
                    CJSONparser parser = new CJSONparser(figuresLoader.TypesNames, figuresLoader.NamespacesNames, 
                        figuresLoader.FiguresGroupType);
                    string content = parser.ParseFile(path);
                    if (content == null)
                    {
                        throw new Exception();
                    }
                    var newPicture = new CPicture(currentParams.PictureBackgroundColor, PictureBox, factory, PictureMode.pmEdit, figuresGroupManager, content);
                    picture = newPicture;
                    setStandartSettings();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                picture.Redraw();
                showErrorMessageBox(FAIL_TO_LOAD_MESSG);
                return false;
            }
        }

        public void CreateButton(string name, Image picture)
        {
            Button newBtn = new Button();
            newBtn.Name = name;
            newBtn.Location = new Point(curBtnX, curBtnY);
            newBtn.Width = BTN_FIGURE_SIZE_PX;
            newBtn.Height = BTN_FIGURE_SIZE_PX;
            newBtn.Image = picture;
            newBtn.Click += new EventHandler(btnFigure_Click);

            pColors.Controls.Add(newBtn);
            figuresBtns.Add(newBtn);

            curBtnY += BTN_FIGURE_SIZE_PX + BTN_FIGURE_DELIMITER_SIZE_PX;
        }

        public void CreateButton(string name, string text)
        {
            Button newBtn = new Button();
            newBtn.Name = name;
            newBtn.Text = text;
            newBtn.Font = new Font("Arial", (float)6);
            newBtn.Location = new Point(curBtnX, curBtnY);
            newBtn.Width = BTN_FIGURE_SIZE_PX;
            newBtn.Height = BTN_FIGURE_SIZE_PX;
            newBtn.Click += new EventHandler(btnFigure_Click);

            pColors.Controls.Add(newBtn);
            figuresBtns.Add(newBtn);

            curBtnY += BTN_FIGURE_SIZE_PX + BTN_FIGURE_DELIMITER_SIZE_PX;
        }

        private void updateWindowCaption()
        {
            bool handled = false;
            string newCaption = String.Empty;

            if (!handled && !projectManager.isOnDisk && projectManager.isSaved)
            {
                newCaption = CAPTION_SAVED_NEW;
                handled = true;
            }
            if (!handled && !projectManager.isOnDisk && !projectManager.isSaved)
            {
                newCaption = CAPTION_NOT_SAVED_NEW;
                handled = true;
            }
            if (!handled && projectManager.isOnDisk && projectManager.isSaved)
            {
                newCaption = String.Format(CAPTION_SAVED, projectManager.fileName);
                handled = true;
            }
            if (!handled && projectManager.isOnDisk && !projectManager.isSaved)
            {
                newCaption = String.Format(CAPTION_NOT_SAVED, projectManager.fileName);
                handled = true;
            }
            this.Text = newCaption;
        }

        private CAppParams GetApplicationParametrs()
        {
            CAppParams res = new CAppParams();

            res.IsMaximized = (this.WindowState == FormWindowState.Maximized);
            res.WindowLocation = new Point(this.Location.X, this.Location.Y);
            res.WindowSize = new Size(this.Size.Width, this.Size.Height);
            res.PictureBackgroundColor = STANDART_CANVAS_COLOR;
            res.Color1 = lColor1.BackColor;
            res.Color2 = lColor2.BackColor;
            res.Color3 = lColor3.BackColor;
            res.Color4 = lColor4.BackColor;
            res.Color5 = lColor5.BackColor;
            res.Color6 = lColor6.BackColor;
            res.Color7 = lColor7.BackColor;
            res.Color8 = lColor8.BackColor;
            res.Color9 = lColor9.BackColor;
            res.Color10 = lColor10.BackColor;

            return res;
        }

        private void setStandartSettings()
        {
            setStandartColorForAllButtons();
            setPressedColorForButton(btnEdit);
            lCurColor.BackColor = Color.Black;
        }

        private void setStandartColorForAllButtons()
        {
            btnEdit.BackColor = standartBtnColor;
            for (int i = 0; i < figuresBtns.Count; i++)
            {
                figuresBtns[i].BackColor = standartBtnColor;
            }
        }

        private void setPressedColorForButton(Button btn)
        {
            btn.BackColor = pressedBtnColor;
        }

        private void ChangeColor(Color newColor)
        {
            if (picture != null)
            {
                switch (picture.Mode)
                {
                    case PictureMode.pmEdit:
                        picture.changeColorOfSelectedFigure(newColor);
                        projectManager.isSaved = false;
                        updateWindowCaption();
                        break;
                    case PictureMode.pmDraw:
                        lCurColor.BackColor = newColor;
                        picture.currentColor = newColor;
                        break;
                }
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e; 
            Label pressedBtn = sender as Label;
            if ((pressedBtn != null) && (picture != null))
            {
                switch (mouse.Button)
                {
                    case MouseButtons.Left:
                        ChangeColor(pressedBtn.BackColor);
                        break;
                    case MouseButtons.Right:
                        currentParams.PictureBackgroundColor = pressedBtn.BackColor;
                        picture.BackgroundColor = pressedBtn.BackColor;
                        break;
                }
            }
        }

        private void btnColor_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            Label pressedBtn = sender as Label;
            if (pressedBtn != null)
            {
                if (mouse.Button == MouseButtons.Left)
                {
                    if (colorDialog.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    else
                    {
                        pressedBtn.BackColor = colorDialog.Color;
                        lCurColor.BackColor = colorDialog.Color;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.Mode = PictureMode.pmEdit;
                setStandartColorForAllButtons();
                setPressedColorForButton(btnEdit);
            }
        }

        private void btnFigure_Click(object sender, EventArgs e)
        {
            Button curBtn = (Button)sender;
            picture.currentFigure = CTwoDFigureFactory.GetFactory(figuresLoader.GetBtnNumber(curBtn.Name));
            setStandartColorForAllButtons();
            setPressedColorForButton(curBtn);
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiCancelCurrentFigure_Click(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.deletePoints();
            }
        }

        private void tsmiDeleteAll_Click(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.Clear();
                projectManager.isSaved = false;
                updateWindowCaption();
            }
        }

        private void tsmiDeleteLastFigure_Click(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.deleteLastFigure();
                projectManager.isSaved = false;
                updateWindowCaption();
            }
        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            /*
            if (((this.WindowState == FormWindowState.Maximized) || (this.WindowState == FormWindowState.Normal)) && (picture != null))
            {
                timerRedraw.Enabled = true;
            }
            */
        }

        private void timerRedraw_Tick(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.Redraw();
                timerRedraw.Enabled = false;
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (projectManager.canContinue())
            {
                projectManager.loadProject();
                updateWindowCaption();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            projectManager.saveProject();
            updateWindowCaption();
        }

        private void tsmiSaveAs_Click(object sender, EventArgs e)
        {
            projectManager.saveProjectAs();
            updateWindowCaption();
        }

        private void tsmiNew_Click(object sender, EventArgs e)
        {
            if (projectManager.canContinue())
            {
                CTwoDFigureFactory factory = CTwoDFigureFactory.GetFactory(0);
                if (factory != null)
                {
                    picture = new CPicture(currentParams.PictureBackgroundColor, PictureBox, factory, PictureMode.pmEdit, figuresGroupManager);
                    setStandartSettings();
                    projectManager.resetProjectInfo();
                    updateWindowCaption();
                }
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !projectManager.canContinue();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (picture != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    switch (picture.Mode)
                    {
                        case PictureMode.pmEdit:
                            picture.selectFigure(e.X, e.Y);
                            break;
                        case PictureMode.pmDraw:
                            picture.addPoint(e.X, e.Y);
                            projectManager.isSaved = false;
                            updateWindowCaption();
                            break;
                        case PictureMode.pmGroup:
                            picture.AddFigureToGroup(e.X, e.Y);
                            break;
                    }
                }
            }
        }

        private void tsmiDeleteSelectedFigure_Click(object sender, EventArgs e)
        {
            if (picture.Mode == PictureMode.pmEdit)
            {
                picture.DeleteSelectedFigure();
            }
        }

        private void tsmiNewGroup_Click(object sender, EventArgs e)
        {
            prevMode = picture.Mode;
            picture.Mode = PictureMode.pmGroup;
        }

        private void tsmiDeleteLastFigureInGroup_Click(object sender, EventArgs e)
        {
            figuresGroupManager.RemoveLastFigure();
            picture.Redraw();
        }

        private void tsmiSaveGroup_Click(object sender, EventArgs e)
        {
            figuresGroupManager.SaveGroup();
            picture.Mode = prevMode;
        }

        private void lCurColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                ChangeColor(colorDialog.Color);
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (picture != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    projectManager.isSaved = false;
                    updateWindowCaption();
                    picture.changePoitionOfSelectedFigure(e.X, e.Y);
                }
            }
        }
    }
}
