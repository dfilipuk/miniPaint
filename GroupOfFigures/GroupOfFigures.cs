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
    class CGroupOfFigures : CTwoDFigure, IFiguresGroup
    {
        public static List<CGroupFigureInfo> GroupTemplate { get; set; }
        public static bool IsTemplateLoaded { get; set; }

        private static int groupWidth;
        private static int groupHeight;
        private static Point groupCenter;

        [DataMember]
        CTwoDFigure[] figures;
        [DataMember]
        Point center;

        public CGroupOfFigures(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            if (points.Length != 0)
            {
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
    }
}
