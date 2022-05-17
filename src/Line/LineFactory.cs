using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace Line
{
    public class CLineFactory : CTwoDFigureFactory
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
}
