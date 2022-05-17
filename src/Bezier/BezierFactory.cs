using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Bezier
{
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
