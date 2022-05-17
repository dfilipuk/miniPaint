using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Runtime.Serialization;

namespace Rectangle
{
    [DataContract]
    class CRectangle : CTwoDFigure, IPerimeter, ISelectable, IEditable, IGroupable
    {
        public bool isSelected { get; set; }
        public bool IsInGroup { get; set; }
        [DataMember]
        int deltX;
        [DataMember]
        int deltY;
        public CRectangle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            changeCoordinates();
            isSelected = false;
            IsInGroup = false;
        }

        public override void Draw()
        {
            gCanvas.FillRectangle(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillRectangle(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
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

        /* Реализация интерфейса IPerimeter */
        public double getPerimeter()
        {
            return 2 * deltX + 2 * deltY;
        }

        /* Реализация интерфейса ISelectable */
        public bool isPointWithinFigure(int x, int y)
        {
            return (isPointInRect(x, y, coordinates[0].X, coordinates[0].Y, coordinates[1].X, coordinates[1].Y));
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
