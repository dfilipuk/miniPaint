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
        static CLineFactory factory;

        private CLineFactory() { }

        public static CLineFactory getFactory()
        {
            if (factory == null)
                factory = new CLineFactory();
            return factory;
        }
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
        static CRectangleFactory factory;

        private CRectangleFactory() { }

        public static CRectangleFactory getFactory()
        {
            if (factory == null)
                factory = new CRectangleFactory();
            return factory;
        }
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
        static CTriangleFactory factory;

        private CTriangleFactory() { }

        public static CTriangleFactory getFactory()
        {
            if (factory == null)
                factory = new CTriangleFactory();
            return factory;
        }
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
        static CCircleFactory factory;

        private CCircleFactory() { }

        public static CCircleFactory getFactory()
        {
            if (factory == null)
                factory = new CCircleFactory();
            return factory;
        }
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
        static CEllipseFactory factory;

        private CEllipseFactory() { }

        public static CEllipseFactory getFactory()
        {
            if (factory == null)
                factory = new CEllipseFactory();
            return factory;
        }
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CEllipse(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 2;
        }
    }

    class CBezierFactory : CTwoDFigureFactory
    {
        static CBezierFactory factory;

        private CBezierFactory() { }

        public static CBezierFactory getFactory()
        {
            if (factory == null)
                factory = new CBezierFactory();
            return factory;
        }
        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            return new CBezier(color, points, canv);
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 4;
        }
    }
}
