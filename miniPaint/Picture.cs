using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    class CPicture
    {
        static CPicture instanse;

        List<CTwoDFigure> figures;
        List<Point> points;
        Graphics gCanvas;
        int pointsAmo;

        public Color curColor { get; set; }
        public CTwoDFigureFactory curFigure { get; set; }
        CPicture(Graphics canv) 
        {
            figures = new List<CTwoDFigure>();
            points = new List<Point>();

            curColor = Color.Black;
            curFigure = new CLineFactory();
            pointsAmo = 0;
            gCanvas = canv;
        }

        public static CPicture getPicture(Graphics canv)
        {
            if (instanse == null)
                instanse = new CPicture(canv);
            return instanse;
        }

        public void addPoint(int x, int y)
        {
            points.Add(new Point(x, y));
            pointsAmo++;

            if (curFigure.isFigureFull(pointsAmo))
                addFigure(); 
        }

        public void deletePoints()
        {
            points.Clear();
            pointsAmo = 0;
        }

        void addFigure()
        {
            figures.Add(curFigure.CreateFigure(curColor, points.ToArray(), gCanvas));
            points.Clear();
            pointsAmo = 0;
        }
    }
}
