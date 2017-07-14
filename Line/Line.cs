using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Runtime.Serialization;

namespace Line
{
    [DataContract]
    public class CLine : CTwoDFigure, IPerimeter, ISelectable, IEditable, IGroupable
    {
        public bool isSelected { get; set; }
        public bool IsInGroup { get; set; }
        public CLine(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            isSelected = false;
            IsInGroup = false;
        }

        public override void Draw()
        {
            gCanvas.DrawLine(new Pen(brush, 3), coordinates[0], coordinates[1]);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.DrawLine(new Pen(brush, 3), coordinates[0], coordinates[1]);
        }

        /* Реализация интерфейса IPerimeter */
        public double getPerimeter()
        {
            int deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            int deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            return Math.Sqrt(deltX * deltX + deltY * deltY);
        }

        /* Реализация интерфейса ISelectable */
        public bool isPointWithinFigure(int x, int y)
        {
            int precision = 300;
            int x0, y0, x1, y1;
            getRectangle(out x0, out y0, out x1, out y1);

            if (isPointInRect(x, y, x0 - 2, y0 - 2, x1 + 2, y1 + 2))
            {
                int val = (coordinates[0].Y - coordinates[1].Y) * x + (coordinates[1].X - coordinates[0].X) * y +
                    (coordinates[0].X * coordinates[1].Y - coordinates[1].X * coordinates[0].Y);

                val = Math.Abs(val - precision);

                return val <= precision;
            }
            else
                return false;
        }

        public void drawEditFrame()
        {
            int x0, y0, x1, y1;
            getRectangle(out x0, out y0, out x1, out y1);

            SolidBrush brush = new SolidBrush(Color.BlueViolet);
            Pen pen = new Pen(brush, 3);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gCanvas.DrawRectangle(pen, x0 - 1, y0 - 1, x1 - x0 + 1, y1 - y0 + 1);
        }

        private void getRectangle(out int x0, out int y0, out int x1, out int y1)
        {
            if (coordinates[0].X < coordinates[1].X)
            {
                x0 = coordinates[0].X;
                x1 = coordinates[1].X;
            }
            else
            {
                x0 = coordinates[1].X;
                x1 = coordinates[0].X;
            }

            if (coordinates[0].Y < coordinates[1].Y)
            {
                y0 = coordinates[0].Y;
                y1 = coordinates[1].Y;
            }
            else
            {
                y0 = coordinates[1].Y;
                y1 = coordinates[0].Y;
            }
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

        /* Реализация интерфейса IGroupable */

        public void GetParams(out Point[] coords, out Color color)
        {
            color = curColor;
            coords = new Point[coordinates.Length];
            for (int i = 0; i < coords.Length; i++)
            {
                coords[i] = new Point(coordinates[i].X, coordinates[i].Y);
            }
        }
    }
}
