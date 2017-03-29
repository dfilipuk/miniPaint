using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Runtime.Serialization;

namespace Circle
{
    [DataContract]
    class CCircle : CTwoDFigure, IPerimeter, ISelectable, IEditable
    {
        public bool isSelected { get; set; }
        [DataMember]
        int radius;
        public CCircle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            int deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            int deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            radius = (int)Math.Sqrt(deltX * deltX + deltY * deltY);
            isSelected = false;
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius, 2 * radius);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillEllipse(brush, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius, 2 * radius);
        }

        /* Реализация интерфеса IPerimeter */
        public double getPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        /* Реализация интерфеса ISelectable */
        public bool isPointWithinFigure(int x, int y)
        {
            if (isPointInRect(x, y, coordinates[0].X - radius, coordinates[0].Y - radius,
                coordinates[0].X + radius, coordinates[0].Y + radius))
            {
                int t1 = (int)Math.Pow((double)(x - coordinates[0].X), 2);
                int t2 = (int)Math.Pow((double)(y - coordinates[0].Y), 2);
                int t3 = (int)Math.Pow((double)radius, 2);
                return t1 + t2 <= t3;
            }
            else
                return false;
        }

        public void drawEditFrame()
        {
            SolidBrush brush = new SolidBrush(Color.BlueViolet);
            Pen pen = new Pen(brush, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gCanvas.DrawRectangle(pen, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius + 1, 2 * radius + 1);
        }

        private bool isPointInRect(int x, int y, int x0, int y0, int x1, int y1)
        {
            return (((x >= x0) && (x <= x1)) && ((y >= y0) && (y <= y1)));
        }

        /* Реализация интерфеса IEditable */
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
