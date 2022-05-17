using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Reflection;

namespace miniPaint
{
    class CFiguresGroupManager
    {
        CViewer UI;
        CFiguresLoader figuresLoader;
        Type figuresGroupType;

        List<CTwoDFigure> figuresGroup;

        public CFiguresGroupManager(CViewer userInterface, CFiguresLoader loader)
        {
            UI = userInterface;
            figuresLoader = loader;
            figuresGroup = new List<CTwoDFigure>();
            figuresGroupType = figuresLoader.FiguresGroupType;
        }

        public void AddFigure(IGroupable figure)
        {
            if (!figure.IsInGroup)
            {
                figure.IsInGroup = true;
                figuresGroup.Add(figure as CTwoDFigure);
            } 
        }

        public void RemoveLastFigure()
        {
            (figuresGroup[figuresGroup.Count - 1] as IGroupable).IsInGroup = false;
            figuresGroup.RemoveAt(figuresGroup.Count - 1);
        }

        public void ClearGroup()
        {
            for (int i = 0; i < figuresGroup.Count; i++)
            {
                (figuresGroup[i] as IGroupable).IsInGroup = false;
            }
            figuresGroup.Clear();
        }

        public void DrawGroup()
        {
            for (int i = 0; i < figuresGroup.Count; i++)
            {
                (figuresGroup[i] as ISelectable).drawEditFrame();
            }
        }

        public void SaveGroup()
        {
            if ((figuresGroupType != null) && (figuresGroup.Count > 0))
            {
                Point[] coordinates;
                Color color;
                CTwoDFigureFactory factory;
                CGroupFigureInfo elem;
                List<CGroupFigureInfo> groupTemplate = new List<CGroupFigureInfo>();
                for (int i = 0; i < figuresGroup.Count; i++)
                {
                    (figuresGroup[i] as IGroupable).GetParams(out coordinates, out color);
                    factory = figuresLoader.GetFactoryOfType(figuresGroup[i].GetType());
                    elem = new CGroupFigureInfo(coordinates, color, factory);
                    groupTemplate.Add(elem);
                }

                Bitmap img = new Bitmap(1,1);
                object[] args = new object[] { Color.Black, new Point[0], Graphics.FromImage(img) };
                object obj = Activator.CreateInstance(figuresGroupType, args);
                (obj as IFiguresGroup).LoadGroupTemplate(groupTemplate);
            }
        }
    }
}
