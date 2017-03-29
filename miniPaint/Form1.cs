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

        const int BTN_FIGURE_SIZE_PX = 41;
        const int BTN_FIGURE_DELIMITER_SIZE_PX = 1;

        const string ERROR_CAPTION = "Ошибка!";
        const string FAIL_TO_SAVE_MESSG = "Не удалось сохранить рисунок!";
        const string FAIL_TO_LOAD_MESSG = "Не удалось загрузить рисунок!";

        const string CAPTION_NOT_SAVED_NEW = "*miniPaint";
        const string CAPTION_SAVED_NEW = "miniPaint";
        const string CAPTION_NOT_SAVED = "*{0} - miniPaint";
        const string CAPTION_SAVED = "{0} - miniPaint";

        const bool EDIT_MODE = true;
        const bool NOT_EDIT_MODE = false;

        CPicture picture;
        CViewer userInterface;
        CProjectInfo projectManager;
        CFiguresLoader figuresLoader;
        List<Button> figuresBtns;
        int curBtnX, curBtnY;

        public frmMain()
        {
            InitializeComponent();
            curBtnX = 8;
            curBtnY = 325;
            figuresBtns = new List<Button>();

            userInterface = new CViewer(this);
            projectManager = new CProjectInfo(userInterface);
            figuresLoader = new CFiguresLoader(userInterface);
            figuresLoader.LoadFigures();
            CTwoDFigureFactory.LoadedFactories = figuresLoader.LoadedMethods;
            CTwoDFigure.KnownTypes = figuresLoader.LoadedTypes;

            CTwoDFigureFactory factory = CTwoDFigureFactory.GetFactory(0);
            if (factory != null)
            {
                picture = new CPicture(PictureBox, factory, EDIT_MODE);
            }

            standartBtnColor = Color.White;
            pressedBtnColor = Color.Bisque;
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
                    var newPicture = new CPicture(PictureBox, factory, EDIT_MODE, path);
                    picture = newPicture;
                    setStandartSettings();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
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

        private void setStandartSettings()
        {
            setStandartColorForAllButtons();
            setPressedColorForButton(btnEdit);
            lCurColor.BackColor = btnBlack.BackColor;
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

        private void btnColor_Click(object sender, EventArgs e)
        {
            Button pressedBtn = sender as Button;
            if (pressedBtn != null)
            {
                if (picture != null)
                {
                    if (!picture.isEditMode)
                    {
                        lCurColor.BackColor = pressedBtn.BackColor;
                        picture.currentColor = pressedBtn.BackColor;
                    }
                    else
                    {
                        picture.changeColorOfSelectedFigure(pressedBtn.BackColor);
                        projectManager.isSaved = false;
                        updateWindowCaption();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (picture != null)
            {
                picture.isEditMode = true;
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
            if (((this.WindowState == FormWindowState.Maximized) || (this.WindowState == FormWindowState.Normal)) && (picture != null))
            {
                timerRedraw.Enabled = true;
            }
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
                    picture = new CPicture(PictureBox, factory, EDIT_MODE);
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
                    if (!picture.isEditMode)
                    {
                        picture.addPoint(e.X, e.Y);
                        projectManager.isSaved = false;
                        updateWindowCaption();
                    }
                    else
                    {
                        picture.selectFigure(e.X, e.Y);
                    }
                }
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
