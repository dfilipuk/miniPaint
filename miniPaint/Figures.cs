using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miniPaint
{
    interface IPerimeter
    {
        double getPerimeter();
    }
    abstract class CTwoDFigure : IPerimeter
    {
        protected Point[] coordinates;
        protected SolidBrush brush;
        protected Graphics gCanvas;
        public abstract double getPerimeter();
        public abstract void Draw();

        public CTwoDFigure(Color color, Point[] points, Graphics canv)
        {
            brush = new SolidBrush(color);
            coordinates = points;
            gCanvas = canv;
        }
    }
}
