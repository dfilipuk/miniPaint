﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    class CRectangle : CTwoDFigure
    {
        int deltX, deltY;
        public CRectangle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            changeCoordinates();
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

        void changeCoordinates()
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
    }
}
