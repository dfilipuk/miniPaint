using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace miniPaint
{
    public partial class frmMain : Form
    {
        readonly Color standartBtnColor;
        readonly Color pressedBtnColor;

        CPicture picture;

        public frmMain()
        {
            InitializeComponent();

            picture = new CPicture(PictureBox, CLineFactory.getFactory());

            standartBtnColor = Color.White;
            pressedBtnColor = Color.Bisque;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            picture.addPoint(e.X, e.Y);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBlack.BackColor;
            picture.currentColor = btnBlack.BackColor;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnWhite.BackColor;
            picture.currentColor = btnWhite.BackColor;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnRed.BackColor;
            picture.currentColor = btnRed.BackColor;
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnOrange.BackColor;
            picture.currentColor = btnOrange.BackColor;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnYellow.BackColor;
            picture.currentColor = btnYellow.BackColor;
        }

        private void btnLime_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnLime.BackColor;
            picture.currentColor = btnLime.BackColor;
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnAqua.BackColor;
            picture.currentColor = btnAqua.BackColor;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBlue.BackColor;
            picture.currentColor = btnBlue.BackColor;
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnPink.BackColor;
            picture.currentColor = btnPink.BackColor;
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBrown.BackColor;
            picture.currentColor = btnBrown.BackColor;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CLineFactory.getFactory();
            btnLine.BackColor = pressedBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
            btnBezier.BackColor = standartBtnColor;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CRectangleFactory.getFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = pressedBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
            btnBezier.BackColor = standartBtnColor;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CTriangleFactory.getFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = pressedBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
            btnBezier.BackColor = standartBtnColor;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CCircleFactory.getFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = pressedBtnColor;
            btnEllipse.BackColor = standartBtnColor;
            btnBezier.BackColor = standartBtnColor;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CEllipseFactory.getFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = pressedBtnColor;
            btnBezier.BackColor = standartBtnColor;
        }

        private void btnBezier_Click(object sender, EventArgs e)
        {
            picture.currentFigure = CBezierFactory.getFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
            btnBezier.BackColor = pressedBtnColor;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiCancelCurrentFigure_Click(object sender, EventArgs e)
        {
            picture.deletePoints();
        }

        private void tsmiDeleteAll_Click(object sender, EventArgs e)
        {
            picture.Clear();
        }

        private void tsmiDeleteLastFigure_Click(object sender, EventArgs e)
        {
            picture.deleteLastFigure();
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
            picture.Redraw();
            timerRedraw.Enabled = false;
        }
    }
}
