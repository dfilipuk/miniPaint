using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace miniPaint
{
    interface IPerimeter
    {
        double getPerimeter();
    }

    interface ISelectable
    {
        bool isSelected { get; set; }
        bool isPointWithinFigure(int x, int y);
        void drawEditFrame();
    }

    [KnownType(typeof(CLine))]
    [KnownType(typeof(CRectangle))]
    [KnownType(typeof(CTriangle))]
    [KnownType(typeof(CEllipse))]
    [KnownType(typeof(CCircle))]
    [KnownType(typeof(CBezier))]
    [DataContract]
    abstract class CTwoDFigure : IPerimeter
    {
        [DataMember]
        protected Point[] coordinates;
        protected SolidBrush brush;
        protected Graphics gCanvas;
        [DataMember]
        protected Color curColor;
        public abstract double getPerimeter();
        public abstract void Draw();
        public abstract void Draw(Graphics canv);

        public CTwoDFigure(Color color, Point[] points, Graphics canv)
        {
            curColor = color;
            brush = new SolidBrush(color);
            coordinates = points;
            gCanvas = canv;
        }
    }
}
