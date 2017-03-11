using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace miniPaint
{
    [DataContract]
    class CEllipse : CTwoDFigure, IPerimeter, ISelectable, IEditable
    {
        public bool isSelected { get; set; }
        [DataMember]
        int deltX;
        [DataMember]
        int deltY;
        public CEllipse(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            changeCoordinates();
            isSelected = false;
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillEllipse(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }

        private void changeCoordinates()
        {
            int x1 = coordinates[0].X;
            int x2 = coordinates[1].X;
            int y1 = coordinates[0].Y;
            int y2 = coordinates[1].Y;

            coordinates[0].X = x1 < x2 ? x1 : x2;
            coordinates[0].Y = y1 < y2 ? y1 : y2;

            coordinates[1].X = x1 > x2 ? x1 : x2;
            coordinates[1].Y = y1 > y2 ? y1 : y2;
        }

        /* Реализация интерфеса IPerimeter */
        public double getPerimeter()
        {
            return Math.PI * (deltX / 2 + deltY / 2);
        }

        /* Реализация интерфейса ISelectable */
        public bool isPointWithinFigure(int x, int y)
        {
            if (isPointInRect(x, y, coordinates[0].X, coordinates[0].Y, coordinates[1].X, coordinates[1].Y))
            {
                int a = deltX / 2;
                int b = deltY / 2;
                int centerX = coordinates[0].X + a;
                int centerY = coordinates[0].Y + b;
                double a2 = Math.Pow((double)a, 2);
                double b2 = Math.Pow((double)b, 2);
                double t1 = Math.Pow((double)(x - centerX), 2);
                double t2 = Math.Pow((double)(y - centerY), 2);
                return t1 / a2 + t2 / b2 <= 1;
            }
            else
                return false;
        }

        public void drawEditFrame()
        {
            SolidBrush brush = new SolidBrush(Color.BlueViolet);
            Pen pen = new Pen(brush, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gCanvas.DrawRectangle(pen, coordinates[0].X - 1, coordinates[0].Y - 1, deltX + 1, deltY + 1);
        }

        private bool isPointInRect(int x, int y, int x0, int y0, int x1, int y1)
        {
            return (((x >= x0) && (x <= x1)) && ((y >= y0) && (y <= y1)));
        }

        /* Реализация интерфейса IEditable */
        public void changeColor(Color newColor)
        {
            curColor = newColor;
            brush = new SolidBrush(curColor);
        }

        public void changePosition(int deltX, int deltY)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i].X += deltX;
                coordinates[i].Y += deltY;
            }
        }
    }
}
