using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Inheritance
{
    public class CGroupFigureInfo
    {
        public Point[] Coordinates { get; set; }
        public Color Color { get; set; }
        public CTwoDFigureFactory Factory { get; set; }

        public CGroupFigureInfo(Point[] coords, Color col, CTwoDFigureFactory fact)
        {
            Coordinates = coords;
            Color = col;
            Factory = fact;
        }
    }
}
