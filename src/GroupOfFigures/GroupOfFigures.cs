using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inheritance;
using System.Drawing;
using System.Runtime.Serialization;

namespace GroupOfFigures
{
    [DataContract]
    class CGroupOfFigures : CTwoDFigure, ISelectable, IEditable, IFiguresGroup
    {
        public static List<CGroupFigureInfo> GroupTemplate { get; set; }
        public static bool IsTemplateLoaded { get; set; }

        private static int groupWidth;
        private static int groupHeight;
        private static Point groupCenter;

        public bool isSelected { get; set; }

        int selectedFigureInd;
        [DataMember]
        CTwoDFigure[] figures;
        [DataMember]
        Point center;
        [DataMember]
        int curGroupWidth;
        [DataMember]
        int curGroupHeight;

        public CGroupOfFigures(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            if (points.Length != 0)
            {
                isSelected = false;
                selectedFigureInd = -1;
                center = new Point();
                center.X = points[0].X;
                center.Y = points[0].Y;
                CreateGroup();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Draw();
            }
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            for (int i = 0; i < figures.Length; i++)
            {
                figures[i].Draw(gCanvas);
            }
        }

        private void CreateGroup()
        {
            figures = new CTwoDFigure[GroupTemplate.Count];
            int deltX = center.X - groupCenter.X;
            int deltY = center.Y - groupCenter.Y;

            Point[] coordinates;
            CTwoDFigure newFigure;
            for (int i = 0; i < figures.Length; i++)
            {
                coordinates = new Point[GroupTemplate[i].Coordinates.Length];
                for (int j = 0; j < GroupTemplate[i].Coordinates.Length; j++)
                {
                    coordinates[j].X = GroupTemplate[i].Coordinates[j].X + deltX;
                    coordinates[j].Y = GroupTemplate[i].Coordinates[j].Y + deltY;
                }
                newFigure = GroupTemplate[i].Factory.CreateFigure(GroupTemplate[i].Color, coordinates, gCanvas);
                figures[i] = newFigure;
            }
            curGroupHeight = groupHeight;
            curGroupWidth = groupWidth;
        }

        /* Реализация интерфейса IFiguresGroup */

        public void LoadGroupTemplate(List<CGroupFigureInfo> template)
        {
            CGroupOfFigures.IsTemplateLoaded = true;
            CGroupOfFigures.GroupTemplate = template;

            int minX = GroupTemplate[0].Coordinates[0].X;
            int minY = GroupTemplate[0].Coordinates[0].Y;
            int maxX = GroupTemplate[0].Coordinates[0].X;
            int maxY = GroupTemplate[0].Coordinates[0].Y;

            for (int i = 0; i < GroupTemplate.Count; i++)
            {
                for (int j = 0; j < GroupTemplate[i].Coordinates.Length; j++)
                {
                    minX = GroupTemplate[i].Coordinates[j].X < minX ? GroupTemplate[i].Coordinates[j].X : minX;
                    minY = GroupTemplate[i].Coordinates[j].Y < minY ? GroupTemplate[i].Coordinates[j].Y : minY;
                    maxX = GroupTemplate[i].Coordinates[j].X > maxX ? GroupTemplate[i].Coordinates[j].X : maxX;
                    maxY = GroupTemplate[i].Coordinates[j].Y > maxY ? GroupTemplate[i].Coordinates[j].Y : maxY;
                }
            }

            groupWidth = maxX - minX;
            groupHeight = maxY - minY;
            groupCenter = new Point(minX + (groupWidth / 2), minY + (groupHeight / 2));
        }

        /* Реализация интерфейса ISelectable */

        public bool isPointWithinFigure(int x, int y)
        {
            ISelectable selectedFigure;
            for (int i = figures.Length; i > 0; i--)
            {
                selectedFigure = figures[i - 1] as ISelectable;
                if (selectedFigure.isPointWithinFigure(x, y))
                {
                    selectedFigureInd = i - 1;
                    return true;
                }
            }
            selectedFigureInd = -1;
            return false;
        }

        public void drawEditFrame()
        {
            SolidBrush frameBrush = new SolidBrush(Color.Green);
            Pen framePen = new Pen(frameBrush, 3);
            framePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            gCanvas.DrawRectangle(framePen, center.X - curGroupWidth / 2 - 3, center.Y - curGroupHeight / 2 - 3, 
                curGroupWidth + 5, curGroupHeight + 5);
            (figures[selectedFigureInd] as ISelectable).drawEditFrame();
        }

        /* Реализация интерфейса IEditable */

        public void changeColor(Color newColor)
        {
            if (selectedFigureInd != -1)
            {
                if (figures[selectedFigureInd] is IEditable)
                {
                    (figures[selectedFigureInd] as IEditable).changeColor(newColor);
                }
                else
                {
                    MakeFigureWithNewColor(newColor);
                }
            }
        }

        public void changePosition(int deltX, int deltY)
        {
            if (isSelected)
            {
                for (int i = 0; i < figures.Length; i++)
                {
                    if (figures[i] is IEditable)
                    {
                        (figures[i] as IEditable).changePosition(deltX, deltY);
                    }
                    else
                    {
                        MakeFigureWithNewPosition(i, deltX, deltY);
                    }
                }
                center.X += deltX;
                center.Y += deltY;
            }
        }

        private void MakeFigureWithNewColor(Color newColor)
        {
            Color color;
            Point[] coordinates;
            (figures[selectedFigureInd] as IGroupable).GetParams(out coordinates, out color);
            color = newColor;
            Type figType = figures[selectedFigureInd].GetType();
            object[] args = new object[] { color, coordinates, gCanvas };
            figures[selectedFigureInd] = (CTwoDFigure)Activator.CreateInstance(figType, args);
        }

        private void MakeFigureWithNewPosition(int ind, int deltX, int deltY)
        {
            Color color;
            Point[] coordinates;
            (figures[ind] as IGroupable).GetParams(out coordinates, out color);

            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i].X += deltX;
                coordinates[i].Y += deltY;
            }

            Type figType = figures[ind].GetType();
            object[] args = new object[] { color, coordinates, gCanvas };
            figures[ind] = (CTwoDFigure)Activator.CreateInstance(figType, args);
        }
    }
}
