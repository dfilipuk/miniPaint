using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace Inheritance
{
    public interface IPerimeter
    {
        double getPerimeter();
    }

    public interface ISelectable
    {
        bool isSelected { get; set; }
        bool isPointWithinFigure(int x, int y);
        void drawEditFrame();
    }

    public interface IEditable
    {
        void changeColor(Color newColor);
        void changePosition(int deltX, int deltY);
    }

    public interface IGroupable
    {
        bool IsInGroup { get; set; }
        void GetParams(out Point[] coords, out Color color);
    }

    public interface IFiguresGroup
    {
        void LoadGroupTemplate(List<CGroupFigureInfo> template);
    }

    /*
    [KnownType(typeof(CLine))]
    [KnownType(typeof(CRectangle))]
    [KnownType(typeof(CTriangle))]
    [KnownType(typeof(CEllipse))]
    [KnownType(typeof(CCircle))]
    [KnownType(typeof(CBezier))]
    */
    [KnownType("GetKnownTypes")]
    [DataContract]
    public abstract class CTwoDFigure
    {
        public static List<Type> KnownTypes { get; set; }
        [DataMember]
        protected Point[] coordinates;
        protected SolidBrush brush;
        protected Graphics gCanvas;
        [DataMember]
        protected Color curColor;
        public abstract void Draw();
        public abstract void Draw(Graphics canv);

        public CTwoDFigure(Color color, Point[] points, Graphics canv)
        {
            curColor = color;
            brush = new SolidBrush(color);
            coordinates = points;
            gCanvas = canv;
        }

        private static Type[] GetKnownTypes()
        {
            return CTwoDFigure.KnownTypes.ToArray();
        }
    }
}
