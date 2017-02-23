using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
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
}
