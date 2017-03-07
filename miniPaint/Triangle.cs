using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    class CTriangle : CTwoDFigure
    {
        public CTriangle(Color color, Point[] points, Graphics canv) : base(color, points, canv) { }
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
}
