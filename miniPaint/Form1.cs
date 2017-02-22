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
            picture = CPicture.getPicture(PictureBox.CreateGraphics());
            standartBtnColor = Color.White;
            pressedBtnColor = Color.Bisque;
        }

        private void PictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            picture.addPoint(e.X, e.Y);
        }

        private void btnBlack_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBlack.BackColor;
            picture.curColor = btnBlack.BackColor;
        }

        private void btnWhite_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnWhite.BackColor;
            picture.curColor = btnWhite.BackColor;
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnRed.BackColor;
            picture.curColor = btnRed.BackColor;
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnOrange.BackColor;
            picture.curColor = btnOrange.BackColor;
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnYellow.BackColor;
            picture.curColor = btnYellow.BackColor;
        }

        private void btnLime_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnLime.BackColor;
            picture.curColor = btnLime.BackColor;
        }

        private void btnAqua_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnAqua.BackColor;
            picture.curColor = btnAqua.BackColor;
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBlue.BackColor;
            picture.curColor = btnBlue.BackColor;
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnPink.BackColor;
            picture.curColor = btnPink.BackColor;
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            lCurColor.BackColor = btnBrown.BackColor;
            picture.curColor = btnBrown.BackColor;
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            picture.currentFigure = new CLineFactory();
            btnLine.BackColor = pressedBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = new CRectangleFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = pressedBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
        }

        private void btnTriangle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = new CTriangleFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = pressedBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = standartBtnColor;
        }

        private void btnCircle_Click(object sender, EventArgs e)
        {
            picture.currentFigure = new CCircleFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = pressedBtnColor;
            btnEllipse.BackColor = standartBtnColor;
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            picture.currentFigure = new CEllipseFactory();
            btnLine.BackColor = standartBtnColor;
            btnRectangle.BackColor = standartBtnColor;
            btnTriangle.BackColor = standartBtnColor;
            btnCircle.BackColor = standartBtnColor;
            btnEllipse.BackColor = pressedBtnColor;
        }
    }
}
