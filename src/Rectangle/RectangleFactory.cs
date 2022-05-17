using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Rectangle
{
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
}
