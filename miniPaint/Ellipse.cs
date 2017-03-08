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
    [DataContract]
    class CEllipse : CTwoDFigure
    {
        [DataMember]
        int deltX;
        [DataMember]
        int deltY;
        public CEllipse(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            changeCoordinates();
        }
        public override double getPerimeter()
        {
            return Math.PI * (deltX / 2 + deltY / 2);
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillEllipse(brush, coordinates[0].X, coordinates[0].Y, deltX, deltY);
        }

        void changeCoordinates()
        {
            int x1 = coordinates[0].X;
            int x2 = coordinates[1].X;
            int y1 = coordinates[0].Y;
            int y2 = coordinates[1].Y;

            coordinates[0].X = x1 < x2 ? x1 : x2;
            coordinates[0].Y = y1 < y2 ? y1 : y2;

            coordinates[1].X = x1 > x2 ? x1 : x2;
            coordinates[1].Y = y1 > y2 ? y1 : y2;
        }
    }
}
