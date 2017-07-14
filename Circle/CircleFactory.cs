using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Circle
{
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
}
