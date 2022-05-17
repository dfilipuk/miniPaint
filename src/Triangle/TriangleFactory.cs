using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Triangle
{
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
}
