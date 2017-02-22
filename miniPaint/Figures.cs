using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    interface IPerimeter
    {
        double getPerimeter();
    }
    abstract class CTwoDFigure : IPerimeter
    {
        protected Point[] coordinates;
        protected SolidBrush brush;
        protected Graphics gCanvas;
        public abstract double getPerimeter();
        public abstract void Draw();

        public CTwoDFigure(Color color, Point[] points, Graphics canv)
        {
            brush = new SolidBrush(color);
            coordinates = points;
            gCanvas = canv;
        }
    }

    class CLine : CTwoDFigure
    {
        public CLine(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            Draw();
        }
        public override double getPerimeter()
        {
            int deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            int deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            return Math.Sqrt(deltX * deltX + deltY * deltY);
        }

        public override void Draw()
        {
            gCanvas.DrawLine(new Pen(brush), coordinates[0], coordinates[1]);
        }
    }

    class CRectangle : CTwoDFigure
    {
        int deltX, deltY;
        public CRectangle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            Draw();
        }
        public override double getPerimeter()
        {
            return 2 * deltX + 2 * deltY;
        }

        public override void Draw()
        {
            gCanvas.FillRectangle(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }
    }

    class CTriangle : CTwoDFigure
    {
        public CTriangle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            Draw();
        }
        public override double getPerimeter()
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

        public override void Draw()
        {
            gCanvas.FillPolygon(brush, coordinates);
        }
    }

    class CEllipse : CTwoDFigure
    {
        int deltX, deltY;
        public CEllipse(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            Draw();
        }
        public override double getPerimeter()
        {
            return Math.PI * (deltX / 2 + deltY / 2);
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }
    }

    class CCircle : CTwoDFigure
    {
        int radius;
        public CCircle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            int deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            int deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            radius = (int) Math.Sqrt(deltX * deltX + deltY * deltY);
            Draw();
        }
        public override double getPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius, 2 * radius);
        }
    }
}
