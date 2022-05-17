using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;

namespace Inheritance
{
    public abstract class CTwoDFigureFactory
    {
        public static List<MethodInfo> LoadedFactories { get; set; }
        public abstract CTwoDFigure CreateFigure(Color color, Point[] points, Graphics canv);
        public abstract bool isFigureFull(int pointsAmo);

        public static CTwoDFigureFactory GetFactory(int ind)
        {
            if ((ind < LoadedFactories.Count) && (ind >= 0))
            {
                MethodInfo m = LoadedFactories[ind];
                object obj = new object();
                object[] objArr = new object[0];
                return (CTwoDFigureFactory)m.Invoke(obj, objArr);
            }
            else
            {
                return null;
            }
        }
    }
}
