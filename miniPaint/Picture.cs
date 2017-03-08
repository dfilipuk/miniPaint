using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace miniPaint
{
    class CPicture
    {
        List<CTwoDFigure> figures;
        List<Point> points;
        Graphics gCanvas;
        Bitmap buffer;
        PictureBox curPicture;
        CTwoDFigureFactory curFigure;
        Color curColor;

        int pointsAmo;
        readonly Color canvasColor;

        public CPicture(PictureBox pb, CTwoDFigureFactory factory)
        {
            figures = new List<CTwoDFigure>();
            points = new List<Point>();

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;

            curPicture = pb;
            buffer = new Bitmap(curPicture.Width, curPicture.Height);
            gCanvas = Graphics.FromImage(buffer);

            Redraw();
        }

        public CPicture(PictureBox pb, CTwoDFigureFactory factory, string filepath)
        {
            figures = new List<CTwoDFigure>(loadPictureFromFile(filepath));
            points = new List<Point>();

            currentColor = Color.Black;
            canvasColor = Color.White;
            currentFigure = factory;
            pointsAmo = 0;

            curPicture = pb;
            buffer = new Bitmap(curPicture.Width, curPicture.Height);
            gCanvas = Graphics.FromImage(buffer);

            Redraw(gCanvas);
        }

        public void addPoint(int x, int y)
        {
            points.Add(new Point(x, y));
            pointsAmo++;

            if (curFigure.isFigureFull(pointsAmo))
            {
                addFigure();
                Redraw();
            }
            else
                drawPoint(x, y, curColor);
        }

        public void deletePoints()
        {
            points.Clear();
            pointsAmo = 0;
            Redraw();
        }

        public void Clear()
        {
            deletePoints();
            figures.Clear();
            gCanvas.Clear(canvasColor);
        }

        public void deleteLastFigure()
        {
            deletePoints();
            if (figures.Count > 0)
                figures.RemoveAt(figures.Count - 1);
            Redraw();
        }

        public void Redraw()
        {
            if (gCanvas != null)
            {
                gCanvas.Clear(canvasColor);
                for (int i = 0; i < figures.Count; i++)
                    figures[i].Draw();
                curPicture.Image = buffer;
            }
        }

        void Redraw(Graphics canv)
        {
            gCanvas.Clear(canvasColor);
            for (int i = 0; i < figures.Count; i++)
                figures[i].Draw(canv);
            curPicture.Image = buffer;
        }

        public void savePictureToFile(string filepath)
        {
            CTwoDFigure[] figuresForSave = figures.ToArray();
            var jsonSerializer = new DataContractJsonSerializer(typeof(CTwoDFigure[]));

            using (var fs = new FileStream(filepath, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, figuresForSave);
            }
        }

        CTwoDFigure[] loadPictureFromFile(string filepath)
        {
            CTwoDFigure[] result;
            var jsonSerializer = new DataContractJsonSerializer(typeof(CTwoDFigure[]));

            using (var fs = new FileStream(filepath, FileMode.Open))
            {
                result = (CTwoDFigure[]) jsonSerializer.ReadObject(fs);
            }

            return result;
        }

        void addFigure()
        {
            figures.Add(currentFigure.CreateFigure(curColor, points.ToArray(), gCanvas));
            points.Clear();
            pointsAmo = 0;
        }

        void drawPoint(int x, int y, Color color)
        {
            gCanvas.FillEllipse(new SolidBrush(color), x - 3, y - 3, 6, 6);
            curPicture.Image = buffer;
        }

        public CTwoDFigureFactory currentFigure
        {
            get
            {
                return curFigure;
            }
            set
            {
                curFigure = value;
                deletePoints();
            }
        }

        public Color currentColor
        {
            get
            {
                return curColor;
            }
            set
            {
                curColor = value;
                deletePoints();
            }
        }
    }
}
