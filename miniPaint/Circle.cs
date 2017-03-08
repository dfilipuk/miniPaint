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
    class CCircle : CTwoDFigure
    {
        [DataMember]
        int radius;
        public CCircle(Color color, Point[] points, Graphics canv) : base(color, points, canv)
        {
            int deltX = Math.Abs(coordinates[0].X - coordinates[1].X);
            int deltY = Math.Abs(coordinates[0].Y - coordinates[1].Y);
            radius = (int)Math.Sqrt(deltX * deltX + deltY * deltY);
        }
        public override double getPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override void Draw()
        {
            gCanvas.FillEllipse(brush, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius, 2 * radius);
        }

        public override void Draw(Graphics canv)
        {
            gCanvas = canv;
            brush = new SolidBrush(curColor);

            gCanvas.FillEllipse(brush, coordinates[0].X - radius, coordinates[0].Y - radius, 2 * radius, 2 * radius);
        }
    }
}
