using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Ellipse
{
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
}
