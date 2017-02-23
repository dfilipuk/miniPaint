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
        List<CTwoDFigure> figures;
        List<Point> points;
        Graphics gCanvas;
        CTwoDFigureFactory curFigure;
        Color curColor;

        int pointsAmo;
        readonly Color canvasColor;
        
        public CPicture(Graphics canv) 
        {
            figures = new List<CTwoDFigure>();
            points = new List<Point>();

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = CLineFactory.getFactory();
            pointsAmo = 0;
            gCanvas = canv;
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

        public void Clear()
        {
            deletePoints();
            figures.Clear();
            gCanvas.Clear(canvasColor);
        }

        public void deleteLastFigure()
        {
            deletePoints();
            if (figures.Count > 0)
                figures.RemoveAt(figures.Count - 1);
            Redraw();
        }

        void addFigure()
        {
            figures.Add(currentFigure.CreateFigure(curColor, points.ToArray(), gCanvas));
            points.Clear();
            pointsAmo = 0;
        }

        void Redraw()
        {
            gCanvas.Clear(canvasColor);
            for (int i = 0; i < figures.Count; i++)
                figures[i].Draw();
        }

        public CTwoDFigureFactory currentFigure
        {
            get
            {
                return curFigure;
            }
            set
            {
                curFigure = value;
                deletePoints();
            }
        }

        public Color currentColor
        {
            get
            {
                return curColor;
            }
            set
            {
                curColor = value;
                deletePoints();
            }
        }
    }
}
