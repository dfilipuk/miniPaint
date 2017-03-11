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
    class CBezier : CTwoDFigure, IPerimeter, ISelectable, IEditable
    {
        public bool isSelected { get; set; }
        public CBezier(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            isSelected = false;
        }

        public override void Draw()
        {
            gCanvas.DrawBezier(new Pen(brush, 3), coordinates[0], coordinates[2], coordinates[3], coordinates[1]);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.DrawBezier(new Pen(brush, 3), coordinates[0], coordinates[2], coordinates[3], coordinates[1]);
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
            int x0, y0, x1, y1;
            getRectangle(out x0, out y0, out x1, out y1);

            if (isPointInRect(x, y, x0, y0, x1, y1))
                return true;
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
            drawPoint(coordinates[0].X, coordinates[0].Y, Color.DarkGoldenrod);
            drawPoint(coordinates[2].X, coordinates[2].Y, Color.DarkGoldenrod);
            drawPoint(coordinates[1].X, coordinates[1].Y, Color.ForestGreen);
            drawPoint(coordinates[3].X, coordinates[3].Y, Color.ForestGreen);
        }

        private void drawPoint(int x, int y, Color color)
        {
            gCanvas.FillEllipse(new SolidBrush(color), x - 5, y - 5, 10, 10);
        }

        private void getRectangle(out int x0, out int y0, out int x1, out int y1)
        {
            x0 = coordinates[0].X;
            y0 = coordinates[0].Y;
            x1 = x0;
            y1 = y0;
            for (int i = 1; i < coordinates.Length; i++)
            {
                if (coordinates[i].X < x0)
                    x0 = coordinates[i].X;
                if (coordinates[i].X > x1)
                    x1 = coordinates[i].X;
                if (coordinates[i].Y < y0)
                    y0 = coordinates[i].Y;
                if (coordinates[i].Y > y1)
                    y1 = coordinates[i].Y;
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
    }
}
