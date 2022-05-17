using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Runtime.Serialization;

namespace Triangle
{
    [DataContract]
    class CTriangle : CTwoDFigure, IPerimeter, ISelectable, IEditable, IGroupable
    {
        public bool isSelected { get; set; }
        public bool IsInGroup { get; set; }
        public CTriangle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            isSelected = false;
            IsInGroup = false;
        }

        public override void Draw()
        {
            gCanvas.FillPolygon(brush, coordinates);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillPolygon(brush, coordinates);
        }

        /* Реализация интерфейса IPerimeter */
        public double getPerimeter()
        {
            double res = 0;
            int deltX, deltY;

            for (int i = 0; i < coordinates.Length - 1; i++)
            {
                deltX = Math.Abs(coordinates[i].X - coordinates[i + 1].X);
                deltY = Math.Abs(coordinates[i].Y - coordinates[i + 1].Y);
                res = res + Math.Sqrt(deltX * deltX + deltY * deltY);
            }

            return res;
        }

        /* Реализация интерфейса ISelectable */
        public bool isPointWithinFigure(int x, int y)
        {
            int x0, y0, x1, y1;
            getRectangle(out x0, out y0, out x1, out y1);

            if (isPointInRect(x, y, x0, y0, x1, y1))
            {
                int temp = y;
                bool isCrossedLine = false;

                while (!isCrossedLine && (temp >= y0))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (isPointBelongToLine(x, temp, coordinates[i].X, coordinates[i].Y,
                            coordinates[(i + 1) % 3].X, coordinates[(i + 1) % 3].Y))
                        {
                            isCrossedLine = true;
                        }
                    }
                    temp--;
                }
                if (!isCrossedLine)
                    return false;

                temp = x;
                isCrossedLine = false;
                while (!isCrossedLine && (temp <= x1))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (isPointBelongToLine(temp, y, coordinates[i].X, coordinates[i].Y,
                            coordinates[(i + 1) % 3].X, coordinates[(i + 1) % 3].Y))
                        {
                            isCrossedLine = true;
                        }
                    }
                    temp++;
                }
                if (!isCrossedLine)
                    return false;

                temp = y;
                isCrossedLine = false;
                while (!isCrossedLine && (temp <= y1))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (isPointBelongToLine(x, temp, coordinates[i].X, coordinates[i].Y,
                            coordinates[(i + 1) % 3].X, coordinates[(i + 1) % 3].Y))
                        {
                            isCrossedLine = true;
                        }
                    }
                    temp++;
                }
                if (!isCrossedLine)
                    return false;

                temp = x;
                isCrossedLine = false;
                while (!isCrossedLine && (temp >= x0))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (isPointBelongToLine(temp, y, coordinates[i].X, coordinates[i].Y,
                            coordinates[(i + 1) % 3].X, coordinates[(i + 1) % 3].Y))
                        {
                            isCrossedLine = true;
                        }
                    }
                    temp--;
                }
                if (!isCrossedLine)
                    return false;

                return true;
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

        private bool isPointBelongToLine(int x, int y, int x1, int y1, int x2, int y2)
        {
            int precision = 300;

            int val = (y1 - y2) * x + (x2 - x1) * y + (x1 * y2 - x2 * y1);
            val = Math.Abs(val - precision);

            return val <= precision;
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
