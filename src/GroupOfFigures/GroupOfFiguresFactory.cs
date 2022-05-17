using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;

namespace GroupOfFigures
{
    class CGroupOfFiguresFactory : CTwoDFigureFactory
    {
        static CGroupOfFiguresFactory factory;

        public static CGroupOfFiguresFactory GetFactory()
        {
            if (factory == null)
            {
                factory = new CGroupOfFiguresFactory();
            }
            return factory;
        }

        private CGroupOfFiguresFactory() { }

        public override CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv)
        {
            if (CGroupOfFigures.IsTemplateLoaded)
            {
                return new CGroupOfFigures(color, points, canv);
            }
            else
            {
                return null;
            }
        }

        public override bool isFigureFull(int pointsAmo)
        {
            return pointsAmo == 1;
        }
    }
}
