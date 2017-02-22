using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class CTwoDPoint
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public CTwoDPoint(int x, int y)
        {
            X = x;
            Y = x;
        }
    }
    interface IPerimeter
    {
        int getPerimeter();
    }
    abstract class CTwoDFigure : IPerimeter
    {
        CTwoDPoint[] coordinates;
        public abstract int getPerimeter();
        public abstract void Draw();
    }
}
