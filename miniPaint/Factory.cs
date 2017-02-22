using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    abstract class CTwoDFigureFactory
    {
        public abstract CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv);
        public abstract bool isFigureFull(int pointsAmo);
    }

    class CLineFactory : CTwoDFigureFactory
    {
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CLine(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 2;
        }
    }

    class CRectangleFactory : CTwoDFigureFactory
    {
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CRectangle(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 2;
        }
    }

    class CTriangleFactory : CTwoDFigureFactory
    {
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CTriangle(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 3;
        }
    }

    class CCircleFactory : CTwoDFigureFactory
    {
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CCircle(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 2;
        }
    }

    class CEllipseFactory : CTwoDFigureFactory
    {
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CEllipse(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 2;
        }
    }
}
